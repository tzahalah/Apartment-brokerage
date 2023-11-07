using Apartment_brokerage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apartment_brokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static int count = 0;
        private static List<Customers> Customers = new List<Customers> { };

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return Customers;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customers Get(String id)
        {
            var code = Customers.FindIndex(x => x.Id ==id);
            return Customers[code];
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customers c)
        {
            count++;
            Customers.Add(c);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customers c)
        {
            var code = Customers.FindIndex(x => x.Id == c.Id);
            Customers[code].Lname = c.Lname;
            Customers[code].Fname = c.Fname;
            Customers[code].Phone = c.Phone;

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            count--;
            var c = Customers.Find(x => x.Id == id);
            Customers.Remove(c);
        }
    }
}
