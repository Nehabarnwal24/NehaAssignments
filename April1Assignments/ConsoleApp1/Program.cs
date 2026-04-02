using Azure.Storage.Blobs;

namespace ConsoleApp1
{
    internal class Program
    {
        static string str_connection = "DefaultEndpointsProtocol=https;AccountName=nehastoragecg;AccountKey=w9iJidbSSTD2UPvCR5QnIMA0XJ0tYSZaXhmbhHLEltTy2Yww5lPmcRJQiQEvSHp7hbZXqgq/hrB++ASths4arg==;EndpointSuffix=core.windows.net";// this value i had kept empty u have to take it from azure access keys and add it and in github u cant put sececet 
        // connection like this becasue when u try to commit it tells secret information is there so for security reasong i cannot do commit so removed

        static async Task Main()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(str_connection);
            BlobContainerClient container_client =
            blobServiceClient.GetBlobContainerClient("data");
            BlobClient blob_client = container_client.GetBlobClient("myFile.txt");
            using FileStream uploadFileStream = File.OpenRead(@"C:\Users\91979\OneDrive\Desktop\Text files\myFile.txt");
            await blob_client.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            Console.WriteLine("File uploaded");
            Console.WriteLine("Operation complete");
        }
    }
}