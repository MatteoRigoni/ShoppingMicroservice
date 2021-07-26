using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context
                .Products
                .Find(p => true)
                .ToListAsync();

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new Product()
            //{
            //    Name = $"Product {index}"
            //}).ToArray();
        }
    }
}
