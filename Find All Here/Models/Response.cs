using System.Collections.Generic;
using System.Collections.Specialized;

namespace Find_All_Here.Models
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<NameValueCollection> Data { get; set; }
        public bool Result { get; set; }
    }
}
