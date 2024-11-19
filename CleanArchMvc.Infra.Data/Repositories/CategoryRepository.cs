using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            this._applicationDbContext.Add(category);
            await this._applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await this._applicationDbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await this._applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            this._applicationDbContext.Remove(category);
            await this._applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            this._applicationDbContext.Update(category);
            await this._applicationDbContext.SaveChangesAsync();
            return category;
        }
    }
}
