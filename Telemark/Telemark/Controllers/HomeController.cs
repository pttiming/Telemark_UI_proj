using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Telemark.Data;
using Telemark.Models;
using Telemark.Services;
using Telemark.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;

namespace Telemark.Controllers
{

  

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHubContext<ResultsHub> _resultsHub;

        public RSU_Service _RSU;

        public ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, RSU_Service RSU, ApplicationDbContext context, IHubContext<ResultsHub> resultsHub)
        {
            _logger = logger;
            _RSU = RSU;
            _context = context;
            _resultsHub = resultsHub;
        }

        public IActionResult Index()
        {

            return View();
        }
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        [HttpPost]
        public void RaceResult(dynamic obj)
        {
            _resultsHub.Clients.Group("1").SendAsync("GetResult","test");


        }

    }
}


