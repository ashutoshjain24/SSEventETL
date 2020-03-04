using System;
using System.Collections.Generic;
using System.Text;


namespace SSEventsETL.DomainModel
{

    public class AdditionalDetails
    {
        //DateTime _tokenExpirationTimestamp;
        //DateTime _eventTimeStamp;
        public string EventID { get; set; }
        public string ObjectID { get; set; }
        public string ObjectType { get; set; }
        public string Action { get; set; }
        public string TokenName { get; set; }
        public string TokenDisplayValue { get; set; }
        //  public DateTime TokenExpirationTimestamp { get; set; }
        public string AccessScopes { get; set; }
        public string AppClientID { get; set; }
        public string AppName { get; set; }
        public string TokenUserID { get; set; }
        public string NewContactUserID { get; set; }
        public string OldContactUserID { get; set; }
        public string NewName { get; set; }
        public string OldName { get; set; }
        public string SheetID { get; set; }
        public string WorkSpaceID { get; set; }
        public string AttachmentName { get; set; }
        public string MultifileDownloadName { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientGroupID { get; set; }
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
        public string OldUserID { get; set; }
        public string OldAccessLevel { get; set; }
        public string NewUserID { get; set; }
        public string NewAccessLevel { get; set; }
        public string NewParentContainerID { get; set; }
        public string ParentContainerID { get; set; }
        public string FolderName { get; set; }
        public string SheetRowID { get; set; }
        public bool? IncludeAttachments { get; set; }
        public string SourceFolderID { get; set; }
        public bool? SendCompletionEmail { get; set; }
        public string FormatType { get; set; }
        public string FormName { get; set; }
        public string GroupName { get; set; }
        public string OldOwnerUserID { get; set; }
        public string NewOwnerUserID { get; set; }
        public string MemberUserID { get; set; }
        public string SourceTemplateID { get; set; }
        public string Source { get; set; }
        public string SheetName { get; set; }
        public int? RowCount { get; set; }
        public bool? IncludeDiscussions { get; set; }
        public string SourceSheetID { get; set; }
        public string DestinationSheetID { get; set; }
        public int? RowsMoved { get; set; }
        public int? RowsCopied { get; set; }
        public string CellLinkSourceSheetID { get; set; }
        public string CelllinkSourceSheetID { get; set; }
        public string RequestUserID { get; set; }
        public string ReportName { get; set; }
        public string UserTypes { get; set; }
        public string EmailAddress { get; set; }
        public string DeclineReason { get; set; }

        //[Computed]
        //public DateTime? AudtInstTS { get; set; }
        //[Computed]
        //public DateTime? AudtUpdtTS { get; set; }
        public DateTime? TokenExpirationTimestamp { get; set; }
        public DateTime? EventTimeStamp { get; set; }
        public string UserIDImpacted { get; set; }
    }
}
