using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Grpc.Core;
using System;
using System.Reflection;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository;
using PSW_Pharmacy_Adapter.Medication_Microservice.Protos;

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
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)).UseLazyLoadingProxies());
            services.AddScoped<IApiKeyService, ApiKeyService>();
            services.AddScoped<IGreetingsService, GreetingsService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<ITenderOfferService, TenderOfferService>();
            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<IPharmacyEmailsService, PharmacyEmailsService>();

            services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ITenderOfferRepository, TenderOfferRepository>();
            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<IPharmacyEmailsRepository, PharmacyEmailsRepository>();

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
