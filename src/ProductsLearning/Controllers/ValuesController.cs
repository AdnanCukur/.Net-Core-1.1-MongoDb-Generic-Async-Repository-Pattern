﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductsLearning.Data.Models;
using ProductsLearning.Data.Repository;

namespace ProductsLearning.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IRepository<Person> _personRepository;

        public ValuesController(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            List<Person> pelles =_personRepository.Find(x => x.Firstname == "pelle").ToList();
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var allPeople = _personRepository.FindAll();
            //var allProducts = _productRepository.ToList();
            return new string[] { "value1", "value2" };
        }

        public async Task<IEnumerable<Person>> SomethingAsync()
        {
            var customers = await _personRepository.FindAsync(x => x.Orders.Count > 0);
            return customers;
        }
        private List<Product> getProductSeedData()
        {
            var seed = new List<Product>();
            for (int i = 0; i < 50; i++)
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
        private List<Person> getPersonSeedData()
        {
            var seed = new List<Person>();
            for (int i = 0; i < 1000; i++)
            {
                seed.Add(new Person
                {
                    Address = new Address()
                    {
                        City = "Gothenburg",
                        PostalCode = "463322",
                        Street = "Kungsgatan 10"
                    },
                    Firstname = "Bert",
                    Lastname = "Karlsson",
                    Orders = new List<Order>
                    {
                        new Order()
                        {
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 23
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                }
                            }

                        },
                        new Order()
                        {
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 23
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                }
                            }

                        },
                        new Order()
                        {
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 23
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                }
                            }

                        },
                        new Order()
                        {
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 23
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                },
                                new Product
                                {
                                    Brand = "Apple",
                                    Category = "Computers",
                                    Name = "Macbook pro 10",
                                    Price = 22
                                }
                            }

                        },
                    }
                });
            }
            return seed;
        }
    }
}
