using Apartment_brokerage.Entities;
using Apartment_brokerage.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apartment_brokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sellersController : ControllerBase
    {
        private readonly DataContext context;
        public sellersController(DataContext context1)
        {
            context = context1;
        }

        // GET: api/<sellersController>
        [HttpGet]
        public IEnumerable<Sellers> Get()
        {
            return context.Sellers;
        }

        // GET api/<sellersController>/5
        [HttpGet("{id}")]
        public ActionResult<Sellers> Get(String id)
        {
            var c = context.Sellers.FindIndex(x => x.Id == id);
            if (c == -1)
                return NotFound();
            return context.Sellers[c]; 
        }

        // POST api/<sellersController>
        [HttpPost]
        public void Post([FromBody]  Sellers s)
        {
            context.countS++;
            context.Sellers.Add(s);
        }

        // PUT api/<sellersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Sellers s)
        {
            var c = context.Sellers.FindIndex(x => x.Id ==s.Id );
            if (c == -1)
                return NotFound();
            context.Sellers[c].Lname = s.Lname;
            context.Sellers[c].Fname = s.Fname;
            context.Sellers[c].Phone = s.Phone;
            context.Sellers[c].CodeApartment = s.CodeApartment;
            return Ok();
        }

        // DELETE api/<sellersController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            context.countS--;
            var s = context.Sellers.Find(x => x.Id == id);
            var codeApartment = s.CodeApartment;
            //TODO  להוריד את כמות הדירות ולמחוק מהרשימה של הדירות את הדירה הנ"ל
            context.Sellers.Remove(s);
        }
    }
}
