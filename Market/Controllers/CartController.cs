using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Market.Models;
using Microsoft.AspNetCore.Authorization;

namespace Market.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository) => _cartRepository = cartRepository;
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody]Cart cart)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var cartmodel = await _cartRepository.GetByIdAsync(cart.Id);
            if (cartmodel != null) {
                cart.Quantity += cartmodel.Quantity;
                cartmodel = await _cartRepository.UpdateAsync(cart.Id, cart);
            }
            else
            {
                cartmodel = await _cartRepository.CreateAsync(cart);
            }
            return Ok(cartmodel);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var CartList = await _cartRepository.GetAllAsync();
            if (CartList == null) { return NotFound(); }
            return Ok(CartList);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartByUserId([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var Cart = await _cartRepository.GetByUserIdAsync(id);
            if (Cart == null) { return NotFound(); }
            return Ok(Cart);
        }

        /*
 [HttpGet("{id:int}")]
 public async Task<IActionResult> GetCartById([FromRoute] int id)
 {
     if (!ModelState.IsValid) return BadRequest(ModelState);
     var Carts = await _cartRepository.GetByIdAsync(id);
     if (Carts == null) { return NotFound(); }
     return Ok(Carts);
 }

 [HttpPost]
 public async Task<IActionResult> Create([FromBody] Cart cart)
 {
     if (!ModelState.IsValid) return BadRequest(ModelState);
     var cartmodel = cart;
     await _cartRepository.CreateAsync(cartmodel);
     return CreatedAtAction(nameof(Create), new { id = cartmodel.Id }, cartmodel);
 }
 [HttpPut, Route("{id:int}")]
 public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cart cart)
 {
     if (!ModelState.IsValid) return BadRequest();

     if (cart == null) return NotFound();
     var cartmodel = await _cartRepository.UpdateAsync(id, cart);
     return Ok(cartmodel);
 }
 [HttpDelete, Route("{id:int}")]
 public async Task<IActionResult> Delete([FromRoute] int id)
 {
     if(!ModelState.IsValid) return BadRequest(ModelState);
     var cartmodel = await _cartRepository.DeleteAsync(id);
     if(cartmodel == null) return NotFound();
     return NoContent();
 }*/
    }

}
