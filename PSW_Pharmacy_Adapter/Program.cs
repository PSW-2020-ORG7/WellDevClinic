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
            CreateHostBuilder(args).Build().Run();
            //ActionsAndBenefitsMessages(args).Build().Run();
            UploadFileToSftpServer();
            
        }

        
        public static void UploadFileToSftpServer()
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.0.16 ", "tester", "password")))
            {
                client.Connect();
                string sourceFile = @"C:\Users\Nastasja\Desktop\psw projekat\WellDevClinic\PSW_Pharmacy_Adapter\wwwroot\html\index.html";
                using (Stream stream= File.OpenRead(sourceFile))
                {
                    client.UploadFile(stream, @"C:\Users\Nastasja\Desktop\ISA\ISA\pharmacy\Files\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
                }
                client.Disconnect();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHostBuilder ActionsAndBenefitsMessages(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .UseWindowsService()
               .ConfigureServices((hostContext, services) =>
               {
                   Console.WriteLine("tu je");
                   services.AddHostedService<TimerService>();
                   services.AddHostedService<RabbitMQService>();
               });

    }
}
