using System;
using EPR_Project_ToyStore.Models;
using EPR_Project_ToyStore.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPR_Project_ToyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ItemController()
        {
            _dbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult ItemList()
        {
            var lst = _dbContext.Items.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult ItemEdit(int id)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.ItemId == id);

            if (item is null)
            {
                return NotFound("No data found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult ItemCreate(ItemModel itemM)
        {
            _dbContext.Items.Add(itemM);
            var result = _dbContext.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult ItemUpdate(int id, [FromBody] ItemModel itemM)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.ItemId == id);

            if (item is null)
            {
                return NotFound("No data found.");
            }

            item.ItemName = itemM.ItemName;
            item.ItemPrice = itemM.ItemPrice;
            item.ItemDescription = itemM.ItemDescription;
            item.ItemAgelimit = itemM.ItemAgelimit;
            var result = _dbContext.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult ItemDelete(int id)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.ItemId == id);

            if (item is null)
            {
                return NotFound("No data found.");
            }

            _dbContext.Items.Remove(item);
            var result = _dbContext.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
    }
}

