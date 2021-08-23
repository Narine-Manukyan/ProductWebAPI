using Microsoft.EntityFrameworkCore;
using ProductCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductData
{
    public class ProductsRepository : IProductRepository
    {
        private readonly ProductDbContext db;

        public ProductsRepository(ProductDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CommitAsync()
        {
            return await db.SaveChangesAsync();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductBase>> GetAllAsync()
        {
            return await db.Products.ToListAsync<ProductBase>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public Task Update(Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
