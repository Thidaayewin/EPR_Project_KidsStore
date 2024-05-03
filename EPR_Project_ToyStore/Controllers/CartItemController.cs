using System;
using EPR_Project_ToyStore.Models;
using EPR_Project_ToyStore.Properties;
using Microsoft.AspNetCore.Mvc;

namespace EPR_Project_ToyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CartItemController()
        {
            _dbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult ReadCart()
        {
            var lst = _dbContext.CartItem.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult EditCart(int id)
        {
            var cart = _dbContext.CartItem.FirstOrDefault(x => x.CartItemId == id);
            if(cart is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(cart);
        }

        [HttpPost]
        public IActionResult CreateCart(CartItemModel cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.CartItem.Add(cartItem);
            var result= _dbContext.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateCart(int id, [FromBody] CartItemModel cartItem)
        {
            var cart = _dbContext.CartItem.FirstOrDefault(x => x.CartItemId == id);
            if (cart is null)
            {
                return NotFound("No Data Found");
            }
           
            var cartExists = _dbContext.Cart.Any(c =>c.CartId  == cartItem.CartId);
            if (!cartExists)
            {
                return BadRequest("Invalid cartId. Cart does not exist.");
            }

            var itemExists = _dbContext.Items.Any(i => i.ItemId == cartItem.ItemId);
            if (!itemExists)
            {
                return BadRequest("Invalid ItemId. Item does not exist.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cart.CartId = cartItem.CartId;
            cart.ItemId = cartItem.ItemId;
            cart.Quantity = cartItem.Quantity;
            var result = _dbContext.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete ("{id}")]
        public IActionResult DeletCart(int id)
        {
            var cart = _dbContext.CartItem.FirstOrDefault(x => x.CartItemId == id);
            if (cart is null)
            {
                return NotFound("No Data Found");
            }
            _dbContext.CartItem.Remove(cart);
            var result = _dbContext.SaveChanges();
           var message = result > 0 ? "Deleting successful" : "Deleting Failed";
            return Ok(message);
        }
	}
}

