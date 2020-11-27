using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
    }
}
