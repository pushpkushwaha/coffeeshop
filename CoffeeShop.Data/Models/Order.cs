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

        public int Status { get; set; }

        public double Total { get; set; }


    }
}
