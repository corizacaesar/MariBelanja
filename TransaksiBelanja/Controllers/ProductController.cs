using AutoMapper;
using Data;
using Data.Dtos.Product;
using Data.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaksiBelanja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IMapper _mapper;

        public ProductController(IProduct product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductViewDto>> GetAll()
        {
            var results = await _product.GetAll();
            var output = _mapper.Map<IEnumerable<ProductViewDto>>(results);
            return output;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewDto>> GetById(int id)
        {
            var result = await _product.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ProductViewDto>(result));
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<ProductViewDto>> GetByName(string name)
        {
            var result = await _product.GetByName(name);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<ProductViewDto>>(result));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post(ProductCreateDto productCreateDto)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(productCreateDto);
                var result = await _product.Insert(newProduct);
                var prodcutDto = _mapper.Map<ProductViewDto>(result);

                return CreatedAtAction("GetById", new { id = result.Id }, prodcutDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProductCreateDto productCreateDto)
        {
            try
            {
                var updateSword = _mapper.Map<Product>(productCreateDto);
                var result = await _product.Update(id, updateSword);
                var swordDTO = _mapper.Map<ProductViewDto>(result);
                return Ok(swordDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _product.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
