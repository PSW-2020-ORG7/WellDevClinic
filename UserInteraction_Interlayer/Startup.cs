using System;
using System.Reflection;
using System.Data.Entity;

using UserInteraction_Microservice.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.ApplicationServices;
using UserInteraction_Microservice.Domain.DomainServices;
using UserInteraction_Microservice.Repository.Abstract;
using UserInteraction_Microservice.Repository;
using System.IO;

namespace UserInteraction_Interlayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly("UserInteraction_Microservice")).UseLazyLoadingProxies());

            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<IUserAppService, UserAppService>();

            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IDirectorAppService, DirectorAppService>();
            
            services.AddScoped<IDoctorAppService, DoctorAppService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            
            services.AddScoped<IDoctorGradeAppService, DoctorGradeAppService>();
            services.AddScoped<IDoctorGradeRepository, DoctorGradeRepository>();
            
            services.AddScoped<ISecretaryAppService, SecretaryAppService>();
            services.AddScoped<ISecretaryRepository, SecretaryRepository>();
            
            services.AddScoped<IPatientAppService, PatientAppService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IFeedbackAppService, FeedbackAppService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            services.AddScoped<IArticleAppService, ArticleAppService>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddScoped<ISpecialityAppService, SpecialityAppService>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            try
            {
                using (StreamReader file = new StreamReader("DBScript.txt"))
                {
                    string sqlRow = "";
                    string ln = "";

                    while ((ln = file.ReadLine()) != null)
                    {
                        sqlRow = sqlRow + " " + ln;
                        if (sqlRow.Contains(";"))
                        {
                            db.Database.ExecuteSqlCommand(sqlRow);
                            sqlRow = "";
                        }
                    }
                    file.Close();
                }
            }
            catch
            {
                Console.WriteLine("Tables already exist!");
            }

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
