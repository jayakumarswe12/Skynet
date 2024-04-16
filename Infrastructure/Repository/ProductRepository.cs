using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}