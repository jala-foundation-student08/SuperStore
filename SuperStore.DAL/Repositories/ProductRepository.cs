using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperStore.Models.Entities;

namespace SuperStore.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SuperStoreDbContext _dbContext;

        public ProductRepository(SuperStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IList<Product>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();

            return products;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }
    }
}
