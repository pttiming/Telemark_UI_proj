using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemark.Models;

namespace Telemark.ViewModels
{
    public class DirectorInfoMessage_ViewModel
    {
        public Director director { get; set; }
        public List<InfoMessage> messages { get; set; }

        public List<Race> races { get; set; }

        public IEnumerable<SelectListItem> racelist { get; set; }
    }
}
