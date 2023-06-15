using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrandClickr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzStorageController : ControllerBase
    {
        private IConfiguration Configuration;
       
        public AzStorageController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET: api/<AzStorageController>
        [HttpGet]
        public async Task<IActionResult> GetAsync(string container, string image)
        {
            var SAStoken = Configuration["ConnectionStrings:SAStoken"];
            string path = $"https://stgcdotnetah2023grp3.blob.core.windows.net/{container}/{image}.jpg?{SAStoken}";
            
            // Download the private blob
            var blob = new BlobClient(new Uri(path)).DownloadStreamingAsync();

            return File(blob.Result.Value.Content, "image/jpeg");
        }

        // GET api/<AzStorageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AzStorageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AzStorageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AzStorageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
