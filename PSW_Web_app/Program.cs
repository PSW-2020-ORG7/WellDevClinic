using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica;
using bolnica.Controller;
using bolnica.Controller.decorators;
using bolnica.Model;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using bolnica.Service;
using Controller;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using Service;

namespace PSW_Web_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static int calculatePort()
        {
            var port = System.Environment.GetEnvironmentVariable("PORT");
            if (port == null)
                return 49153;
            else
                return Int32.Parse(System.Environment.GetEnvironmentVariable("PORT"));
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

