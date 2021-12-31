using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.Models
{
    [BsonIgnoreExtraElements]
    public partial class Item : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string SortId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double discount { get; set; }


    }
}
