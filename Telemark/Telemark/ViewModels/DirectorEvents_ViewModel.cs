using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemark.Models;

namespace Telemark.ViewModels
{
    public class DirectorEvents_ViewModel
    {
        public List<Race> rsuRaces { get; set; }

        public List<Race> importedRaces { get; set; }
    }
}
