using System;
using DapperAttribute = Dapper.Contrib.Extensions;



namespace SSEventsETL.DomainModel
{
    [DapperAttribute.Table("SSQEvents")]
    public class Event
    {

        public string EventID { get; set; }
        public string ObjectType { get; set; }
        public string Action { get; set; }
        public string ObjectID { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string UserID { get; set; }
        public string RequestUserID { get; set; }
        public string Source { get; set; }
        //public DateTime EventLoadDatetime { get; set; }
        public AdditionalDetails AdditionalDetails { get; set; }
       }

}
