using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Data.Models
{
    [BsonIgnoreExtraElements]
    public class GroupDiscount : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ItemId { get; set; }
        public List<string> OtherItemIds { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
