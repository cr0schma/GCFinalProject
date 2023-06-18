using GrandClickr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        private List<UserName> GetUserNamesTest()
        {
            List<UserName> users = new List<UserName>();
            foreach (UserName user in _context.UserNames)
            {
                users.Add(user);
            }

            

            return users;
        }

        private List<Secret> GetSecret()
        {
            List<Secret> secrets = new List<Secret>();
            foreach (Secret secret in _context.Secrets)
            {
                secrets.Add(secret);
            }

            return secrets;
        }

        // GET: api/<GrandClickrDbController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserName>>> GetUserNames()
        {
            return await _context.UserNames.ToListAsync();

            
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
