using System;
using System.Collections.Generic;
using System.Text;


namespace SSEventsETL.DomainModel
{
    public class UserDetails
    {
        public int? ID { get; set; }
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }
        public string UserTypes { get; set; }
        public string EmailAddress { get; set; }
        public string DeclineReason { get; set; }
        public string OldownerUserID { get; set; }
        public string NewownerUserID { get; set; }
        public DateTime? AudtInstTS { get; set; }
        public DateTime? AudtUpdtTS { get; set; }
        public string UserIDInitiator { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string RequestUserID { get; set; }
        public string Source { get; set; }
    }
}
