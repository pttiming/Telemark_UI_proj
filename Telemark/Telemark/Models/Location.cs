﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Race")]
        public int race_id { get; set; }
        public Race Race { get; set; }
        [Display(Name = "Name")]
        public string LocationName { get; set; }
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public string Country { get; set; }
        [Column(TypeName = "decimal(10, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }


    }
}
