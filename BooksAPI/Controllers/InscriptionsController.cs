using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    public class InscriptionsController : Controller
    {
        private readonly BooksDBContext _context;
      

        public InscriptionsController(BooksDBContext context)
        {
            _context = context;
        }
        //private readonly Models.BooksDBContext _context;
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Inscription> GetInscription()
        {
          return _context.Inscription;
           // return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Inscription.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
