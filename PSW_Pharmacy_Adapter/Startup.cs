using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using Grpc.Core;
using PSW_Pharmacy_Adapter.Protos;
using System;
using System.Reflection;


namespace PSW_Pharmacy_Adapter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)).UseLazyLoadingProxies());
            services.AddScoped<IApiKeyService, ApiKeyService>();
            services.AddScoped<IGreetingsService, GreetingsService>();
            services.AddScoped<IActionsAndBenefitsService, ActionsAndBenefitsService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<ITenderOfferService, TenderOfferService>();
            services.AddScoped<ITenderService, TenderService>();

            services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            services.AddScoped<IActionAndBenefitRepository, ActionAndBenefitRepository>();
            services.AddScoped<ITenderOfferRepository, TenderOfferRepository>();
            services.AddScoped<ITenderRepository, TenderRepository>();

            services.AddHttpClient();
        }

        private Server server;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime, MyDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();


            server = new Server
            {
                Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
                Ports = { new ServerPort("localhost", 8989, ServerCredentials.Insecure) }
            };
            server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutdown);

        }

        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }

        }


        private string CreateConnectionStringFromEnvironment()
        {
            string host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "adaptersdb";
            string username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            return $"server={host};port={port};database={database};username={username};password={password}";
        }
    }
}
