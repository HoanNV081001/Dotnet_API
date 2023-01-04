using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_API.Models;
using Dotnet_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICatRepository _ICatRepository;

        public CategorysController(ICatRepository ICatRepository){
            _ICatRepository = ICatRepository;
        }
         [HttpGet]
        public IActionResult GetAll(){
            try
            {
                return Ok(_ICatRepository.GetAll());
            }
            catch 
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }
        [HttpPost]
        public IActionResult Add(CatModel catModel){
            try
            {
                return Ok(_ICatRepository.Add(catModel));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            } 
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            try
            {
                var data = _ICatRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }else
                {
                    return NotFound();
                }
            }
            catch 
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CatVM catVM){

            if (id != catVM.IdCat)
            {
                return BadRequest();
            }
            try
            {
                _ICatRepository.Update(catVM);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try
            {
                _ICatRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
