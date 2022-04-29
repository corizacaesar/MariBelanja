using AutoMapper;
using KatalogProduk.Data;
using KatalogProduk.DTO;
using KatalogProduk.Models;
using KatalogProduk.SyncDataServices.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KatalogProduk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduksController : ControllerBase
    {
        private readonly IProduk _produk;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public ProduksController(IProduk produk, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _produk = produk;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }
        // GET: api/<ProduksController>
        [HttpGet]
        public async Task<IEnumerable<ProdukDTO>> Get()
        {
            var result = await _produk.GetAll();
            var output = _mapper.Map<IEnumerable<ProdukDTO>>(result);
            return output;
        }

        // GET api/<ProduksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdukDTO>> Get(int id)
        {
            var result = await _produk.GetById(id);
            if (result == null)
                return NotFound();
            else
                return Ok(_mapper.Map<ProdukDTO>(result));
        }

        // POST api/<ProduksController>
        [HttpPost]
        public async Task<ActionResult<ProdukDTO>> Post(ProdukDTO value)
        {
            try
            {
                var newProduk = _mapper.Map<Produk>(value);
                var result = await _produk.Insert(newProduk);
                var produkDTO = _mapper.Map<ProdukDTO>(result);
                return produkDTO;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            try
            {

                _commandDataClient.SendProdukToTransaksiBelanja(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal{ex.Message}");
            }
        }

        // PUT api/<ProduksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProdukDTO produkDTO)
        {
            try
            {
                var updateProduk = _mapper.Map<Produk>(produkDTO);
                var result = await _produk.Update(id, updateProduk);
                var output = _mapper.Map<ProdukDTO>(result); 
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
                await _produk.Delete(id);
                return Ok($"Id {id} berhasil di delete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
