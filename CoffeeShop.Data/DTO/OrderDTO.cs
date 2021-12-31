using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.DTO
{
    public class OrderDTO
    {
       
        public Item NewItem { get; set; }

        public Order Order { get; set; }
    }
}
