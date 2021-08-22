using ProductCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductData
{
    public class ProductsData : IProductData
    {
        public Task Add(Product newAccount)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
