using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Payments.Core.DTO.InputModel;
using DevFreela.Payments.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DevFreela.Payments.Infrastructure.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string REQUIRED_PAYMENTS_QUEUE = "Required_Payments";
        private const string DONE_PAYMENTS_QUEUE = "Done_Payments";
        
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private IServiceProvider _serviceProvider;

        public ProcessPaymentConsumer(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;

            var factory = new ConnectionFactory{
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue:REQUIRED_PAYMENTS_QUEUE,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null
            );
            _channel.QueueDeclare(
                queue:DONE_PAYMENTS_QUEUE,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs ) => 
            {
                var paymentInfoBYTE = eventArgs.Body.ToArray();
                var paymentInfoJSON = Encoding.UTF8.GetString(paymentInfoBYTE);
                var paymentInfoInputModel = JsonSerializer
                    .Deserialize<PaymentInfoInputModel>(paymentInfoJSON);
                this.ProcessPayment(paymentInfoInputModel);
                

                //Enviar para a fila Done_Payments o id do projeto que foi pago
                var paymentDoneInputModel= new PaymentApprovedIntegrationEvent(paymentInfoInputModel.IdProject);
                var paymentDoneJSON = JsonSerializer.Serialize(paymentDoneInputModel);
                var paymentDoneBYTE = Encoding.UTF8.GetBytes(paymentDoneJSON);
                _channel.BasicPublish(
                    exchange: "",
                    routingKey: DONE_PAYMENTS_QUEUE,
                    basicProperties:null,
                    body:paymentDoneBYTE
                );
                
                //Enviar pra fila que a mensagem foi recebida
                _channel.BasicAck(eventArgs.DeliveryTag,false);
            };
            

            _channel.BasicConsume(REQUIRED_PAYMENTS_QUEUE,false,consumer);
            return Task.CompletedTask;
        }
        private void ProcessPayment(PaymentInfoInputModel paymentInfoInputModel)
        {
            using(var scoped = _serviceProvider.CreateScope()){
                var paymentService = scoped.ServiceProvider.GetRequiredService<IPaymentService>();
                paymentService.Pay(paymentInfoInputModel);
            }   
        }
    }
}