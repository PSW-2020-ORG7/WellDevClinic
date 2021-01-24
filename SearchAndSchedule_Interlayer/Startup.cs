using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchAndSchedule_Microservice.ApplicationServices;
using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain;
using SearchAndSchedule_Microservice.Repository;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.IO;
using System.Reflection;

namespace SearchAndSchedule_Interlayer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly("SearchAndSchedule_Microservice")).UseLazyLoadingProxies());

            services.AddScoped<IBussinesDayAppService, BusinessDayAppService>();
            services.AddScoped<IBussinesDayRepository, BussinesDayRepository>();

            services.AddScoped<IExaminationAppService, ExaminationAppService>();
            services.AddScoped<IExaminationRepository, ExaminationRepository>();

            services.AddScoped<IOperationAppService, OperationAppService>();
            services.AddScoped<IOperationRepository, OperationRepository>();

            services.AddScoped<ISearchPeriods, DatePrioritySearch>();
            services.AddScoped<ISearchPeriods, NoPrioritySearch>();
            services.AddScoped<ISearchPeriods, DoctorPrioritySearch>();

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
