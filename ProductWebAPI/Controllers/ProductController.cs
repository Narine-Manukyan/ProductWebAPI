using Microsoft.AspNetCore.Mvc;
using ProductCore;
using ProductData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IEnumerable<ProductBase>> GetAll()
        {
            return await productRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("Products/{id:int}")]
        public async Task<Product> GetByID(int id)
        {
            return await productRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync(Product newProduct)
        {
            await productRepository.AddAsync(newProduct);
            await productRepository.CommitAsync();
        }

        [HttpPut]
        public async Task Update(Product newProduct)
        {
            productRepository.Update(newProduct);
            await productRepository.CommitAsync();
        }
    }
}
