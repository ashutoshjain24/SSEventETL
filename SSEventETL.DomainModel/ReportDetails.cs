using System;
using System.Collections.Generic;
using System.Text;


namespace SSEventsETL.DomainModel
{
    public class ReportDetails
    {
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }       
        public string ReportName { get; set; }
        public string SourceObjectID { get; set; }
        public string SourceGlobaltemplateID { get; set; }
        public string SourceType { get; set; }
        public string NewName { get; set; }
        public string OldName { get; set; }
        public string AccessLevel { get; set; }
        public string UserID { get; set; }
        public string GroupID { get; set; }
        public string WorkSpaceID { get; set; }
        public string OldUserID { get; set; }
        public string OldAccessLevel { get; set; }
        public string NewUserID { get; set; }
        public string NewAccessLevel { get; set; }
        public string NewParentContainerID { get; set; }
        public string ParentContainerID { get; set; }
        public string FolderName { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientGroupID { get; set; }
        public string FormatType { get; set; }
        public string UserIDImpacted { get; set; }
        public string UserIDInitiator { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string RequestUserID { get; set; }    
        public string Source { get; set; }
    }
}
