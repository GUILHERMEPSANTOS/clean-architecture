using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext { get; set; }

        public CategoryRepository(ApplicationDbContext context) => this._categoryContext = context;

        public async Task<Category> CreateAsync(Category category)
        {
            this._categoryContext.Add(category);

            await this._categoryContext.SaveChangesAsync();

            return category;
        }
        public async Task<Category> GetByIdAsync(int? id)
        {
            return await this._categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await this._categoryContext.Categories.ToListAsync();
        }
        public async Task<Category> DeleteAsync(Category category)
        {
            this._categoryContext.Remove(category);

            await this._categoryContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            this._categoryContext.Update(category);

            await this._categoryContext.SaveChangesAsync();

            return category;
        }

    }
}