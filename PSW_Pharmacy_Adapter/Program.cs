using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices;

namespace PSW_Pharmacy_Adapter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var consumer = new Task(() => CreateHostBuilderForRabbitMQ(args).Build().Run());
            consumer.Start();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilderForRabbitMQ(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<RabbitMQService>();
                });


        private static int calculatePort()
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            if (port == null)
                return 64724;
            else
                return int.Parse(Environment.GetEnvironmentVariable("PORT"));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.ListenAnyIP(calculatePort());
                    })
                    .UseStartup<Startup>();
                });

    }
}
