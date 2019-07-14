using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P110_CoreTravelo.DAL;
using P110_CoreTravelo.Models;
using P110_CoreTravelo.ViewModel;

namespace P110_CoreTravelo.Controllers
{
    public class HomeController : Controller
    {
        private readonly TraveloDbContext _context;

        public HomeController(TraveloDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeIndexVM viewModel = new HomeIndexVM()
            {
                Sliders = _context.Sliders,
                Destinations = _context.Destinations.OrderByDescending(d => d.Id).Take(4),
                HoneyMoon = _context.HoneyMoon.First(),
                HoneymoonDestinations = _context.HoneymoonDestinations,
                Services=_context.Services,
                Blogs = _context.Blogs
            };

            return View(viewModel);
        }

    }
}