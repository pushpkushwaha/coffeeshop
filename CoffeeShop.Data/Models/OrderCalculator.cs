using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop.Data.Models
{
    public partial class Order
    {
        public void GetTotal(List<GroupDiscount> groupDiscount)
        {
            double _total = 0;
            this.Items.ForEach(item =>
            {
                _total += GetItemPrice(item, groupDiscount);
            });
            this.Total = _total;
        }

        private double GetItemPrice(Item item, List<GroupDiscount> _groupDiscount)
        {
            double total = 0;
            double totalDiscount = 0;

            var t = _groupDiscount.FirstOrDefault(x => x.ItemId == item.Id);
            if (t != null)
            {
                bool allExists = t.OtherItemIds.All(x => this.Items.Any(y => y.Id == x));
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
