using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace bolnica
{
    public class MyContextContextFactory : IDesignTimeDbContextFactory<EventDbContext>
    {

        public EventDbContext CreateDbContext(string[] args)
        {
            /*IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();s
            // Here we create the DbContextOptionsBuilder manually. */
            var builder = new DbContextOptionsBuilder<EventDbContext>();

            // Build connection string. This requires that you have a connectionstring in the appsettings.json
            var connectionString = "server=localhost;port=3306;database=eventlogs;user=root;password=root";
            builder.UseMySql(connectionString);
            // Create our DbContext.
            return new EventDbContext(builder.Options);
        }


    }
}
