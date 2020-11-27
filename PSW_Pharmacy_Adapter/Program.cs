using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service;

namespace PSW_Pharmacy_Adapter
{
    public class Program
    {
        public static List<Message> Messages = new List<Message>();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            ActionsAndBenefitsMessages(args).Build().Run();
        }

        public static List<Api> Apis = new List<Api>()
        {
            new Api("pharmacy1", "api1", "localhost:454545"),
            new Api("pharmacy2", "api2", "localhost:9090"),
            new Api("pharmacy3", "api3", "localhost:556699"),
            new Api("pharmacy4", "api4", "localhost:8778"),
        };

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHostBuilder ActionsAndBenefitsMessages(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHostedService<TimerService>();
                   services.AddHostedService<SubscriberService>();
               });

    }
}
