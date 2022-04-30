using AutoMapper;
using TransaksiBelanja.Data;
using TransaksiBelanja.Models;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using TransaksiBelanja.AsyncDataService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaksiBelanja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShopping _shopping;
        private readonly IMapper _mapper;
        private readonly IMessageAsyncClient _messageAsyncCLient;

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

        [HttpPost]
        public async Task<ActionResult<Shopping>> CreateShopping(ShoppingPublishDto shoppingPublishDto)
        {
            var newShopping = _mapper.Map<Shopping>(shoppingPublishDto);
            _shopping.CreateShopping(newShopping);
            _shopping.SaveChanges();

            var shoppingReadDto = _mapper.Map<Shopping>(newShopping);

            /*try
            {
                //sync message
               await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"-->Tidak dapat mengirimkan Sync Data: {ex.Message}");
            }*/

            //Kirim async
            try
            {
                var shoppingDto = _mapper.Map<ShoppingPublishDto>(shoppingReadDto);
                shoppingDto.Event = "Shopping_Publish";
                _messageAsyncCLient.PublishNewShopping(shoppingDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Tidak dapat mengirimkan asynd message {ex.Message}");
            }

            //return CreatedAtAction(nameof(GetPlatformById),new { Id=platformReadDto.Id }, platformReadDto);
            return Ok(shoppingPublishDto);
        }
    }
}
