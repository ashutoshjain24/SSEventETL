using System;
using System.Collections.Generic;
using System.Text;



namespace SSEventsETL.DomainModel
{
    public class AttachmentDetails
    {
        public int? ID { get; set; }
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }
        public string SheetID { get; set; }
        public string WorkSpaceID { get; set; }
        public string AttachmentName { get; set; }
        public string MultifileDownloadname { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientGroupID { get; set; }
        public DateTime? AudtInstTS { get; set; }
        public DateTime? AudtUpdtTS { get; set; }
        public string UserIDInitiator { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string RequestUserID { get; set; }
        public string Source { get; set; }
    }
}
