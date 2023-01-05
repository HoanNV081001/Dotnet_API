using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSearchController : ControllerBase
    {
        private readonly IProductResposity _IProductResposity;

        public ProductSearchController(IProductResposity IProductResposity){
            _IProductResposity = IProductResposity;
        }
         [HttpGet]
        public IActionResult GettAllProducts(string? search, double? from, double? to, string? sortBy, int page =1)
        {
             try
            {
                var result = _IProductResposity.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
    }
}
