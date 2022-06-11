using Newtonsoft.Json;
using Microsoft.CSharp;

namespace Find_All_Here.RestClient
{
    public static class JSON
    {
        public static object Parse(string data)
        {
            return JsonConvert.DeserializeObject(data);
        }

        public static string Stringuify(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
