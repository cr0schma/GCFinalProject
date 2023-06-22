using Azure.Storage.Blobs.Models;
using GrandClickr.Models;
using GrandClickr.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrandClickr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzStorageController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly AzBlobService _azBlobService;
       
        public AzStorageController(IConfiguration configuration, AzBlobService azBlobService)
        {
            _configuration = configuration;
            SAStoken = _configuration["ConnectionStrings:SAStoken"];
            _azBlobService = azBlobService;
        }

        // Variables
        string SAStoken;

        // Endpoints
        [HttpGet("GetImages")]
        public async Task<List<AzStorage>> GetImages(string userContainer)
        {
            var container = _azBlobService.GetContainer(SAStoken, userContainer.ToLower());
            List<AzStorage> blobs = new();

            await foreach (BlobItem blobItem in container.GetBlobsAsync())
            {
                AzStorage blob = new();
                blob.BlobURL = $"{container.Uri}/{blobItem.Name}";
                blob.Tags = container.GetBlobClient(blobItem.Name).GetTags().Value.Tags.Values.ToList();
                blob.imageName = blobItem.Name;
                blobs.Add(blob);
            }

            return blobs;
        }
        
        [HttpGet("GetImagesByTag")]
        public async Task<List<AzStorage>> GetImagesByTag(string userContainer, string tag)
        {
            var container = _azBlobService.GetContainer(SAStoken, userContainer.ToLower());
            List<AzStorage> blobs = new();
            string query = $"genre = '{tag.ToLower()}'";
            foreach (TaggedBlobItem blobItem in container.FindBlobsByTags(query))
            {
                AzStorage blob = new();
                blob.BlobURL = $"{container.Uri}/{blobItem.BlobName}";
                blob.Tags = container.GetBlobClient(blobItem.BlobName).GetTags().Value.Tags.Values.ToList();
                blob.imageName = blobItem.BlobName;
                blobs.Add(blob);
            }

            return blobs;
        }

        [HttpPost("AddImage")]
        public async Task<bool> AddImage(IFormFile image, string userContainer, string? tag = null)
        {
            Stream stream = image.OpenReadStream();
            var container = _azBlobService.GetContainer(SAStoken, userContainer.ToLower());
            string imageName = image.FileName.ToLower();
            await container.UploadBlobAsync(imageName, stream);
            
            // Add tag if provided
            if (tag != null)
            {
                Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "genre", tag.ToLower() }
            };
                container.GetBlobClient(imageName).SetTags(tags);
            }
            return true;
        }

        [HttpPut("AddTag")]
        public async Task AddTag(string userContainer, string fileName, string tag)
        {
            var container = _azBlobService.GetContainer(SAStoken, userContainer.ToLower());
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "genre", tag.ToLower() }
            };
            await container.GetBlobClient(fileName.ToLower()).SetTagsAsync(tags);
        }
        
        [HttpDelete("DeleteImage")]
        public async Task<IActionResult> DeleteImage(string userContainer, string fileName)
        {
            var container = _azBlobService.GetContainer(SAStoken, userContainer.ToLower());
            var blobClient = container.GetBlobClient(fileName.ToLower());
            
            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
