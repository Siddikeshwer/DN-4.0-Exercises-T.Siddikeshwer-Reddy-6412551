using Microsoft.AspNetCore.Mvc;
using WebApi_Handson_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi_Handson_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Pen", Price = 10 },
            new Product { Id = 2, Name = "Book", Price = 50 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updated)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return Ok(products);
        }
    }
}
