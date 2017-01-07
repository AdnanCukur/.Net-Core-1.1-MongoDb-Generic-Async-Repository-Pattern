using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsLearning.Data.Models
{
    public class Order : Entity
    {
        [BsonElement("Products")]
        public List<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}
