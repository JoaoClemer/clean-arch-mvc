using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            this._applicationDbContext.Add(product);
            await this._applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await this._applicationDbContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await this._applicationDbContext.Products.Include(p => p.Category).
                SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this._applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            this._applicationDbContext.Remove(product);
            await this._applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            this._applicationDbContext.Update(product);
            await this._applicationDbContext.SaveChangesAsync();
            return product;
        }
    }
}
