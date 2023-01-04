using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();
        [HttpGet]
        public IActionResult GetAll(){
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id){
            try
            {
                var product = products.SingleOrDefault(p=>p.IdProduct==Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch 
            {
                
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult PostPrduct(ProductVM productVM){
            var product = new Product
            {
                IdProduct = Guid.NewGuid(),
                Name = productVM.Name,
                Price = productVM.Price
            };
            products.Add(product);
            return Ok(new 
            {
                Success = true,
                Data = product
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, Product productEdit){
            try
            {
                var product = products.SingleOrDefault(p=>p.IdProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.IdProduct.ToString())
                {
                    return BadRequest();
                }
                product.Name = productEdit.Name;
                product.Price = productEdit.Price;
                return Ok();
            }
            catch 
            {
                
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id){
            try
            {
                var product = products.SingleOrDefault(p=>p.IdProduct == Guid.Parse(id));

                if (product == null)
                {
                    NotFound();
                }
                products.Remove(product);
                return Ok();
            }
            catch
            {
                
                return BadRequest();
            }
        }
    }
}
