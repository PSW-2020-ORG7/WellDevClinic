using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bolnica.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace bolnica
{
    public class MyContextContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {

        public MyDbContext CreateDbContext(string[] args)
        {
            /*IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // Here we create the DbContextOptionsBuilder manually. */
            var builder = new DbContextOptionsBuilder<MyDbContext>();

            // Build connection string. This requires that you have a connectionstring in the appsettings.json
            var connectionString = "server=localhost;port=3306;database=newmydb;user=root;password=root";
            builder.UseMySql(connectionString);
            // Create our DbContext.
            return new MyDbContext(builder.Options);
        }


    }
}
