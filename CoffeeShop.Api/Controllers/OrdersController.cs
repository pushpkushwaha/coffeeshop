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
        [HttpGet("New")]
        public OrderViewModel NewOrder()
        {
            return new OrderViewModel();
        }
        [HttpPost("Place")]
        public async Task<OrderViewModel> Insert(OrderViewModel viewModel)
        {
            await _dbContext.Orders.InsertAsync(viewModel.Order);
            return viewModel;
        }

        [HttpPost("AddItem")]
        public OrderViewModel AddItem(OrderViewModel orderViewModel)
        {
            var groupDiscounts = _dbContext.GroupDiscounts.GetAsync().Result;
            if (orderViewModel.NewItem != null) orderViewModel.Order.Items.Add(orderViewModel.NewItem);
            orderViewModel.Order.GetTotal(groupDiscounts);
            return orderViewModel;
        }

    }
}
