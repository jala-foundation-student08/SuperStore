using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperStore.Models.Entities;

namespace SuperStore.Services.Business
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProductsAsync();
        Task<Product> AddProductAsync(Product product);
    }
}
