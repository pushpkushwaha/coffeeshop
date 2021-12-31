using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ItemsRepository _itemsRepo;
        private readonly GroupDiscountRepository _groupDiscountRepository;

        public ItemsController(ItemsRepository itemsRepo, GroupDiscountRepository groupDiscountRepository)
        {
            _itemsRepo = itemsRepo;
            _groupDiscountRepository = groupDiscountRepository;
        }

        [HttpGet("all")]
        public async Task<List<Item>> GetAll()
        {
            return await _itemsRepo.GetAsync();
        }
        [HttpGet("AllGroupDiscount")]
        public async Task<List<GroupDiscount>> AllGroupDiscount()
        {
            return await _groupDiscountRepository.GetAsync();
        }

        [HttpPost("InsertAll")]
        public async Task<List<Item>> InsertAll(List<Item> items)
        {
            await _itemsRepo.InsertManyAsync(items);
            return items;
        }

        [HttpPost("InsertGroupDiscount")]
        public async Task<List<GroupDiscount>> InsertGroupDiscount(List<GroupDiscount> items)
        {
            await _groupDiscountRepository.InsertManyAsync(items);
            return items;
        }
    }
}
