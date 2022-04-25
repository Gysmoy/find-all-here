using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace find_all_here.Models
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public ArraySegment<NameValueCollection> Data { get; set; }
    }
}
