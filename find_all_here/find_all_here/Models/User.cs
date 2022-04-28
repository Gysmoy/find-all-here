using System;
using System.Collections.Generic;
using System.Text;

namespace find_all_here.Models
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
        public string Profile_mini { get; set; }
        public string Profile_full { get; set; }
        public string Profile_type { get; set; }
        public bool Status { get; set; }
    }
}
