using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Notification.Service.Models;
using Notification.Service.Service;

using Serilog;
using Serilog.Events;
using Notification.Service.Utils;

namespace Notification.Service
{
    public class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            LogService.ConfigureLogger();
        Inicio:
            try
            {

                var MessageBrokerHost =  Environment.GetEnvironmentVariable("MESSAGE_BROKER_HOST");
                var factory = new ConnectionFactory { HostName = MessageBrokerHost };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "notification",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                Console.WriteLine("Waiting for new notifications.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    Message message = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body));
                    try
                    {
                        EmailService.Send(message);
                        Log.Information("Mail Sent");
                        Console.WriteLine("Mail sent");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Mail failed");
                    }

                };
                channel.BasicConsume(queue: "notification",
                        autoAck: true,
                        consumer: consumer);

                Console.CancelKeyPress += (o, e) =>
                {
                    Console.WriteLine("Exit...");
                    waitHandle.Set();
                };

                waitHandle.WaitOne();
            }
            catch (Exception connectionException)
            {
                Console.WriteLine("Error on connect to rabbitmq");
                Console.WriteLine("Trying reconnect");
                System.Threading.Thread.Sleep(5000);
                goto Inicio;
            }
        }
    }
}