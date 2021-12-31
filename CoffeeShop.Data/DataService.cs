using CoffeeShop.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data
{
   public class DataService
    {
      
        public DataService(IOptions<DbSettings> dbSettingsOptions)
        {
            DbContext = new MongoContext(dbSettingsOptions);
        }

        public MongoContext DbContext { get; private set; }
    }
}
