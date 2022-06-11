using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Net.Security;
using System.Text;

namespace Find_All_Here.RestClient
{
    public static class Database
    {
        public static string Connect(string query, dynamic _params, string fetch = "all")
        {

            var request = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
            (
                delegate { return true; }
            );

            NameValueCollection body = new NameValueCollection
            {
                ["x-auth-token"] = "411cededc5c7a6cddd7d31142d4c4c71cc7a174374dde0bcab3d62c9cf03c67d",
                ["query"] = query,
                ["params"] = JSON.Stringuify(_params),
                ["fetch"] = fetch
            };

            var response = request.UploadValues("https://scriptperu.com/find_all_here/index.php", "POST", body);

            return Encoding.Default.GetString(response);
        
        }
        public static string Fetch(string query, string[] parameters, string fetch = "all")
        {
            WebClient request = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
            (
                delegate { return true; }
            );

            NameValueCollection body = new NameValueCollection
            {
                ["x-auth-token"] = "411cededc5c7a6cddd7d31142d4c4c71cc7a174374dde0bcab3d62c9cf03c67d",
                ["query"] = query,
                ["params"] = JsonConvert.SerializeObject(parameters),
                ["fetch"] = fetch
            };
            var response = request.UploadValues("https://scriptperu.com/find_all_here/index.php", "POST", body);
            return Encoding.Default.GetString(response);
        }
    }
}
