using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperStore.API.Models;
using SuperStore.Models.Entities;
using SuperStore.Services.Business;
using System.Net;
using System.Threading.Tasks;

namespace SuperStore.API.Controllers
{
    [Route("api/products")]

    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddProductAsync([FromBody] UpsertProductDto upsertProductDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var product = _mapper.Map<Product>(upsertProductDto);

            var addProduct = await _productService.AddProductAsync(product);

            if (addProduct is null) return NotFound();

            var addProductDto = _mapper.Map<UpsertProductDto>(addProduct);

            return StatusCode((int)HttpStatusCode.Created, addProductDto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductDto>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products is null) return NotFound();

            var productListDto = _mapper.Map<IList<ProductDto>>(products);

            return Ok(productListDto);
        }
    }
}
