using Find_All_Here.RestClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Find_All_Here.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Birth_date { get; set; }
        public string Profile_mini { get; set; }
        public string Profile_full { get; set; }
        public string Profile_type { get; set; }

        public bool Status { get; set; }

        // constructor
        public User()
        {
            Status = false;
        }

        public static Response GetUserByUsernameAndPassword(string username, string password)
        {
            var sp = StoredProcedures.GetUserByUsernameAndPassword;
            string[] parameters = { username, username, password };
            string res_user = Database.Fetch(sp, parameters, "one");
            
            Response data_user = JsonConvert.DeserializeObject<Response>(res_user);
            return data_user;
        }
    }
}
