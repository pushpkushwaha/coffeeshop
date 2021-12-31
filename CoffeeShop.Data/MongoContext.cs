using CoffeeShop.Data.DAL;
using CoffeeShop.Data.Models;
using CoffeeShop.Infra;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data
{
    public class MongoContext
    {
        private IMongoDatabase _tcDb;
        protected readonly DbSettings dbSettings;
        public MongoContext(IOptions<DbSettings> dbSettingsOptions)
        {
            dbSettings = dbSettingsOptions.Value;
            var tcMongoClient = new MongoClient(dbSettings.ConnectionString);
            _tcDb = tcMongoClient.GetDatabase(dbSettings.DatabaseName);

            Items = new ItemsRepository(_tcDb, "Items");
            Orders = new OrdersRepository(_tcDb, "Orders");
            GroupDiscounts = new GroupDiscountRepository(_tcDb, "GroupDiscount");
        }

        public MongoSet<Item> Items { get; }
        public MongoSet<Order> Orders { get; }

        public MongoSet<GroupDiscount> GroupDiscounts { get; }
    }
}
