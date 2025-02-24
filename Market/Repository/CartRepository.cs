using Market.Interfaces;
using Market.Data;
using Market.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;



namespace Market.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationContext _context;
        public CartRepository(ApplicationContext context) => _context = context;
        
        public async Task<Cart?> CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
        public async Task<List<Cart>?> GetAllAsync()
        {
            var Carts = await _context.Carts.ToListAsync();
            if (Carts.Any()) return Carts;
            return null;
        }
        public async Task<List<Cart>?> GetByUserIdAsync(int id)
        {
            var Carts = await _context.Carts.Where(x=>x.UserId ==id).ToListAsync();
            if(Carts!=null) return Carts;
            return null;
        }
        public async Task<Cart?> GetByIdAsync(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Cart?> UpdateAsync(int id, Cart cart)
        {
            var exCart = await _context.Carts.FirstOrDefaultAsync(i => i.Id == id);
            if (exCart != null)
            {
                exCart.Product = cart.Product;
                exCart.ProductId = cart.ProductId;
                exCart.Quantity = cart.Quantity;
            }
            await _context.SaveChangesAsync();
            return exCart;
        }
        public async Task<Cart?> DeleteAsync(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if(cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
            return null;
        }
        
    }
}
