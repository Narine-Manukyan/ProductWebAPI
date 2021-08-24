using ProductCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductData
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductBase>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateAsync(Product newProduct);
        Task<Product> AddAsync(Product newProduct);
        Task DeleteAsync(int id);
    }
}
