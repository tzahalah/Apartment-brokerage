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
        private readonly DataContext context;
        public CustomersController(DataContext context1)
        {
            context = context1;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return context.Customers;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customers> Get(String id)
        {
            var code = context.Customers.FindIndex(x => x.Id ==id);
            if (code == -1)
                return NotFound();
            return context.Customers[code];
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customers c)
        {
            context.countC++;
            context.Customers.Add(c);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customers c)
        {
            var code = context.Customers.FindIndex(x => x.Id == c.Id);
            if (code == -1)
                return NotFound();
            context.Customers[code].Lname = c.Lname;
            context.Customers[code].Fname = c.Fname;
            context.Customers[code].Phone = c.Phone;
            return Ok();

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            context.countC--;
            var c = context.Customers.Find(x => x.Id == id);
            context.Customers.Remove(c);
        }
    }
}
