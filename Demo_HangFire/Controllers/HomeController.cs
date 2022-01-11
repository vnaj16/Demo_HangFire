using Demo_HangFire.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_HangFire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBackgroundJobs _backgroundJobs;

        public HomeController(ILogger<HomeController> logger, IBackgroundJobs backgroundJobs)
        {
            _logger = logger;
            _backgroundJobs = backgroundJobs;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FireAndForgetJob()
        {
            _backgroundJobs.FireAndForgetJob();
            return Ok();
        }

        public IActionResult DelayedJob()
        {
            _backgroundJobs.DelayedJob();
            return Ok();
        }

        public IActionResult ContinuationJob()
        {
            _backgroundJobs.ContinuationJob();
            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
