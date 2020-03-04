using System;
using SSEventsETL.Helpers;
using Newtonsoft.Json;
using SSEventsETL.DomainModel;

namespace SSEventsETL.EventsProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString();

            var inputStream = DatabaseHelper.GetFromTheDatabase(ConnString);

            var payLoad = JsonConvert.DeserializeObject<PayLoad>(inputStream.Response);

            var superEventDetails = ObjectHelper.CreateObject(payLoad);

            // TODO: Add lookup for database connection string.
            var tablemap = DatabaseHelper.GetTableMappingFromDatabase(ConnString);

            DatabaseHelper.BulkInsertEventInToDatabse(superEventDetails, tablemap, ConnString);
        }
    }
}
