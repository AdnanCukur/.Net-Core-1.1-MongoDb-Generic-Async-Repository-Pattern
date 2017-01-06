using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsLearning.Data.Models
{
    public class Address
    {
        [BsonElement("Street")]
        public string Street { get; set; }
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("PostalCode")]
        public string PostalCode { get; set; }
    }
}
