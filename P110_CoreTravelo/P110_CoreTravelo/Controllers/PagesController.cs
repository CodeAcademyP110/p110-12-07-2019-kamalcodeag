using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P110_CoreTravelo.DAL;
using P110_CoreTravelo.Models;

namespace P110_CoreTravelo.Controllers
{
    public class PagesController : Controller
    {
        private readonly TraveloDbContext _context;

        public PagesController(TraveloDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Destinations.OrderByDescending(d => d.Id).Take(12));
        }
    }
}