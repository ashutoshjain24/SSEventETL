using System;
using System.Collections.Generic;
using System.Text;

namespace SSEventsETL.DomainModel
{
    public class DashboardDetails
    {
        public int? ID { get; set; }
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }
        public string DashboardName { get; set; }
        public string SourceGlobalTemplateID { get; set; }
        public string SourceObjectID { get; set; }
        public string SourceType { get; set; }
        public string AccessibleBy { get; set; }
        public string PublishType { get; set; }
        public string PublishFormat { get; set; }
        public string AccessLevel { get; set; }
        public string UserID { get; set; }
        public string GroupID { get; set; }
        public string WorkspaceID { get; set; }
        public string OldUserID { get; set; }
        public string OldAccessLevel { get; set; }
        public string NewUserID { get; set; }
        public string NewAccessLevel { get; set; }
        public string NewparentContainerID { get; set; }
        public string ParentContainerID { get; set; }
        public string FolderName { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public DateTime? AudtInstTS { get; set; }
        public DateTime? AudtUpdtTS { get; set; }
        public string UserIDInitiator { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string RequestUserID { get; set; }
        public string Source { get; set; }
    }
}
