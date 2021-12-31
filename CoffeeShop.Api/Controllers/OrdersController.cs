using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data.DAL;
using CoffeeShop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersRepository _ordersRepository;
        private readonly GroupDiscountRepository _groupDiscount;

        public OrdersController(OrdersRepository ordersRepository, GroupDiscountRepository groupDiscount)
        {
            _ordersRepository = ordersRepository;
            _groupDiscount = groupDiscount;
        }
        [HttpGet("all")]
        public async Task<List<Order>> GetAll()
        {
            return await _ordersRepository.GetAsync();
        }

        [HttpPost("New")]
        public async Task<Order> Insert(Order order)
        {
            var groupDiscounts = _groupDiscount.GetAsync().Result;
            order.GetTotal(groupDiscounts);
            await _ordersRepository.InsertAsync(order);
            return order;
        }

    }
}
