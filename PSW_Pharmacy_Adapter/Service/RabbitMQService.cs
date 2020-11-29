using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Converter;
using PSW_Pharmacy_Adapter.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PSW_Pharmacy_Adapter.Service
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "pharmacy.queue",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                Message message;
                try
                {   // try deserialize with default datetime format
                    message = JsonConvert.DeserializeObject<Message>(jsonMessage);
                }
                catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                {
                    message = JsonConvert.DeserializeObject<Message>(jsonMessage, new MyDateTimeConverter());
                }
                Console.WriteLine(" [x] Received {0}", message);
                Program.Messages.Add(message);
            };
            channel.BasicConsume(queue: "pharmacy.queue",
                                    autoAck: true,
                                    consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
