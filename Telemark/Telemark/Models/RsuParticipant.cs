using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{

    public class EventObject
    {
        public int event_id { get; set; }
        public List<ParticipantObject> participants { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country_code { get; set; }
    }

    public class User
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public object middle_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public object profile_image_url { get; set; }
    }

    public class ParticipantObject
    {
        public User user { get; set; }
        public int? registration_id { get; set; }
        public int? event_id { get; set; }
        public int? rsu_transaction_id { get; set; }
        public int? transaction_id { get; set; }
        public int? bib_num { get; set; }
        public string chip_num { get; set; }
        public int? age { get; set; }
        public string registration_date { get; set; }
        public int? team_id { get; set; }
        public string team_name { get; set; }
        public int? team_type_id { get; set; }
        public string team_type { get; set; }
        public string team_gender { get; set; }
        public string team_bib_num { get; set; }
        public int? last_modified { get; set; }
        public string imported { get; set; }
        public string race_fee { get; set; }
        public string offline_payment_amount { get; set; }
        public string processing_fee { get; set; }
        public string processing_fee_paid_by_user { get; set; }
        public string processing_fee_paid_by_race { get; set; }
        public string partner_fee { get; set; }
        public string affiliate_profit { get; set; }
        public string extra_fees { get; set; }
        public string amount_paid { get; set; }
        public string usatf_discount_amount_in_cents { get; set; }
        public string usatf_discount_additional_field { get; set; }
        public string giveaway { get; set; }
        public int? giveaway_option_id { get; set; }
    }

    public class MyArray
    {
        public EventObject @event { get; set; }
        public List<Participant> participants { get; set; }
    }

    public class RsuParticipant
    {
        public List<MyArray> MyArray { get; set; }
    }

}
