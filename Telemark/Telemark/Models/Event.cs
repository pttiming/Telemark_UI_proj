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
        public Race Race { get; set; }
        public int event_id { get; set; }
        public int race_event_days_id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string event_type { get; set; }
        public string distance { get; set; }
    }
}
