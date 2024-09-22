using Apartment_brokerage.Core.DTO;
using Apartment_brokerage.Core.Services;
using Apartment_brokerage.Entities;
using Apartment_brokerage.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apartment_brokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly IMapper mapper;
        public CustomersController(ICustomersService _customersService, IMapper _mapper)
        {
            customersService= _customersService;
            mapper= _mapper;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> Get()
        {
            var cl= await customersService.Get();
            var cdto= mapper.Map<List<CustomerDto>>(cl);
            return Ok(cdto);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var c = await customersService.Get(id);
             var cdto=mapper.Map<CustomerDto>(c);
            return Ok( cdto);
        }

        // POST api/<CustomersController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CustomerDto>> Post([FromBody] CustomerPostModel c)
        {
            var nc=new Customers {Identity= c.Identity,Fname=c.Fname,Lname=c.Lname,Phone=c.Phone};
            nc= await  customersService.PostAsync(nc);
            var cdto= mapper.Map<CustomerDto>(nc);
            return Ok( cdto);

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Put(int id, [FromBody] CustomerPostModel c)
        {
            var nc = new Customers { Identity = c.Identity, Fname = c.Fname, Lname = c.Lname, Phone = c.Phone };
             nc=await customersService.PutAsync( id, nc);
             var cdto = mapper.Map<CustomerDto>(nc);
             return Ok(cdto);

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDto>> Delete(int id)
        {
          var c= await customersService.DeleteAsync( id);
          var cdto = mapper.Map<CustomerDto>(c);
            return Ok( cdto);
        }
    }
}
