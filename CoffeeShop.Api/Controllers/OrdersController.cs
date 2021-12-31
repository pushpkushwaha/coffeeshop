using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data;
using CoffeeShop.Data.DAL;
using CoffeeShop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataService dataService;
        private readonly ILogger<OrdersController> logger;
        private readonly MongoContext _dbContext;
        public OrdersController(DataService dataService, ILogger<OrdersController> logger)
        {
            this.dataService = dataService;
            this.logger = logger;
            _dbContext = this.dataService.DbContext;
        }
        [HttpGet("all")]
        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.GetAsync();
        }

        [HttpPost("New")]
        public async Task<Order> Insert(Order order)
        {
            var groupDiscounts = _dbContext.GroupDiscounts.GetAsync().Result;
            order.GetTotal(groupDiscounts);
            await _dbContext.Orders.InsertAsync(order);
            return order;
        }

    }
}
