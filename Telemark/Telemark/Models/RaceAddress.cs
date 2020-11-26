using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class RaceAddress
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Race")]
        public int race_id { get; set; }
        public Race Race { get; set; }
        public string street { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country_code { get; set; }
    }
}
