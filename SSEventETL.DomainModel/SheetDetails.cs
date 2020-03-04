using System;

namespace SSEventsETL.DomainModel
{
    public class SheetDetails 
    {
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string Action { get; set; }
        public string SourceObjectID { get; set; }
        public string SourceGlobaltemplateID { get; set; }
        public string SourcetemplateID { get; set; }
        public string Source { get; set; }
        public string SourceType { get; set; }
        public string SheetName { get; set; }
        public string NewName { get; set; }
        public string OldName { get; set; }
        public string AccessLevel { get; set; }
        public string UserIDInitiator { get; set; }
        public string GroupID { get; set; }
        public string WorkSpaceID { get; set; }
        public string OldUserID { get; set; }
        public string OldAccessLevel { get; set; }
        public string NewUserID { get; set; }
        public string NewAccessLevel { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientGroupID { get; set; }
        public string FormatType { get; set; }
        public int? RowCount { get; set; }
        public bool? IncludeAttachments { get; set; }
        public bool? IncludeDiscussions { get; set; }
        public string SourceSheetID { get; set; }
        public string DestinationSheetID { get; set; }
        public int? RowsMoved { get; set; }
        public int? RowsCopied { get; set; }
        public string CelllinkSourceSheetID { get; set; }
        public string NewParentContainerID { get; set; }
        public string ParentContainerID { get; set; }
        public string FolderName { get; set; }
        public string RequestUserID { get; set; }
        public bool? SendCompletionEmail { get; set; }
        public string UserIDImpacted { get; set; }
        public DateTime? EventTimestamp { get; set; }
    }
}
