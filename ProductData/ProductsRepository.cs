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
            await db.AddAsync(newProduct);
        }

        public async Task<int> CommitAsync()
        {
            return await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
                db.Remove(product);
        }

        public async Task<IEnumerable<ProductBase>> GetAllAsync()
        {
            return await db.Products.ToListAsync<ProductBase>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public void Update(Product newProduct)
        {
            var entity = db.Products.Attach(newProduct);
            entity.State = EntityState.Modified;
        }
    }
}
