using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data;
using CoffeeShop.Data.DAL;
using CoffeeShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DataService dataService;
        private readonly ILogger<ItemsController> logger;
        private readonly MongoContext _dbContext;

        public ItemsController(DataService dataService, ILogger<ItemsController> logger)
        {
            this.dataService = dataService;
            this.logger = logger;
            _dbContext = this.dataService.DbContext;
        }

        [HttpGet("all")]
        public async Task<List<Item>> GetAll()
        {
            return await _dbContext.Items.GetAsync();
        }
        [HttpGet("AllGroupDiscount")]
        public async Task<List<GroupDiscount>> AllGroupDiscount()
        {
            return await _dbContext.GroupDiscounts.GetAsync();
        }

        [HttpPost("InsertAll")]
        public async Task<List<Item>> InsertAll(List<Item> items)
        {
            await _dbContext.Items.InsertManyAsync(items);
            return items;
        }

        [HttpPost("InsertGroupDiscount")]
        public async Task<List<GroupDiscount>> InsertGroupDiscount(List<GroupDiscount> items)
        {
            await _dbContext.GroupDiscounts.InsertManyAsync(items);
            return items;
        }
    }
}
