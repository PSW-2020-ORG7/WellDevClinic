using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter
{
    public class MyContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseMySql("server=localhost;port=3306;database=adaptersdb;user=root;password=root");
            return new MyDbContext(builder.Options);
        }
    }
}
