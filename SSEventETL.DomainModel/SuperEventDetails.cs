using System;
using System.Collections.Generic;
using System.Text;

namespace SSEventsETL.DomainModel
{
    public class SuperEventDetails
    {

        public SuperEventDetails()
        {
            EventDetailHeaders = new List<EventDetailHeader>();
            AttachmentDetails = new List<AttachmentDetails>();
            AccountDetails = new List<AccountDetails>();
            AccessTokenDetails = new List<AccessTokenDetails>();
            DashboardDetails = new List<DashboardDetails>();
            DiscussionDetails = new List<DiscussionDetails>();
            FolderDetails = new List<FolderDetails>();
            FormDetails = new List<FormDetails>();
            GroupDetails = new List<GroupDetails>();
            ReportDetails = new List<ReportDetails>();
            SheetDetails = new List<SheetDetails>();
            UpdateRequestDetails = new List<UpdateRequestDetails>();
            UserDetails = new List<UserDetails>();
            WorkSpaceDetails = new List<WorkSpaceDetails>();
        }

        public List<EventDetailHeader> EventDetailHeaders { get; set; }
        public List<AttachmentDetails> AttachmentDetails { get; set; }
        public List<AccountDetails> AccountDetails { get; set; }
        public List<AccessTokenDetails> AccessTokenDetails { get; set; }
        public List<DashboardDetails> DashboardDetails { get; set; }
        public List<DiscussionDetails> DiscussionDetails { get; set; }
        public List<FolderDetails> FolderDetails { get; set; }
        public List<FormDetails> FormDetails { get; set; }
        public List<GroupDetails> GroupDetails { get; set; }
        public List<ReportDetails> ReportDetails { get; set; }
        public List<SheetDetails> SheetDetails { get; set; }
        public List<UpdateRequestDetails> UpdateRequestDetails { get; set; }
        public List<UserDetails> UserDetails { get; set; }
        public List<WorkSpaceDetails> WorkSpaceDetails { get; set; }
    }
}
