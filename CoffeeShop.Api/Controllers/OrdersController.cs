using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data;
using CoffeeShop.Data.BAL;
using CoffeeShop.Data.DTO;
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
        private readonly IOrderService orderService;
        private readonly ILogger<OrdersController> logger;
        private readonly MongoContext _dbContext;
        public OrdersController(DataService dataService, IOrderService orderService, ILogger<OrdersController> logger)
        {
            this.dataService = dataService;
            this.orderService = orderService;
            this.logger = logger;
            _dbContext = this.dataService.DbContext;
        }
        [HttpGet("all")]
        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.GetAsync();
        }
       
        [HttpPost("Place")]
        public async Task<Order> Insert(Order order)
        {
            // order default status will be zero which means new order
            // status 0= new, 1= preparing, 2= order completed

            order.Date = DateTime.Now;
            await _dbContext.Orders.InsertAsync(order);
            return order;
        }

        [HttpPost("AddItem")]
        public OrderDTO AddItem(OrderDTO dto)
        {
            orderService.AddItem(dto.NewItem, dto.Order);
            return dto;
        }

        [HttpPost("RemoveItem")]
        public OrderDTO RemoveItem(OrderDTO dto)
        {
            orderService.RemoveItem(dto.NewItem.SortId, dto.Order);
            return dto;
        }
    }
}
