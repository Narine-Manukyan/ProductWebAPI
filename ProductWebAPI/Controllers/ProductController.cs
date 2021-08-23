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
        public async Task<IEnumerable<ProductBase>> GetAll()
        {
            return await productRepository.GetAllAsync();
        }
    }
}
