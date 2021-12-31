using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop.Data.BAL
{
    public class OrderService : IOrderService
    {
        private readonly DataService dataService;
        private readonly List<GroupDiscount> _groupDiscount;
        public OrderService(DataService dataService)
        {
            this.dataService = dataService;
            _groupDiscount = dataService.DbContext.GroupDiscounts.GetAsync().Result;
        }

        public void AddItem(Item item, Order order)
        {
            if (item != null)
            {
                item.SortId = Guid.NewGuid().ToString();
                order.Items.Add(item);
                this.UpdateTotal(order);
            }
        }

        public void RemoveItem(string sortId, Order order)
        {
            order.Items = order.Items.TakeWhile(x => x.SortId != sortId)?.ToList();
            this.UpdateTotal(order);
        }
        private void UpdateTotal(Order order)
        {
            double _total = 0;
            order.Items.ForEach(item =>
            {
                _total += GetItemPrice(item, order);
            });
            order.Total = _total;
        }

        private double GetItemPrice(Item item, Order order)
        {
            double total = 0;
            double totalDiscount = 0;
            // below business logic depend upon busness requirement
            var t = _groupDiscount.FirstOrDefault(x => x.ItemId == item.Id);
            if (t != null)
            {
                bool allExists = t.OtherItemIds.All(x => order.Items.Any(y => y.Id == x));
                totalDiscount = allExists ? item.discount + t.DiscountPercentage : item.discount;
            }
            else
                totalDiscount = item.discount;

            total = item.price * (1 - (totalDiscount / 100));
            total += total * item.tax / 100;

            return total;
        }
    }
}
