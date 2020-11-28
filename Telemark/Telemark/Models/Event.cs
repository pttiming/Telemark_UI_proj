using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Race")]
        public int race_id { get; set; }
        public Race race { get; set; }
        public int event_id { get; set; }
        public int race_event_days_id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string age_calc_base_date { get; set; }
        public string registration_opens { get; set; }
        public string event_type { get; set; }
        public string distance { get; set; }
        public string volunteer { get; set; }
        public string require_dob { get; set; }
        public string require_phone { get; set; }
        [NotMapped]
        public Registration_Periods[] registration_periods { get; set; }
        [NotMapped]
        public string[] sub_event_ids { get; set; }
        public string giveaway { get; set; }
    }

    public class Registration_Periods
    {
        [Key]
        public int id { get; set; }
        public string registration_opens { get; set; }
        public string registration_closes { get; set; }
        public string race_fee { get; set; }
        public string processing_fee { get; set; }
    }
}
