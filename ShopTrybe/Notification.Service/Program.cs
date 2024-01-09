using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Notification.Service.Models;

namespace Notification.Service
{
    public class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {

        Inicio:
            try
            {

                var factory = new ConnectionFactory { HostName = "localhost" };
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
                   Console.WriteLine("New e-mail - Subsject: " + message.Title + " - " + message.MailTo);

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