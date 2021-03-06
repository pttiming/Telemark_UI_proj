﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class PushResult
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("TextUser")]
        public int user_id { get; set; }
        public TextUser TextUser { get; set; }
        public int race_id { get; set; }
        public int participant_bib { get; set; }
        public bool completed { get; set; }

    }
}
