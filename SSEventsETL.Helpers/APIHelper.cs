using System;
using SSEventsETL.DomainModel;
using SSEventsETL.Utility;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using SSEventsETL.Enumerations;




namespace SSEventsETL.Helpers
{
    public static class APIHelper
    {
        public static CallLog CallTheAPI(string apiURL)
        {
            
            CallLog callLog = new CallLog();

            //log.Info("Execution Started");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ConfigurationManager.AppSettings["Bearer"], ConfigurationManager.AppSettings["AuthKey"]);
                //log.Info("Autorized");
                callLog.StartTime = DateTime.Now;
                HttpResponseMessage httpresponse = new HttpResponseMessage();
                try
                {
                    using (httpresponse = client.GetAsync(new Uri(apiURL)).Result)
                    {
                        callLog.ResponseCode = httpresponse.StatusCode.ToString();
                        // callLog.RequestHeader = client.DefaultRequestHeaders.ToString();
                        callLog.Request = httpresponse.RequestMessage.ToString();
                        callLog.EndTime = DateTime.Now;
                        callLog.Response = httpresponse.Content.ReadAsStringAsync().Result;
                        callLog.ResponseHeader = httpresponse.Headers.ToString();
                        if (httpresponse.IsSuccessStatusCode)
                        {
                            callLog.PayLoad = JsonConvert.DeserializeObject<PayLoad>(callLog.Response);
                            callLog.IsCallSuccess = true;
                        }
                        else
                        {
                            callLog.IsCallSuccess = false;
                        }
                        //To raise the HttpException in case of bad response
                        httpresponse.EnsureSuccessStatusCode();

                    };
                }
                catch (HttpRequestException)
                {
                    callLog.IsCallSuccess = false;

                }
                catch (Exception)
                {
                    callLog.IsCallSuccess = false;

                }
                //log.Info("Get response");

                return callLog;
                //log.Info("Response received");

            }

        }

        public static string GenerateTheAPIURL(Enums.ObjectType objectType)
        {
            string apiURL = "";
            switch (objectType)
            {
                case Enums.ObjectType.Events:
                    apiURL = CreateEventsAPIURL();
                    break;
                case Enums.ObjectType.Users:
                    apiURL = CreateMasterDataAPIURL(Enums.ObjectType.Users);
                    break;
                case Enums.ObjectType.Sheets:
                    apiURL = CreateMasterDataAPIURL(Enums.ObjectType.Sheets);
                    break;
                case Enums.ObjectType.Reports:
                    apiURL = CreateMasterDataAPIURL(Enums.ObjectType.Reports);
                    break;
                case Enums.ObjectType.Sights:
                    apiURL = CreateMasterDataAPIURL(Enums.ObjectType.Sights);
                    break;
                case Enums.ObjectType.WorkSpaces:
                    apiURL = CreateMasterDataAPIURL(Enums.ObjectType.WorkSpaces);
                    break;
                case Enums.ObjectType.Groups:
                    apiURL = CreateMasterDataAPIURL(Enums.ObjectType.Groups);
                    break;
            }
            return apiURL;

        }

        private static string CreateEventsAPIURL()
        {
            string nextStreamPostionFromDB = "";
            string sinceValueFromDB = "";
            string apiURL = "";

            nextStreamPostionFromDB = DatabaseHelper.GetConfigurationFromDB("NextStreamPosition");
            sinceValueFromDB = DatabaseHelper.GetConfigurationFromDB("Since"); 

            if (string.Equals(nextStreamPostionFromDB, "0",new StringComparison{}) || string.IsNullOrEmpty(nextStreamPostionFromDB))
            {
                apiURL = Convert.ToString(ConfigurationManager.AppSettings["ServiceUrl"]) + "since=" + sinceValueFromDB;
            }
            else
            {
                apiURL = Convert.ToString(ConfigurationManager.AppSettings["ServiceUrl"]) + "streamPosition=" + nextStreamPostionFromDB;
            }
            return apiURL;
        }

        private static string CreateMasterDataAPIURL(Enums.ObjectType objectType)
        {
            string apiURL = "";
            try
            {
               
            }
            catch (Exception ex)
            { 
            }
            return apiURL;
        }


    }
}
