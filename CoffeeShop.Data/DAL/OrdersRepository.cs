using CoffeeShop.Data.Models;
using CoffeeShop.Infra;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.DAL
{
    public class OrdersRepository : MongoSet<Order>
    {
        public OrdersRepository(IMongoDatabase db, string collectionName)
            : base(db, collectionName)
        {

        }
    }
}
