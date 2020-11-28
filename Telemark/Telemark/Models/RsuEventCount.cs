using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Models
{

    public class RsuEventCount
    {
        public Participant_Counts[] participant_counts { get; set; }
    }

    public class Participant_Counts
    {
        public int event_id { get; set; }
        public int num_participants { get; set; }
    }

}
