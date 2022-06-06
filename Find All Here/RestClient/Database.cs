using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Net.Security;
using System.Text;

namespace Find_All_Here.RestClient
{
    internal class Database
    {
        private readonly string Url = "https://scriptperu.com/find_all_here/index.php";
        private readonly string Token = "411cededc5c7a6cddd7d31142d4c4c71cc7a174374dde0bcab3d62c9cf03c67d";
        private NameValueCollection Data { get; set; }
        public string Connect(string query, string[] _params, string fetch)
        {

            WebClient request = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
            (
                delegate { return true; }
            );
            NameValueCollection nameValueCollection = new NameValueCollection
            {
                ["x-auth-token"] = Token,
                ["query"] = query,
                ["params"] = JsonConvert.SerializeObject(_params),
                ["fetch"] = fetch
            };
            Data = nameValueCollection;

            var response = request.UploadValues(Url, "POST", Data);

            return Encoding.Default.GetString(response);
        }
    }
}
