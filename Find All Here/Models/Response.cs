using System.Collections.Generic;
using System.Collections.Specialized;

namespace Find_All_Here.Models
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<Dictionary<string, string>> Data { get; set; }
        public bool Result { get; set; }
        public int Rows { get; set; }
    }
}
