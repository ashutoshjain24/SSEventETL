using System;
using System.Collections.Generic;
using System.Text;
using SSEventsETL.DomainModel;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SSEventsETL.Helpers
{
    /// <summary>
    /// Requires three items in configuration app.config
    /// 1) StorageConnectionString in ConnectionStrings collection defeines the azure storage connection string
    /// 2) messagequeuename in appsettings defines the message queue name in azure
    /// 3) blobcontainer in appsettings defines the blob storage container name
    /// </summary>
    public static class AzureStorageHelper
    {
        public class AzureConfigSettings
        {
            public string storageConnectionString { get; set; }
            public string queuename { get; set; }
            public string blobcontainer { get; set; }
        }
        public class MessagePayload
        {
            public int ID { get; set; }
            public string BlobGuid { get; set; }
            public string Message { get; set; }
        }

        public class Response
        {
            public int ID { get; set; }
            public string RESPONSE { get; set; }
        }

        public static async Task<PayLoad> GetJSONBlob(AzureConfigSettings settings, MessagePayload message)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(settings.storageConnectionString);
            // blob client to access Blob storage
            var blobClient = storageAccount.CreateCloudBlobClient();
            // using container name agreed upon by sender and receiver parties
            var container = blobClient.GetContainerReference(settings.blobcontainer);
            // in case container doesn’t exist, create it
            // await container.CreateIfNotExistsAsync();

            var BlobData = new PayLoad();
            try
            {
                var blobName = message.BlobGuid;
                // get reference to the blob to read the contents
                var blobReference = container.GetBlockBlobReference(blobName);
                // get the content of the Blob Object
                var content = await blobReference.DownloadTextAsync();
                //Console.WriteLine(content);

                // Parse the Content of the Blob Object into a Domain Object
                BlobData = Newtonsoft.Json.JsonConvert.DeserializeObject<PayLoad>(content);

                // last step – delete the message when the blob is successfully read
                await blobReference.DeleteAsync();

            }
            catch (Exception ex)
            {
                // LOG ERRORS

                // throw the error so the job knows we had an exception
                throw (ex);
            }

            return BlobData;
        }

        public static async Task<int> PostMessageListToQueueAsync(AzureConfigSettings settings, List<Response> data)
        {

            var processed = 0;

            foreach (var result in data)
            {
                var success = await PostMessageToQueueAsync(settings, result);
                if (success)
                {
                    processed++;
                }
            }

            return processed;

        }
        public static async Task<bool> PostMessageToQueueAsync(AzureConfigSettings settings, Response data)
        {
            try
            {
                // Parse the connection string and return a reference to the storage account.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(settings.storageConnectionString);

                // blob client to access Blob storage
                var blobClient = storageAccount.CreateCloudBlobClient();
                // using container name agreed upon by sender and receiver parties
                var container = blobClient.GetContainerReference(settings.blobcontainer);
                // in case container doesn’t exist, create it
                _ = await container.CreateIfNotExistsAsync();

                // create cloud queue client
                var client = storageAccount.CreateCloudQueueClient();
                // get a reference to a queue we’ll use to send messages to
                var queue = client.GetQueueReference(settings.queuename);
                // in case queue doesn’t exist, create it
                await queue.CreateIfNotExistsAsync();

                var pl = new MessagePayload();
                // Database ID 
                pl.ID = data.ID;

                // check the message body length, and if it is under 64KB then we can post it in the 
                // queue body instead of posting it to blob storage.

                // If the RESPONSE is > 64KB (minus some for the reset of this json) then we need to post the RESPONSE as a BLOB
                if (System.Text.ASCIIEncoding.ASCII.GetByteCount(data.RESPONSE) < 63000)
                {
                    pl.Message = data.RESPONSE;
                }
                else
                // If the RESPONSE is >- 63KB then upload the message as a blob into the provided container
                {
                    // blob name to be used to store message body
                    var blobName = Guid.NewGuid();

                    // add the blob name (generated guid) to the payload object
                    pl.BlobGuid = blobName.ToString();

                    // upload message body to Storage blob rather than send as a message to allow more than 64KB
                    var blob = container.GetBlockBlobReference(blobName.ToString());
                    await blob.UploadTextAsync(data.RESPONSE);
                }

                // convert the payload into JSON and post to message queue

                var QueueMessage = JsonConvert.SerializeObject(pl);
                var message = new CloudQueueMessage(QueueMessage);

                await queue.AddMessageAsync(message);
            }
            catch(Exception ex)
            {
                // log error
                return false;
            }

            return true;
        }
    }
}
