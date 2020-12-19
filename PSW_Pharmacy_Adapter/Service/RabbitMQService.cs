using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PSW_Pharmacy_Adapter.Service
{
    public class RabbitMQService : BackgroundService, IRabbitMQService
    {
        IConnection connection;
        IModel channel;
        

        private IActionAndBenefitRepository _ActionRepository;
        /*public RabbitMQService(IActionAndBenefitRepository actionsRepo)
        {
            _ActionRepository = actionsRepo;
        }*/

   
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            MyContextFactory cf = new MyContextFactory();
            _ActionRepository = new ActionAndBenefitRepository(cf.CreateDbContext(new string[0]));
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
                ActionAndBenefit actionAndBenefit = ActionAndBenefitMapper.mapActionAndBenefit(
                                                     JsonConvert.DeserializeObject<ActionAndBenefitDto>(
                                                     jsonMessage.ToString()), ActionStatus.pending);
                Console.WriteLine(" [x] Received {0}", actionAndBenefit.PharmacyName);
                _ActionRepository.Save(actionAndBenefit);
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
