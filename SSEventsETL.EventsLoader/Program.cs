using SSEventsETL.DomainModel;
using SSEventsETL.Helpers;
using SSEventsETL.Enumerations;
using System.Threading.Tasks;

namespace SSEventsETL.EventsLoader
{
    class Program
    {
        static async Task Main(string[] args)
        {

            CallLog callLog = new CallLog();
            while (callLog.PayLoad.MoreAvailable)
            {
                var apiURL = APIHelper.GenerateTheAPIURL(Enums.ObjectType.Events);
                //setting the flag back to false
                callLog.IsCallSuccess = false;

                while (!callLog.IsCallSuccess)
                    callLog = APIHelper.CallTheAPI(apiURL);
                // get the DB PK ID of the row just inserted
                var dbid = DatabaseHelper.InsertCallLogInToDatabse(callLog);

                // convert response data into ojbect using database Key for new record created above
                var PL = Newtonsoft.Json.JsonConvert.DeserializeObject<PayLoad>(callLog.Response);
                // build AzureStorageHelper MessagePayload with Datbase ID
                AzureStorageHelper.AzureConfigSettings azureconfig = new AzureStorageHelper.AzureConfigSettings()
                {
                    storageConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString(),
                    blobcontainer = System.Configuration.ConfigurationManager.AppSettings["AzureContainerName"].ToString(),
                    queuename = System.Configuration.ConfigurationManager.AppSettings["AzureQueueName"].ToString()
                };
                var data = new AzureStorageHelper.Response() { ID = (int)dbid, RESPONSE = callLog.Response };
                await AzureStorageHelper.PostMessageToQueueAsync(azureconfig, data);

            }

        }
    }
}
