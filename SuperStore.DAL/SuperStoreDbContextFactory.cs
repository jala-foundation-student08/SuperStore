using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SuperStore.DAL
{
    public class SuperStoreDbContextFactory : IDesignTimeDbContextFactory<SuperStoreDbContext>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public SuperStoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SuperStoreDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                options =>
                {
                    options.EnableRetryOnFailure();
                });

            return new SuperStoreDbContext(optionsBuilder.Options);
        }
    }
}
