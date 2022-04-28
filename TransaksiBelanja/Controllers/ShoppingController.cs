using AutoMapper;
using Data.Dtos.Shopping;
using Data.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaksiBelanja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShopping _shopping;
        private readonly IMapper _mapper;

        public ShoppingController(IShopping shopping, IMapper mapper)
        {
            _shopping = shopping;
            _mapper = mapper;
        }
        // GET: api/<ShoppingController>
        [HttpGet]
        public async Task<IEnumerable<ShoppingViewDto>> GetAllAsync()
        {
            var results = await _shopping.GetAll();
            var output = _mapper.Map<IEnumerable<ShoppingViewDto>>(results);
            return output;
        }

        // GET api/<ShoppingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingViewDto>> GetById(int id)
        {
            var result = await _shopping.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ShoppingViewDto>(result));
        }

        // POST api/<ShoppingController>
        [HttpPost]
        public async Task<ActionResult> Post(ShoppingCreateDto shoppingCreateDto)
        {
            try
            {
                var newShopper = _mapper.Map<Shopping>(shoppingCreateDto);
                var result = await _shopping.Insert(newShopper);
                var shoppingDto = _mapper.Map<ShoppingViewDto>(result);

                return CreatedAtAction("GetById", new { id = result.Id }, shoppingDto); 

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ShoppingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ShoppingCreateDto shoppingCreateDto)
        {
            try
            {
                var updateShopping = _mapper.Map<Shopping>(shoppingCreateDto);
                var result = await _shopping.Update(id, updateShopping);
                var swordDTO = _mapper.Map<ShoppingViewDto>(result);
                return Ok(swordDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ShoppingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _shopping.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
