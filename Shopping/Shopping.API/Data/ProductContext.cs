using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existsProduct = productCollection.Find(p => true).Any();
            if (!existsProduct)
            {
                productCollection.InsertMany(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Product 1",
                    Description = "Description of product 1",
                    Category = "Main category",
                    ImageFile = "product1.png",
                    Price = 100
                },
                new Product()
                {
                    Name = "Product 2",
                    Description = "Description of product 2",
                    Category = "Main category",
                    ImageFile = "product2.png",
                    Price = 200
                },
                new Product()
                {
                    Name = "Product 3",
                    Description = "Description of product 3",
                    Category = "Main category",
                    ImageFile = "product3.png",
                    Price = 8
                }
            };
        }

        public IMongoCollection<Product> Products { get; }
    }
}
