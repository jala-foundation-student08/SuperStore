using Microsoft.EntityFrameworkCore;
using SuperStore.Models.Entities;

namespace SuperStore.DAL
{
    public class SuperStoreDbContext : DbContext
    {
        public SuperStoreDbContext(DbContextOptions options) : base(options){}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }


    }
}
