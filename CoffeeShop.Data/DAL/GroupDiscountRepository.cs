using CoffeeShop.Data.Models;
using CoffeeShop.Infra;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.DAL
{
    public class GroupDiscountRepository : BaseRepository<GroupDiscount>
    {
        public GroupDiscountRepository(IOptions<DbSettings> dbSettingsOptions)
            : base(dbSettingsOptions, "GroupDiscount")
        {

        }
    }
}
