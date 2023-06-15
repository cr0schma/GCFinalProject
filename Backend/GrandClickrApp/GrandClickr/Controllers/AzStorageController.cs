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
            
            // Get a temporary path on disk where we can download the file
            string downloadPath = $"{image}.jpg";

            // Download the public blob at https://aka.ms/bloburl
            await new BlobClient(new Uri(path)).DownloadToAsync(downloadPath);

            Byte[] b = System.IO.File.ReadAllBytes(downloadPath);
            return File(b, "image/jpeg");
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
