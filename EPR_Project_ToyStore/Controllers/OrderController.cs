using System;
using EPR_Project_ToyStore.Models;
using EPR_Project_ToyStore.Properties;
using Microsoft.AspNetCore.Mvc;

namespace EPR_Project_ToyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public OrderController()
		{
            _dbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var lst = _dbContext.Orders.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult OrderEdit(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(x=> x.OrderId == id);
            if(order is null)
            {
                return NotFound("No data found.");
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult OrderCreate(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _dbContext.Items.FirstOrDefault(x => x.ItemId == orderModel.ItemId);
            if(item is null)
            {
                return NotFound("Item not found.");
            }

            decimal itemPrice = (decimal)item.ItemPrice;

            decimal amount = (decimal)(orderModel.OrderQuantity * itemPrice);

            var order = new OrderModel
            {
                ItemId = orderModel.ItemId,
                OrderDate = DateTime.Now,
                OrderQuantity = orderModel.OrderQuantity,
                Amount = amount,
            };

            _dbContext.Orders.Add(order);
            var result = _dbContext.SaveChanges();

            string message = result > 0 ? "Saving successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult OrderUpdate(int id, [FromBody] OrderModel orderModel)
        {
            var orderInfo = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);

            if (orderInfo is null)
            {
                return NotFound("No data found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _dbContext.Items.FirstOrDefault(x => x.ItemId == orderModel.ItemId);
            if (item is null)
            {
                return NotFound("Item not found.");
            }

            decimal amount = (decimal)(orderModel.OrderQuantity * item.ItemPrice);

            orderInfo.ItemId = orderModel.ItemId;
            orderInfo.OrderDate = DateTime.Now;
            orderInfo.OrderQuantity = orderModel.OrderQuantity;
            orderInfo.Amount = amount;
           
            var result = _dbContext.SaveChanges();

            string message = result > 0 ? "Updating successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult OrderDelete(int id)
        {
            var orderInfo = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
            if (orderInfo is null)
            {
                return NotFound("No data found.");
            }

            _dbContext.Orders.Remove(orderInfo);
            var result = _dbContext.SaveChanges();
            var message = result > 0 ? "Deleting successful" : "Deleting Failed";
            return Ok(message);
        }
	}
}

