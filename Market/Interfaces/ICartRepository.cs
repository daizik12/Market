using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> CreateAsync(Cart cart);
        Task<List<Cart>?> GetAllAsync();
        Task<Cart?> GetByIdAsync(int id);
        Task<List<Cart>?> GetByUserIdAsync(int userId);
        Task<Cart?> UpdateAsync(int id, Cart cart);
        Task<Cart?> DeleteAsync(int id);
    }
}
