using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext { get; set; }

        public ProductRepository(ApplicationDbContext context) => this._productContext = context;
        public async Task<Product> CreateAsync(Product product)
        {
            this._productContext.Add(product);

            await this._productContext.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this._productContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await this._productContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            //eager loading
            return await this._productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.CategoryId == id);
        }


        public async Task<Product> UpdateAsync(Product product)
        {
            this._productContext.Update(product);

            await this._productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            this._productContext.Remove(product);

            await this._productContext.SaveChangesAsync();

            return product;
        }
    }
}