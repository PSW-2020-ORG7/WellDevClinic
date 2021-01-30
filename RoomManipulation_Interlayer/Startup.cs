using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EventSourcing;
using EventSourcing.Repository;
using EventSourcing.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomManipulation_Microservice.ApplicationServices;
using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain;
using RoomManipulation_Microservice.Repository;
using RoomManipulation_Microservice.Repository.Abstract;

namespace RoomManipulation_Interlayer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly("RoomManipulation_Microservice")).UseLazyLoadingProxies());

            services.AddScoped<IEquipmentAppService, EquipmentAppService>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();

            services.AddScoped<IRenovationAppService, RenovationAppService>();
            services.AddScoped<IRenovationRepository, RenovationRepository>();

            services.AddScoped<IRoomAppService, RoomAppService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IRoomTypeAppService, RoomTypeAppService>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddDbContext<EventDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironmentEventLogs(),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)).UseLazyLoadingProxies());


            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IDomainEventRepository, DomainEventRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext db, EventDbContext event_db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            event_db.Database.EnsureCreated();
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

        private string CreateConnectionStringFromEnvironmentEventLogs()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST_EVENTS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT_EVENTS") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA_EVENTS") ?? "eventlogs";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME_EVENTS") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD_EVENTS") ?? "root";
            return $"server={server};port={port};database={database};user={user};password={password};";
        }
    }
}
