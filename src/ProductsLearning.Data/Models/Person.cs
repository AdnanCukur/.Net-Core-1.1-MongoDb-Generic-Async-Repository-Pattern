using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsLearning.Data.Models
{
    public class Person: Entity
    {
        [BsonElement("Firstname")]
        public string Firstname { get; set; }
        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("Address")]
        public Address Address { get; set; }
        [BsonElement("Orders")]
        public List<Order> Orders { get; set; }

        public Person()
        {
            Orders = new List<Order>();
        }

    }
}
