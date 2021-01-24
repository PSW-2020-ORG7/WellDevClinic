using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Examination_Microservice.ApplicationSevices;
using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain;
using Examination_Microservice.Repository;
using Examination_Microservice.Repository.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Examination_Interlayer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            /* services.AddDbContext<MyDbContext>(opts =>
                     opts.UseMySql(CreateConnectionStringFromEnvironment(),
                     b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)).UseLazyLoadingProxies());*/

            services.AddDbContext<MyDbContext>(opts =>
                   opts.UseMySql(CreateConnectionStringFromEnvironment(),
                   b => b.MigrationsAssembly("Examination_Microservice")).UseLazyLoadingProxies());

            services.AddScoped<IExaminationDetailsAppService, ExaminationDetailsAppService>();
            services.AddScoped<IExaminationDetailsRepository, ExaminationDetailsRepository>();

            services.AddScoped<IPatientFileAppService, PatientFileAppService>();
            services.AddScoped<IPatientFileRepository, PatientFileRepository>();

            services.AddScoped<IHospitalizationAppService, HospitalizationAppService>();
            services.AddScoped<IHospitalizationRepository, HospitalizationRepository>();

            services.AddScoped<IReferralAppService, ReferralAppService>();
            services.AddScoped<IReferralRepository, ReferralRepository>();

            services.AddScoped<IPrescriptionAppService, PrescriptionAppService>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            services.AddScoped<ITherapyAppService, TherapyAppService>();
            services.AddScoped<ITherapyRepository, TherapyRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            /*try
            {
                var script = db.Database.GenerateCreateScript();
                db.Database.ExecuteSqlRaw(script);
            }
            catch
            {
                Console.WriteLine("Tables already exist!");
            }*/
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "DbDDD";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            return $"server={server};port={port};database={database};user={user};password={password};";
        }
    }
}
