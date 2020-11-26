using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{

    public class Participant
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User user { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public int registration_id { get; set; }
        public int event_id { get; set; }
        public int bib_num { get; set; }
        public string chip_num { get; set; }
        public int age { get; set; }
        public string registration_date { get; set; }
        public int team_id { get; set; }
        public string team_name { get; set; }
        public int team_type_id { get; set; }
        public string team_type { get; set; }
        public string team_gender { get; set; }
        public string team_bib_num { get; set; }
        public int last_modified { get; set; }

    }
}
