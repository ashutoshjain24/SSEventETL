using System;
using System.Collections.Generic;
using System.Text;


namespace SSEventsETL.DomainModel
{
    
   public class EventDetails
    {

        private List<EventDetails> _additionalDetails = new List<EventDetails>();
        public List<EventDetails> AdditionalDetails { get => _additionalDetails; set => _additionalDetails = value; }
    }
}
