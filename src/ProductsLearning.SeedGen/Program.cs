using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using ProductsLearning.Data.Models;
using ProductsLearning.Data.Repository;
using ProductsLearning.SeedGen.SeedData;
using Person = ProductsLearning.Data.Models.Person;

namespace ProductsLearning.SeedGen
{
    public class Program
    {
        private static readonly Repository<Person> _personRepository = new Repository<Person>("mongodb://localhost:27017/adoshop");

        public static void Main(string[] args)
        {

            var testProduct = new Faker<Product>()
                .RuleFor(x => x.Brand, f => f.PickRandom(Clothing.Brands))
                .RuleFor(x => x.Category, f => f.Commerce.Product())
                .RuleFor(x => x.Price, f => f.Random.Number(99, 1000))
                .RuleFor(x => x.Name, (f,x) => f.Commerce.ProductAdjective() + " " + f.Commerce.ProductMaterial() + " " + x.Category);

            var testOrders = new Faker<Order>()
                .RuleFor(x => x.Products, f => testProduct.Generate(f.Random.Number(1, 10)).ToList());
            var testAddress = new Faker<Address>()
                .RuleFor(x => x.Street, f => f.Address.StreetAddress())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.PostalCode, f => f.Address.ZipCode());
            var testUsers = new Faker<Person>()
                .RuleFor(u => u.Firstname, f => f.Name.FirstName())
                .RuleFor(u => u.Lastname, f => f.Name.LastName())
                .RuleFor(u => u.Address, f => testAddress.Generate())
                .RuleFor(u => u.Orders, f => testOrders.Generate(f.Random.Number(1, 5)).ToList());
            var inserted = 0;
            var insertsPerCommit = 1000;
            Stopwatch sw = new Stopwatch();
            
            for (int i = 0; i < 1000; i++)
            {

                var test = testUsers.Generate(insertsPerCommit);
                sw.Start();
                _personRepository.Insert(test);
                inserted += insertsPerCommit;
                sw.Stop();
                Console.WriteLine($"Inserted {insertsPerCommit} in {(double) sw.ElapsedMilliseconds/(double) 1000}s with a speed of {(((double)insertsPerCommit)/((double)sw.ElapsedMilliseconds))*1000} /s. Total: {inserted}");
                sw.Reset();
            }

        }

    }
}
