using System;
using System.Collections.Generic;
using System.Text;
using SSEventsETL.DomainModel;
using Newtonsoft.Json;

namespace SSEventsETL.Helpers
{
   public class JsonHelperParse
    {
        public static PayLoad ParseInputStream(InputStream inpuStream)
        {
            try
            {
                return JsonConvert.DeserializeObject<PayLoad>(inpuStream.Response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
