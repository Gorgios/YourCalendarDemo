using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Terminarz.Data;
using Terminarz.Models;

namespace Terminarz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private CallsController _callsController;
        private HappeningsController _happeningsController;
        private MeetingsController _meetingsController;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, CallsController callsConroller, 
            HappeningsController happeningsController, MeetingsController meetingsController)
        {
            _callsController = callsConroller;
            _happeningsController = happeningsController;
            _meetingsController = meetingsController;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var happenings = _context.Happenings;
            var meetings = _context.Meetings.Include(c => c.Contact);
            var calls = _context.Calls.Include(c => c.Contact);
            List<Models.Task> Tasks = new List<Models.Task>();
            foreach (Meeting m in meetings)
            {
                Tasks.Add(m);
            }
            foreach (Call c in calls)
            {
                Tasks.Add(c);
            }
            foreach (Happening h in happenings)
            {
                Tasks.Add(h);
            }
            var sorted = Tasks.OrderBy(d => d.Date).ThenBy(t => t.Time);
            return View(sorted.ToList());
        }
        public IActionResult GetNewestTask()
        {
            var happenings = _context.Happenings;
            var meetings = _context.Meetings.Include(c => c.Contact);
            var calls = _context.Calls.Include(c => c.Contact);
            List<Models.Task> Tasks = new List<Models.Task>();
            foreach (Meeting m in meetings)
            {
                Tasks.Add(m);
            }
            foreach (Call c in calls)
            {
                Tasks.Add(c);
            }
            foreach (Happening h in happenings)
            {
                Tasks.Add(h);
            }
            var sorted = Tasks.OrderBy(d => d.Date).ThenBy(t => t.Time);
            return View(sorted.ToList()[0]);
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
    }
}
