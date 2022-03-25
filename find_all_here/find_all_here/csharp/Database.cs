using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Net.Security;
using System.IO;
using System.Text;

namespace find_all_here.csharp
{
    internal class Database
    {
        public string Connect(string query, string[] _params, string fetch)
        {
            string token = "411cededc5c7a6cddd7d31142d4c4c71cc7a174374dde0bcab3d62c9cf03c67d";
            string url = "https://scriptperu.com/find_all_here/index.php";

            WebClient request = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
            (
                delegate { return true; }
            );
            NameValueCollection data = new NameValueCollection();

            data["x-auth-token"] = token;
            data["query"] = query;
            data["params"] = JsonConvert.SerializeObject(_params);
            data["fetch"] = fetch;

            var response = request.UploadValues(url, "POST", data);

            return Encoding.Default.GetString(response);
        }
    }
}
