using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Controllers
{
    public class LiveController : Controller
    {

        public IActionResult Announcer()
        {

            return View();
        }

        public IActionResult SelfieOutput()
        {

            return View();
        }

        public IActionResult SelfieController()
        {

            return View();
        }
    }
}
