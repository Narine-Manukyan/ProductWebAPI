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

        public async Task<Product> AddAsync(Product newProduct)
        {
            var result =  await db.Products.AddAsync(newProduct);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                db.Remove(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductBase>> GetAllAsync()
        {
            return await db.Products.ToListAsync<ProductBase>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(Product newProduct)
        {
            var result = await db.Products
                .FirstOrDefaultAsync(e => e.Id == newProduct.Id);

            if (result != null)
            {
                result.Name = newProduct.Name;
                result.Price = newProduct.Price;
                result.Available = newProduct.Available;
                result.Description = newProduct.Description;
                result.DateCreated = newProduct.DateCreated;
                await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
