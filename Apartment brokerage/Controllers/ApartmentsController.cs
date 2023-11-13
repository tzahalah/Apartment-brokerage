using Apartment_brokerage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apartment_brokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly DataContext context;
        public ApartmentsController(DataContext context1)
        {
            context = context1;
        }



        // GET: api/<ApartmentsController>
        [HttpGet]
        public IEnumerable<Apartments> Get()
        {
            return context.Apartments;
        }

        // GET api/<ApartmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Apartments> Get(int Code)
        {
            var c = context.Apartments.FindIndex(x => x.Code == Code);
            if (c ==-1)
                return NotFound();
            return context.Apartments[c];
        }

        // POST api/<ApartmentsController>
        [HttpPost]
        public void Post([FromBody] Apartments a)
        {

            context.Apartments.Add(new Apartments { Code = context.countA++, Rooms = a.Rooms, Meters = a.Meters, City = a.City, Street = a.Street, Num = a.Num }) ;
        }

        // PUT api/<ApartmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int Code, [FromBody] Apartments a)
        {
            var c = context.Apartments.FindIndex(x => x.Code == Code);
            if (c == -1)
                return NotFound();
            context.Apartments[c].Rooms = a.Rooms;
            context.Apartments[c].Meters = a.Meters;
            context.Apartments[c].City = a.City;
            context.Apartments[c].Street = a.Street;
            context.Apartments[c].Num = a.Num;
            return Ok();
        }

        // DELETE api/<ApartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.countA--;    
            var a = context.Apartments.Find(x => x.Code == id);
            context.Apartments.Remove(a);
        }
    }
}
