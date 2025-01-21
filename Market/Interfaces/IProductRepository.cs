using Market.DTOs.Product;
using Market.Models;

namespace Market.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> CreateAsync(Product productModel);
        Task<Product?> GetAsync(int id);
        Task<List<Product>?> GetAllAsync();
        Task<Product?> UpdateAsync(int id, UpdateDTO productModel);
        Task<Product?> DeleteAsync(int id);


    }
}
