using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.DTO;
using GeekShopping.ProductAPI.Exceptions;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            List<ProductDTO> product = await _repository.FindAll();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id){
            ProductDTO product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO dto){
            if (dto == null) return BadRequest();
            ProductDTO product = await _repository.Create(dto);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Put([FromBody] ProductDTO dto){
            if (dto == null) return BadRequest();
            try{
                ProductDTO product = await _repository.Update(dto);
                return Ok(product);
            }
            catch(NotFoundException e){
                return NotFound(e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            bool status = await _repository.Delete(id);
            if (status) return Ok(status);
            return NotFound();
        }
    }
}