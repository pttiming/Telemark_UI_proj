using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class TextUser
    {
        public int id { get; set; }
        public string FullNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string current_race { get; set; }

        public string last_request { get; set; }

        public DateTime last_request_tem { get; set; }

        public bool is_participant { get; set; }

        public int participant_id { get; set; }


    }
}
