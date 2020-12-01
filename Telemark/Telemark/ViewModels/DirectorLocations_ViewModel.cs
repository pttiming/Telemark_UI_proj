using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemark.Models;

namespace Telemark.ViewModels
{
    public class DirectorLocations_ViewModel
    {
        public Director director { get; set; }
        public List<Location> locations { get; set; }

        public List<Race> races { get; set; }
    }
}
