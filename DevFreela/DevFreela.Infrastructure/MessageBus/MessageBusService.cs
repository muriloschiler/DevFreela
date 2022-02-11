using DevFreela.Core.IServices;
using RabbitMQ.Client;

namespace DevFreela.Infrastructure.MessageBus{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _connectionFactory;
        public MessageBusService()
        {
            this._connectionFactory = new ConnectionFactory{
                HostName = "localhost",
                Port = 5672,
                RequestedHeartbeat = new System.TimeSpan(60),
                Ssl={
                    ServerName = "localhost",
                    Enabled = true 
                }
            };
        }


        public void Publish(string queue, byte[] message)
        {
            using(var connection = _connectionFactory.CreateConnection())
            {
                using(var chanel = connection.CreateModel())
                {
                    //Garantir que a fila, caso nao exista, seja criada    
                    chanel.QueueDeclare(
                        queue:queue,
                        durable:false,
                        exclusive:false,
                        autoDelete:false,
                        arguments:null
                    );

                    chanel.BasicPublish(
                        exchange:"",
                        routingKey:queue,
                        basicProperties:null,
                        body:message
                    );
                }
            }
        }
    }
}