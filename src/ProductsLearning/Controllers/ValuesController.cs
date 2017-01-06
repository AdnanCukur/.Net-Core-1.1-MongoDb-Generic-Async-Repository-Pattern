using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsLearning.Data.Models;
using ProductsLearning.Data.Repository;

namespace ProductsLearning.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static readonly MongoRepository<Product> _productRepository = new MongoRepository<Product>("mongodb://localhost:27017/adoshop");
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            var cont = _productRepository.Collection.;
            //var allProducts = _productRepository.ToList();
            return new string[] { "value1", "value2" };
        }

        private List<Product> getSeedData()
        {
            var seed = new List<Product>();
            for (int i = 0; i < 500000; i++)
            {
                seed.Add(new Product
                {
                    Brand = "Apple",
                    Category = "Computers",
                    Name = "Macbook Pro",
                    Price = i
                });
            }
            return seed;
        }
    }
}
