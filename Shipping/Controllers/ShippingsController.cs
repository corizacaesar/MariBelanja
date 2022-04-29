using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.Data;
using Shipping.DTO;
using Shipping.Models;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly IShipping _shipping;
        private readonly IMapper _mapper;

       public ShippingsController(IShipping shipping, IMapper mapper)
       {
           _shipping = shipping;
           _mapper = mapper;
       }

       // GET: api/<ShippingsController>
        [HttpGet]
        public async Task<IEnumerable<ShippingDTO>> Get()
        {
            var result = await _shipping.GetAll();
            var output = _mapper.Map<IEnumerable<ShippingDTO>>(result);
            return output;
        }

        // GET api/<ShippingsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingDTO>> Get(int id)
        {
            var result = await _shipping.GetById(id);
            if (result == null)
                return NotFound();
            else
                return Ok(_mapper.Map<ShippingDTO>(result));
        }

        // POST api/<ProduksController>
        [HttpPost]
        public async Task<ActionResult<ShippingDTO>> Post(ShippingDTO value)
        {
            try
            {
                var newShipping = _mapper.Map<Ship>(value);
                var result = await _shipping.Insert(newShipping);
                var shippingDTO = _mapper.Map<ShippingDTO>(result);
                return shippingDTO;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProduksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ShippingDTO shippingDTO)
        {
            try
            {
                var updateShipping = _mapper.Map<Ship>(shippingDTO);
                var result = await _shipping.Update(id, updateShipping);
                var output = _mapper.Map<ShippingDTO>(result); 
                return Ok(output);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProduksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _shipping.Delete(id);
                return Ok($"Id {id} berhasil di delete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}