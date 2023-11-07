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
        private static int count = 0;
        private static List<Apartments> Apartments = new List<Apartments> { };

       
            // GET: api/<ApartmentsController>
            [HttpGet]
        public IEnumerable<Apartments> Get()
        {
            return Apartments;
        }

        // GET api/<ApartmentsController>/5
        [HttpGet("{id}")]
        public Apartments Get(int Code)
        {
            var c = Apartments.FindIndex(x => x.Code == Code);
            return Apartments[c];
        }

        // POST api/<ApartmentsController>
        [HttpPost]
        public void Post([FromBody] Apartments a)
        {

            Apartments.Add(new Apartments { Code = count++, Rooms = a.Rooms, Meters = a.Meters, City = a.City, Street = a.Street, Num = a.Num }) ;
        }

        // PUT api/<ApartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int Code, [FromBody] Apartments a)
        {
            var c = Apartments.FindIndex(x => x.Code == Code);
            Apartments[c].Rooms = a.Rooms;
            Apartments[c].Meters = a.Meters;
            Apartments[c].City = a.City;
            Apartments[c].Street = a.Street;
            Apartments[c].Num = a.Num;
        }

        // DELETE api/<ApartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            count--;
            var a = Apartments.Find(x => x.Code == id);
            Apartments.Remove(a);
        }
    }
}
