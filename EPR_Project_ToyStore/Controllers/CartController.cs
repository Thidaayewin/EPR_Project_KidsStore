using System;
using EPR_Project_ToyStore.Models;
using EPR_Project_ToyStore.Properties;
using Microsoft.AspNetCore.Mvc;

namespace EPR_Project_ToyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
		private readonly AppDbContext _dbContext;

        public CartController() {

            _dbContext = new AppDbContext();
		}

        [HttpGet]
        public IActionResult ReadCart()
        {
            var lst = _dbContext.Cart.ToList();
            return Ok(lst);
        }

        [HttpGet ("{id}")]
        public IActionResult EditCart(int id)
        {
            var cart = _dbContext.Cart.FirstOrDefault(x => x.CartId == id);
            return Ok(cart);
        }

        [HttpPost]
        public IActionResult CreateCart(CartModel cartModel)
        {   
            _dbContext.Cart.Add(cartModel);
            var result = _dbContext.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving Failed";
            return Ok(message);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCart(int id, [FromBody] CartModel cartModel)
        {
            var cart = _dbContext.Cart.FirstOrDefault(x => x.CartId == id);
            if (cart is null)
            {
                return NotFound("No data found.");
            }

            var result = _dbContext.SaveChanges();
            string message = result > 0 ? "Updating successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCart(int id)
        {
            var cart = _dbContext.Cart.FirstOrDefault(x => x.CartId == id);
            if (cart is null)
            {
                return NotFound("No data found.");
            }

            _dbContext.Cart.Remove(cart);
            var result = _dbContext.SaveChanges();
            var message = result > 0 ? "Deleting successful" : "Deleting Failed";
            return Ok(message);
        }
	}
}

