using Azure.Storage.Blobs;

namespace GrandClickr.Services
{
    public class AzBlobService
    {
        public BlobContainerClient GetContainer(string connectionString, string containerName)
        {
            BlobServiceClient blobServiceClient = new(connectionString);
            return blobServiceClient.GetBlobContainerClient(containerName);
        }
    }
}
