using GrandClickr.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrandClickr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrandClickrDbController : ControllerBase
    {
        private readonly GrandClickrContext _context;

        public GrandClickrDbController(GrandClickrContext context)
        {
            _context = context;
        }

        // GET: api/<GrandClickrDbController>
        [HttpGet]
        public bool GetUserName(string userName, string password)
        {
            return true;
        }

        // GET api/<GrandClickrDbController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GrandClickrDbController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GrandClickrDbController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GrandClickrDbController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
