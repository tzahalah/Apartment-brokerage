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
        private static int count = 0;
        private static List<Sellers> Sellers = new List<Sellers> { };

        // GET: api/<sellersController>
        [HttpGet]
        public IEnumerable<Sellers> Get()
        {
            return Sellers;
        }

        // GET api/<sellersController>/5
        [HttpGet("{id}")]
        public Sellers Get(String id)
        {
            var c = Sellers.FindIndex(x => x.Id == id);
            return Sellers[c];
        }

        // POST api/<sellersController>
        [HttpPost]
        public void Post([FromBody]  Sellers s)
        {
            count++;
            Sellers.Add(s);
        }

        // PUT api/<sellersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Sellers s)
        {
            var c = Sellers.FindIndex(x => x.Id ==s.Id );
            Sellers[c].Lname = s.Lname;
            Sellers[c].Fname = s.Fname;
            Sellers[c].Phone = s.Phone;
            Sellers[c].CodeApartment = s.CodeApartment;
        }

        // DELETE api/<sellersController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            count--;
            var s = Sellers.Find(x => x.Id == id);
            var codeApartment = s.CodeApartment;
            //TODO  להוריד את כמות הדירות ולמחוק מהרשימה של הדירות את הדירה הנ"ל
            Sellers.Remove(s);
        }
    }
}
