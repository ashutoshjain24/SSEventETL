using SSEventsETL.DomainModel;
using System.Collections.Generic;
using System;
using System.Data;


namespace SSEventsETL.Helpers
{
    public static class ObjectHelper
    {
        public static SuperEventDetails CreateObject(PayLoad payLoad)
        {
            SuperEventDetails superEventDetail = new SuperEventDetails();
           
            foreach (Event _event in payLoad.Data)
            {
                if (_event.AdditionalDetails == null)
                {
                    _event.AdditionalDetails = new AdditionalDetails();
                }

                List<EventDetailHeader> gett = new List<EventDetailHeader>();

                var eventDetailHeader = new EventDetailHeader()
                {
                    EventID = _event.EventID,
                    NextStreamPosition = payLoad.NextStreamPosition,                   
                    EventTimeStamp = _event.EventTimestamp
                };

                superEventDetail.EventDetailHeaders.Add(eventDetailHeader);

                switch (_event.ObjectType)
                {
                    case "SHEET":
                        var sheetDetail = new SheetDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            SourceObjectID = _event.AdditionalDetails.SourceObjectID,
                            SourceGlobaltemplateID = _event.AdditionalDetails.SourceGlobalTemplateID,
                            SourcetemplateID = _event.AdditionalDetails.SourceTemplateID,
                            Source = _event.AdditionalDetails.Source,
                            SourceType = _event.AdditionalDetails.SourceType,
                            SheetName = _event.AdditionalDetails.SheetName,
                            NewName = _event.AdditionalDetails.NewName,
                            OldName = _event.AdditionalDetails.OldName,
                            AccessLevel = _event.AdditionalDetails.AccessLevel,
                            UserIDInitiator = _event.AdditionalDetails.UserID,

                            GroupID = _event.AdditionalDetails.GroupID,
                            WorkSpaceID = _event.AdditionalDetails.WorkSpaceID,
                            OldUserID = _event.AdditionalDetails.OldUserID,
                            OldAccessLevel = _event.AdditionalDetails.OldAccessLevel,
                            NewUserID = _event.AdditionalDetails.NewUserID,
                            NewAccessLevel = _event.AdditionalDetails.NewAccessLevel,
                            RecipientEmail = _event.AdditionalDetails.RecipientEmail,
                            RecipientGroupID = _event.AdditionalDetails.RecipientGroupID,
                            FormatType = _event.AdditionalDetails.FormatType,                        
                            RowCount = _event.AdditionalDetails.RowCount,
                            IncludeAttachments = _event.AdditionalDetails.IncludeAttachments,
                            IncludeDiscussions = _event.AdditionalDetails.IncludeDiscussions,
                            SourceSheetID = _event.AdditionalDetails.SourceSheetID,
                            DestinationSheetID = _event.AdditionalDetails.DestinationSheetID,
                            RowsMoved = _event.AdditionalDetails.RowsMoved,
                            RowsCopied = _event.AdditionalDetails.RowsCopied,
                            CelllinkSourceSheetID = _event.AdditionalDetails.CelllinkSourceSheetID,
                            NewParentContainerID = _event.AdditionalDetails.NewParentContainerID,
                            ParentContainerID = _event.AdditionalDetails.ParentContainerID,
                            FolderName = _event.AdditionalDetails.FolderName,
                            RequestUserID = _event.AdditionalDetails.RequestUserID,
                            SendCompletionEmail = _event.AdditionalDetails.SendCompletionEmail,
                            UserIDImpacted = _event.AdditionalDetails.UserIDImpacted,
                            EventTimestamp = _event.AdditionalDetails.EventTimeStamp
                        };
                        superEventDetail.SheetDetails.Add(sheetDetail);
                        break;

                    case "REPORT":
                        var reportDetail = new ReportDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                         
                            ReportName = _event.AdditionalDetails.ReportName,
                            SourceObjectID = _event.AdditionalDetails.SourceObjectID,
                            SourceGlobaltemplateID = _event.AdditionalDetails.SourceGlobalTemplateID,
                            SourceType = _event.AdditionalDetails.SourceType,
                            NewName = _event.AdditionalDetails.NewName,
                            OldName = _event.AdditionalDetails.OldName,
                            AccessLevel = _event.AdditionalDetails.AccessLevel,
                            UserID = _event.AdditionalDetails.UserID,
                            GroupID = _event.AdditionalDetails.GroupID,
                            WorkSpaceID = _event.AdditionalDetails.WorkSpaceID,
                            OldUserID = _event.AdditionalDetails.OldUserID,
                            OldAccessLevel = _event.AdditionalDetails.OldAccessLevel,
                            NewUserID = _event.AdditionalDetails.NewUserID,
                            NewAccessLevel = _event.AdditionalDetails.NewAccessLevel,
                            NewParentContainerID = _event.AdditionalDetails.NewParentContainerID,
                            ParentContainerID = _event.AdditionalDetails.ParentContainerID,
                            FolderName = _event.AdditionalDetails.FolderName,
                            RecipientEmail = _event.AdditionalDetails.RecipientEmail,
                            RecipientGroupID = _event.AdditionalDetails.RecipientGroupID,
                            FormatType = _event.AdditionalDetails.FormatType,
                            UserIDImpacted = _event.AdditionalDetails.UserIDImpacted,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,                                               
                            Source = _event.Source

                        };

                        superEventDetail.ReportDetails.Add(reportDetail);
                        break;
                    case "ATTACHMENT":
                        var attachmentDetail = new AttachmentDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            SheetID = _event.AdditionalDetails.SheetID,
                            WorkSpaceID = _event.AdditionalDetails.WorkSpaceID,                       
                            AttachmentName = _event.AdditionalDetails.AttachmentName,
                            MultifileDownloadname = _event.AdditionalDetails.MultifileDownloadName,
                            RecipientEmail = _event.AdditionalDetails.RecipientEmail,
                            RecipientGroupID = _event.AdditionalDetails.RecipientGroupID,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.AttachmentDetails.Add(attachmentDetail);
                        break;
                    case "USER":
                        var userDetail = new UserDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            UserTypes= _event.AdditionalDetails.UserTypes,
                            EmailAddress= _event.AdditionalDetails.EmailAddress,
                            DeclineReason= _event.AdditionalDetails.DeclineReason,
                            OldownerUserID = _event.AdditionalDetails.OldOwnerUserID,
                            NewownerUserID= _event.AdditionalDetails.NewOwnerUserID,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.UserDetails.Add(userDetail);
                        break;
                    case "DISCUSSION":
                        var discussionDetail = new DiscussionDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            SheetRowID =_event.AdditionalDetails.SheetRowID,
                            SheetID= _event.AdditionalDetails.SheetID,
                            WorkSpaceID= _event.AdditionalDetails.WorkSpaceID,
                            RecipientEmail= _event.AdditionalDetails.RecipientEmail,
                            RecipientGroupID= _event.AdditionalDetails.RecipientGroupID,
                            IncludeAttachments= _event.AdditionalDetails.IncludeAttachments,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.DiscussionDetails.Add(discussionDetail);
                        break;
                    case "DASHBOARD":
                        var dashboardDetail = new DashboardDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            DashboardName = _event.AdditionalDetails.DashboardName,
                            SourceGlobalTemplateID = _event.AdditionalDetails.SourceGlobalTemplateID,
                            SourceObjectID = _event.AdditionalDetails.SourceObjectID,
                            SourceType = _event.AdditionalDetails.SourceType,
                            AccessibleBy = _event.AdditionalDetails.AccessibleBy,
                            PublishType = _event.AdditionalDetails.PublishType,
                            PublishFormat = _event.AdditionalDetails.PublishFormat,
                            AccessLevel = _event.AdditionalDetails.AccessLevel,
                            UserID = _event.AdditionalDetails.UserID,
                            GroupID = _event.AdditionalDetails.GroupID,
                            WorkspaceID = _event.AdditionalDetails.WorkSpaceID,
                            OldUserID = _event.AdditionalDetails.OldUserID,
                            OldAccessLevel = _event.AdditionalDetails.OldAccessLevel,
                            NewUserID = _event.AdditionalDetails.NewUserID,
                            NewAccessLevel = _event.AdditionalDetails.NewAccessLevel,
                            NewparentContainerID = _event.AdditionalDetails.NewParentContainerID,
                            ParentContainerID = _event.AdditionalDetails.ParentContainerID,
                            FolderName = _event.AdditionalDetails.FolderName,
                            OldName = _event.AdditionalDetails.OldName,
                            NewName = _event.AdditionalDetails.NewName,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.DashboardDetails.Add(dashboardDetail);
                        break;
                    case "FOLDER":
                        var folderDetail = new FolderDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            FolderName = _event.AdditionalDetails.FolderName,
                            SourceFolderID = _event.AdditionalDetails.SourceFolderID,
                            OldName = _event.AdditionalDetails.OldName,
                            NewName = _event.AdditionalDetails.NewName,
                            SendCompletionEmail =_event.AdditionalDetails.SendCompletionEmail,
                            IncludeAttachments = _event.AdditionalDetails.IncludeAttachments,
                            FormatType = _event.AdditionalDetails.FormatType,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.FolderDetails.Add(folderDetail);
                        break;
                    case "FORM":
                        var formDetail = new FormDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            FormName = _event.AdditionalDetails.FolderName,
                            SheetID = _event.AdditionalDetails.SheetID,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.FormDetails.Add(formDetail);
                        break;
                    case "UPDATE REQUEST":
                        var updateRequestDetail = new UpdateRequestDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            SheetID = _event.AdditionalDetails.SheetID,
                            RowCounts =_event.AdditionalDetails.RowCount.ToString(),
                            IncludeAttachments = _event.AdditionalDetails.IncludeAttachments,
                            IncludeDiscussions = _event.AdditionalDetails.IncludeDiscussions,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.UpdateRequestDetails.Add(updateRequestDetail);
                        break;
                    case "WORKSPACE":
                        var workspaceDetail = new WorkSpaceDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            OldName = _event.AdditionalDetails.OldName,
                            NewName = _event.AdditionalDetails.NewName,
                            AccessLevel = _event.AdditionalDetails.AccessLevel,
                            UserID = _event.AdditionalDetails.UserID,
                            GroupID = _event.AdditionalDetails.GroupID,
                            IncludeAttachments = _event.AdditionalDetails.IncludeAttachments,
                            SendCompletionEmail = _event.AdditionalDetails.SendCompletionEmail,
                            FormatType = _event.AdditionalDetails.FormatType,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.WorkSpaceDetails.Add(workspaceDetail);
                        break;
                    case "ACCESSTOKEN":
                        var accessTokenDetails = new AccessTokenDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            TokenName  =_event.AdditionalDetails.TokenName,
                            TokenDisplayValue = _event.AdditionalDetails.TokenDisplayValue,
                            TokenExpirationTimestamp = _event.AdditionalDetails.TokenExpirationTimestamp,
                            AccessScopes = _event.AdditionalDetails.AccessScopes,
                            AppClientID = _event.AdditionalDetails.AppClientID,
                            AppName = _event.AdditionalDetails.AppName,
                            TokenUserID = _event.AdditionalDetails.TokenUserID,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.AccessTokenDetails.Add(accessTokenDetails);
                        break;
                    case "ACCOUNT":
                        var accountDetails = new AccountDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            NewContactUserID = _event.AdditionalDetails.NewContactUserID,
                            OldContactUserID = _event.AdditionalDetails.OldContactUserID,
                            NewName = _event.AdditionalDetails.NewName,
                            OldName = _event.AdditionalDetails.OldName,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.AccountDetails.Add(accountDetails);
                        break;
                    case "GROUP":
                        var groupDetails = new GroupDetails()
                        {
                            EventID = _event.EventID,
                            ObjectID = _event.ObjectID,
                            Action = _event.Action,
                            GroupName = _event.AdditionalDetails.GroupName,
                            OldName = _event.AdditionalDetails.OldName,
                            NewName = _event.AdditionalDetails.NewName,
                            OldownerUserID = _event.AdditionalDetails.OldOwnerUserID,
                            NewownerUserID = _event.AdditionalDetails.NewOwnerUserID,
                            MemberUserID = _event.AdditionalDetails.MemberUserID,
                            UserIDInitiator = _event.UserID,
                            EventTimestamp = _event.EventTimestamp,
                            RequestUserID = _event.RequestUserID,
                            Source = _event.Source,
                        };
                        superEventDetail.GroupDetails.Add(groupDetails);
                        break;
                }

            }
            return superEventDetail;
        }
    }
}
