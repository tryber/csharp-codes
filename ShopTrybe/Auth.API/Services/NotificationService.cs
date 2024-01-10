namespace Auth.API.Services;

using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Auth.API.Models;

public class NotificationService : INotificationService
{
    public void Send(Message message)
    {
        var messageBrokerHost = Environment.GetEnvironmentVariable("MESSAGE_BROKER_HOST");
        var _factory = new ConnectionFactory { HostName = messageBrokerHost };
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();
        {

            channel.QueueDeclare(queue: "notification",
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);


            string messageSerialize = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageSerialize);

            channel.BasicPublish(exchange: string.Empty,
                routingKey: "notification",
                basicProperties: null,
                body: body);
        }
    }
}