using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemark.Models;

namespace Telemark.ViewModels
{
    public class RaceDetails_ViewModel
    {
        public Race race { get; set; }

        public decimal lat { get; set; }

        public decimal lng { get; set; }

        public List<Participant> participants { get; set; }

        public List<Event> events { get; set; }

        public List<Location> locations { get; set; }

        public string jsonLocations { get; set; }

        public List<SmsMessage> messages { get; set; }

        public List<TextUser> users { get; set; }

        public List<InfoMessage> infoMessages { get; set; }
        public Location[] locs { get; set; }
    }
}
