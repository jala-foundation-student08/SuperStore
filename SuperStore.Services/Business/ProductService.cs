using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperStore.DAL.Repositories;
using SuperStore.Models.Entities;

namespace SuperStore.Services.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return products;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var addProduct = await _productRepository.AddProductAsync(product);

            return addProduct;
        }
    }
}
