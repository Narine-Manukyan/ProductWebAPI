using ProductCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductData
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductBase>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        void Update(Product newProduct);
        Task AddAsync(Product newProduct);
        Task DeleteAsync(int id);
        Task<int> CommitAsync();
    }
}
