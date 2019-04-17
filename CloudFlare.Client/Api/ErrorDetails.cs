using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlare.Client.Api
{
    public class ErrorDetails
    {
        public int Code { get; set; }

        public string Message { get; set; }
    }
}
