using ProductCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductData
{
    public interface IProductData
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Update(Product newAccount);
        Task Add(Product newAccount);
        Task<bool> Delete(int id);
        int Commit();
    }
}
