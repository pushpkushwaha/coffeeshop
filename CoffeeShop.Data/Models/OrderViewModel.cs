using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.Models
{
    public class OrderViewModel 
    {
        public Item NewItem { get; set; }

        public Order Order { get; set; }
    }
}
