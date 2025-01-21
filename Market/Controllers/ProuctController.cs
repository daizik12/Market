using Market.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Market.Data;
using Market.Interfaces;
using Market.Mapppers;
using Market.DTOs.Product;

namespace Market.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IProductRepository _repository;

        public ProductController(ApplicationContext context, IProductRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var product = await _repository.GetAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO Product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var productmodel = Product.ToProductFromCreate();
            await _repository.CreateAsync(productmodel);

            return CreatedAtAction(nameof(GetById), new { id = productmodel.Id }, productmodel);
        }
        [HttpPut, Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDTO productUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ProductModel = await _repository.UpdateAsync(id, productUpdate);
            if(ProductModel == null) return NotFound();
            return Ok(ProductModel);
        }
        [HttpDelete, Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var ProductModel = await _repository.DeleteAsync(id);

            if(ProductModel == null) return NotFound();
            
            return NoContent();
        }

    }
}
