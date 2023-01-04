using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_API.Data;
using Dotnet_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context){
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll(){
            try
            {
                 var Cat = _context.Categories.ToList();
                 return Ok(Cat);
            }
            catch 
            {
                
                return BadRequest();
            }
           
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(CatModel catModel){
           try
           {
                var categories = new Category
                {
                    NameCat = catModel.NameCat
                };
                _context.Add(categories);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, categories);
           }
           catch
           {
            
            return BadRequest();
           } 
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var cat = _context.Categories.SingleOrDefault(c=>c.IdCat == id);
            if (cat ==null)
            {
                return NotFound();
            }else{
                return Ok(cat);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCatById(int id, CatModel catModel){
            var cat = _context.Categories.SingleOrDefault(c=>c.IdCat==id);
            if (cat == null)
            {
                return NotFound();
            }else{
                cat.NameCat = catModel.NameCat;
                _context.SaveChanges();
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            var cat= _context.Categories.SingleOrDefault(c=>c.IdCat==id);
            if (cat == null)
            {
                return NotFound();
            }else
            {
                 _context.Remove(cat);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
        }
    }
}
