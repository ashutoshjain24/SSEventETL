using System;
using System.Collections.Generic;
using System.Text;


namespace SSEventsETL.DomainModel
{
    public class WorkSpaceDetails
    {
        public int? ID { get; set; }
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public string AccessLevel { get; set; }
        public string UserID { get; set; }
        public string GroupID { get; set; }
        public bool? IncludeAttachments { get; set; }
        public bool? SendCompletionEmail { get; set; }
        public string FormatType { get; set; }
        public DateTime? AudtInstTS { get; set; }
        public DateTime? AudtUpdtTS { get; set; }
        public string UserIDInitiator { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string RequestUserID { get; set; }
        public string Source { get; set; }
    }
}
