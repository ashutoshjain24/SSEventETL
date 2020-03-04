using System;
using System.Collections.Generic;
using System.Text;

namespace SSEventsETL.DomainModel
{
    public class InputStream
    {
        public string NextStreamPosition { get; set; }
        public string Response { get; set; }

        // public List<Event> Data { get { return _data; } set { _data = value; } }
    }
}
