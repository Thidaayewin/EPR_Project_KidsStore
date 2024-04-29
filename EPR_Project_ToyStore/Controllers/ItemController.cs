using System;
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
        public IActionResult Read()
        {
            var lst = _dbContext.Items.ToList();
            return Ok(lst);
        }
    }
}

