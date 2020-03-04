using System;
using System.Collections.Generic;
using System.Text;



namespace SSEventsETL.DomainModel
{
    public class AccessTokenDetails
    {

        public int? ID { get; set; }
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }
        public string TokenName { get; set; }
        public string TokenDisplayValue { get; set; }
        public DateTime? TokenExpirationTimestamp { get; set; }
        public string AccessScopes { get; set; }
        public string AppClientID { get; set; }
        public string AppName { get; set; }
        public string TokenUserID { get; set; }
        public DateTime? AudtInstTS { get; set; }
        public DateTime? AudtUpdtTS { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string UserIDInitiator { get; set; }
        public string Source { get; set; }
        public string RequestUserID { get; set; }
    }
}
