using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using TransaksiBelanja.Data;
using TransaksiBelanja.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaksiBelanja.Controllers
{
    [Route("api/p/[controller]")]
    [ApiController]
    public class ProduksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduct _product;

        public ProduksController(IMapper mapper, IProduct context)
        {
            _mapper = mapper;
            _product = context;

        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            //Console.WriteLine(value);
            Console.WriteLine("--> Inbound POST KatalogProduk");
            return Ok("Inbound test dari ProdukController");
        }

        // POST api/<ProduksController>
        //[HttpPost]
        //public async Task<ActionResult<ProductCreateDto>> Post(ProductCreateDto request)
        //{
        //    if (request != null)
        //        Console.WriteLine("---> Data Diterima");
        //    else
        //        Console.WriteLine("Data null");
        //    var newProduct = _mapper.Map<Product>(request);
        //    var result = await _product.Insert(newProduct);
        //    var productCreateDTO = _mapper.Map<ProductCreateDto>(result);
        //    Console.WriteLine("---> Data Disimpan");
        //    return productCreateDTO;

        //}

        // GET: api/<ProduksController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var result = await _product.GetAll();
            var output = _mapper.Map<IEnumerable<Product>>(result);
            return output;
        }

        //// GET api/<ProduksController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProduksController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProduksController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProduksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
