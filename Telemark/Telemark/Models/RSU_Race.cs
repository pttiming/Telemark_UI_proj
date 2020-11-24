using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{

        public class RSU_Race
        {
            public Race race { get; set; }
        }

        public class Race
        {
            public int race_id { get; set; }
            public string name { get; set; }
            public string last_date { get; set; }
            public string last_end_date { get; set; }
            public object next_date { get; set; }
            public object next_end_date { get; set; }
            public string is_draft_race { get; set; }
            public string is_private_race { get; set; }
            public string is_registration_open { get; set; }
            public string created { get; set; }
            public string last_modified { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string external_race_url { get; set; }
            public object external_results_url { get; set; }
            public string fb_page_id { get; set; }
            public object fb_event_id { get; set; }
            public Address address { get; set; }
            public string timezone { get; set; }
            public string logo_url { get; set; }
            public string can_use_registration_api { get; set; }
            public string real_time_notifications_enabled { get; set; }
            public Event[] events { get; set; }
        }

        public class Address
        {
            public string street { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zipcode { get; set; }
            public string country_code { get; set; }
        }

        public class Event
        {
            public int event_id { get; set; }
            public int race_event_days_id { get; set; }
            public string name { get; set; }
            public object details { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public string age_calc_base_date { get; set; }
            public string registration_opens { get; set; }
            public string event_type { get; set; }
            public string distance { get; set; }
            public string volunteer { get; set; }
            public string require_dob { get; set; }
            public string require_phone { get; set; }
            public Registration_Periods[] registration_periods { get; set; }
            public object[] sub_event_ids { get; set; }
            public string giveaway { get; set; }
        }

        public class Registration_Periods
        {
            public string registration_opens { get; set; }
            public string registration_closes { get; set; }
            public string race_fee { get; set; }
            public string processing_fee { get; set; }
        }
}
