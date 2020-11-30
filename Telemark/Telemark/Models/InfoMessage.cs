using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class InfoMessage
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Race")]
        public int race_id { get; set; }
        public Race race { get; set; }
        public string keyword { get; set; }
        public string information { get; set; }

    }
}
