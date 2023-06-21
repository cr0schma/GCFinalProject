using GrandClickr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

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
        [Route("Login")]
        public bool UserLoginValidation(string userName, string password)
        {
            int userId = 0;
            foreach (var secret in _context.Secrets)
            {
                if (secret.Password == password)
                {
                    userId = secret.UserId;
                }

                foreach (var user in _context.UserNames)
                {
                    if (user.Id == userId)
                    {
                        if (user.UserName1 == userName)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
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
