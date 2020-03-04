using System;
using System.Collections.Generic;
using System.Text;

namespace SSEventsETL.DomainModel
{
    public class CallLog
    {
        private string _request = "";
        private string _response = "";
        private string _requestHeader = "";
        private string _responseHeader = "";
        private DateTime _startTime = new DateTime();
        private DateTime _endTime = new DateTime();
        private PayLoad _payLoad = new PayLoad();
        private string _responseCode = "";
        private bool _isCallSuccess = false;

        public string Request { get => _request; set => _request = value; }
        public string Response { get => _response; set => _response = value; }
        public string RequestHeader { get => _requestHeader; set => _requestHeader = value; }
        public string ResponseHeader { get => _responseHeader; set => _responseHeader = value; }
        public DateTime StartTime { get => _startTime; set => _startTime = value; }
        public DateTime EndTime { get => _endTime; set => _endTime = value; }
        public PayLoad PayLoad { get => _payLoad; set => _payLoad = value; }
        public bool IsCallSuccess { get => _isCallSuccess; set => _isCallSuccess = value; }
        public string ResponseCode { get => _responseCode; set => _responseCode = value; }
    }
}
