using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HttoFundamentalsListener
{
    public  class ResponseListen
    {
        public string ResponseText { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string Header { get; set; } = "";
        public string Coockie { get; set; } = "";
    }
}
