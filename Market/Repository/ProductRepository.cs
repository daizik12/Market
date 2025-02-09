using Market.Interfaces;
using Market.Data;
using Market.Models;
using Market.DTOs.Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Market.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context) { _context = context; } 
        public async Task<Product?> CreateAsync(Product productmodel)
        {
            await _context.Products.AddAsync(productmodel);
            await _context.SaveChangesAsync();
            return productmodel;
        }
        public async Task<Product?> UpdateAsync(int id, UpdateDTO productDTO)
        {
            var exProduct = await _context.Products.FirstOrDefaultAsync(i=>i.Id == id);
            if (exProduct != null)
            { 
                exProduct.Name = productDTO.Name;
                exProduct.Description = productDTO.Description;
                exProduct.Price = productDTO.Price;
                exProduct.Fats = productDTO.fats;
                exProduct.Protein = productDTO.protein;
                exProduct.Carbohydrates = productDTO.carbohydrates;
            }
            await _context.SaveChangesAsync();
            return exProduct;
        }
        public async Task<Product?> DeleteAsync(int id)
        {
            var productmodel = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (productmodel != null)
            {
                _context.Products.Remove(productmodel);
                await _context.SaveChangesAsync();
                return productmodel;
            }
            return null;
        }

        public async Task<List<Product>?> GetAllAsync()
        {
            var Products = await _context.Products.ToListAsync();
            if (Products.Count > 0) return Products;
            return null;
        }
        public async Task<Product?> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i=>i.Id == id);
        }
    }
}
