using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.Models
{
    [BsonIgnoreExtraElements]
    public partial class Order : IEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public List<Item> Items { get; set; }

        public DateTime Date { get; set; }

        private int _status;
        public int Status
        {
            get { return _status; }

            set
            {
                _status = value;
                // value 2== order completed
                if (value == 2 && NotifyOrderCompletion != null)
                {
                    NotifyOrderCompletion.Invoke();
                }
            }
        }

        public double Total { get; set; }

        public event Action NotifyOrderCompletion;
    }
}
