using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service;
using Renci.SshNet;

namespace PSW_Pharmacy_Adapter
{
    public class Program
    {
        public static List<Message> Messages = new List<Message>();

        public static void Main(string[] args)
        {
            var consumer = new Task(() => CreateHostBuilderForRabbitMQ(args).Build().Run());
            consumer.Start();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHostBuilder CreateHostBuilderForRabbitMQ(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    Console.WriteLine("tu je");
                    services.AddHostedService<RabbitMQService>();
                });

    }
}
