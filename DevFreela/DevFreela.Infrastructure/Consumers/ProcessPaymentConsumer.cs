using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.DTO;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DevFreela.Infrastructure.Consumers{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private IServiceProvider _serviceProvider;
        private const string DONE_PAYMENTS_QUEUE = "Done_Payments";

        public ProcessPaymentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        
            var connectionFactory = new ConnectionFactory{
                HostName = "localhost",
            };
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: DONE_PAYMENTS_QUEUE,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender , eventArgs)=>{
                var paymentApprovedIntegrationEventBYTE = eventArgs.Body.ToArray();
                var paymentApprovedIntegrationEventJSON = Encoding.UTF8.GetString(paymentApprovedIntegrationEventBYTE);
                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedIntegrationEventJSON);
                FinishProject(paymentApprovedIntegrationEvent);

                _channel.BasicAck(eventArgs.DeliveryTag,false);

            };

            _channel.BasicConsume(queue: DONE_PAYMENTS_QUEUE,false,consumer);
            return Task.CompletedTask;
        }

        private async void FinishProject(PaymentApprovedIntegrationEvent paymentApprovedIntegrationEvent)
        {
            using(var scope = _serviceProvider.CreateScope()){
                var projectRepository = scope.ServiceProvider.GetService<ProjectRepository>();
                var project = await projectRepository.GetProject(paymentApprovedIntegrationEvent.IdProject);
                await projectRepository.FinishProject(project);
            }
        }
    }
}