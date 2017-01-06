using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsLearning.Data.Models
{
    public class Product : Entity
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public int Price { get; set; }

        [BsonElement("Brand")]
        public string Brand { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

    }
}
