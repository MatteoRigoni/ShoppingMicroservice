using Shopping.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Client.Data
{
    public static class ProductContext
    {
        public static readonly List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id = "1",
                Name = "Procuct 1",
                Description = "Description of product 1",
                Category = "Main category",
                ImageFile = "product1.png",
                Price = 100
            },
            new Product()
            {
                Id = "2",
                Name = "Procuct 2",
                Description = "Description of product 2",
                Category = "Main category",
                ImageFile = "product2.png",
                Price = 200
            }
        };
    }
}
