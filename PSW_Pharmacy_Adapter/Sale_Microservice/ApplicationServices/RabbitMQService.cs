using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository.Iabstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices
{
    public class RabbitMQService : BackgroundService, IRabbitMQService
    {
        IConnection connection;
        IModel channel;
        
        private ISaleRepository _saleRepository;
   
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            MyContextFactory cf = new MyContextFactory();
            _saleRepository = new SaleRepository(cf.CreateDbContext(new string[0]));
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "pharmacy.queue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                Sale sale = SaleMapper.MapSale(JsonConvert.DeserializeObject<SaleDto>(
                                                     jsonMessage.ToString()), SaleStatus.pending);
                Console.WriteLine(" [x] Received {0}", sale.PharmacyName);
                _saleRepository.Save(sale);
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
            => Task.CompletedTask;

    }
}
