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

namespace DevFreela.Payments.API.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string QUEUE = "Payments";
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
                queue:QUEUE,
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
                
                _channel.BasicAck(eventArgs.DeliveryTag,false);
            };
            
            _channel.BasicConsume(QUEUE,false,consumer);
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