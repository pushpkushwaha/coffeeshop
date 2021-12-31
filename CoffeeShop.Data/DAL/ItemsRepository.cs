using CoffeeShop.Data.Models;
using CoffeeShop.Infra;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.DAL
{
    public class ItemsRepository : BaseRepository<Item>
    {
        public ItemsRepository(IOptions<DbSettings> dbSettingsOptions)
            : base(dbSettingsOptions, "Items")
        {

        }
    }
}
