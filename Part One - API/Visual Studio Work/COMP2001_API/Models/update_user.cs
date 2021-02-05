using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2001_API.Models
{
    public class update_user
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
    }
}
