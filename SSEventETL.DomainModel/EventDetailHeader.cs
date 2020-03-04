using System;
using System.Collections.Generic;
using System.Text;

namespace SSEventsETL.DomainModel
{
    public class EventDetailHeader
    {
        public string NextStreamPosition { get; set; }
        public string EventID { get; set; }
        public DateTime? EventTimeStamp { get; set; } 
    }
}
