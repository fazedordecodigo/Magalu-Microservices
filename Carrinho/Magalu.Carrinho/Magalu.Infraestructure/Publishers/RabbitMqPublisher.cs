using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Application.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Magalu.Infraestructure.Publishers
{
    public class RabbitMqPublisher<T> : IPublisher<T> where T : class
    {
        private readonly RabbitMQSetting _rabbitMQSettings;

        public RabbitMqPublisher(IOptions<RabbitMQSetting> rabbitMQSetting)
        {
            _rabbitMQSettings = rabbitMQSetting.Value;
        }

        public async Task PublishAsync(T message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMQSettings.HostName,
                UserName = _rabbitMQSettings.UserName,
                Password = _rabbitMQSettings.Password,
                VirtualHost = "/",
                Port = 5672
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var messageJson = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageJson);

            await Task.Run(() => 
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body)
            );
        }
    }
}
