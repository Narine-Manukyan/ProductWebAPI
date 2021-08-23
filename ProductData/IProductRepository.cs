using ProductCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductData
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductBase>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task Update(Product newAccount);
        Task AddAsync(Product newAccount);
        Task<bool> Delete(int id);
        int Commit();
    }
}
