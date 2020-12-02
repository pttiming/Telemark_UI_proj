using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{
    public class RawResult
    {
        public int bib { get; set; }

        public string time { get; set; }

        public int participant_id { get; set; }

        public Participant participant { get; set; }

        public RawResult()
        {

        }
    }
}
