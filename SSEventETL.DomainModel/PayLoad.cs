using System;
using System.Collections.Generic;
using System.Text;


namespace SSEventsETL.DomainModel
{
    public class PayLoad
    {
        private List<Event> _data = new List<Event>();

        private bool _moreAvailable = true;

        public string NextStreamPosition { get; set; }
        public bool MoreAvailable { get => _moreAvailable; set => _moreAvailable = value; }
        public List<Event> Data { get { return _data; } set { _data = value; } }
        public int EventCount { get => _data.Count; }
     
    }
}
