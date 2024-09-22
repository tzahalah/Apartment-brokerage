
using Apartment_brokerage.Core.DTO;
using Apartment_brokerage.Core.Services;
using Apartment_brokerage.Entities;
using Apartment_brokerage.Models;
using Apartment_brokerage.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apartment_brokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsService apartmentsService;
        private readonly IMapper mapper;
        public ApartmentsController(IApartmentsService _apartmentsService, IMapper _mapper)
        {
            this.apartmentsService = _apartmentsService ;
            this.mapper = _mapper ;
        }



        // GET: api/<ApartmentsController>
        [HttpGet]
        public async Task<ActionResult<ApartmentDto>> Get()
        {
            var a= await apartmentsService.Get();
            if (a != null ) {
           var adto = mapper.Map<List<ApartmentDto>>(a); 
            return Ok(adto);}
            return BadRequest();
        }

        // GET api/<ApartmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentDto>> Get(int Code)
        {
            var a = await apartmentsService.Get(Code);
            var adto= mapper.Map<ApartmentDto>(a);
             return Ok(adto);
        }

        // POST api/<ApartmentsController>
        [HttpPost]
        public async Task< ActionResult<ApartmentDto>> Post( [FromBody] ApartmentPostModel a)
        {
            var na=new Apartments { Rooms= a.Rooms ,Meters=a.Meters,City=a.City,Street=a.Street,Num=a.Num,SellersId=a.SellersId};
            na= await apartmentsService.PostAsync(na);
           var adto= mapper.Map<ApartmentDto>(na);
            return Ok(adto);
        }

        // PUT api/<ApartmentsController>/5
        [HttpPut("{id}")]
        public async  Task<ActionResult<ApartmentDto>> Put(int code, [FromBody] ApartmentPostModel a)
        {
            var na = new Apartments { Rooms = a.Rooms, Meters = a.Meters, City = a.City, Street = a.Street, Num = a.Num, SellersId=a.SellersId };
            try
            {
                na = await apartmentsService.PutAsync(code, na);
                var adto = mapper.Map<ApartmentDto>(na);
                return Ok(adto);
            }catch(Exception e) { throw new Exception("קוד לא קיים"); }

        }

        // DELETE api/<ApartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApartmentDto>> Delete(int id)
        {
            var a= await apartmentsService.DeleteAsync(id);
            var adto = mapper.Map<ApartmentDto>(a);
            return Ok(adto);
        }
    }
}
