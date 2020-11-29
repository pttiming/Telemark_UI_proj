using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{

    public class RsuRaces
    {
        [Key]
        public int id { get; set; }
        public RaceObject[] races { get; set; }
    }

    public class RaceObject
    {
        [Key]
        public int id { get; set; }
        public Race race { get; set; }
    }

    public class Race
    {
        [Key]
        public int id { get; set; }
        public int race_id { get; set; }
        [ForeignKey("Director")]
        public int director_id { get; set; }
        public Director Director { get; set; }
        public string name { get; set; }
        public string last_date { get; set; }
        public string last_end_date { get; set; }
        public string next_date { get; set; }
        public string next_end_date { get; set; }
        public string is_draft_race { get; set; }
        public string is_private_race { get; set; }
        public string is_registration_open { get; set; }
        public string created { get; set; }
        public string last_modified { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string external_race_url { get; set; }
        public string external_results_url { get; set; }
        public string fb_page_id { get; set; }
        public long? fb_event_id { get; set; }
        public RaceAddress address { get; set; }
        public string timezone { get; set; }
        public string logo_url { get; set; }
        public string real_time_notifications_enabled { get; set; }
        [NotMapped]
        public Event[] events { get; set; }

        public string Keyword { get; set; }

    }

}
