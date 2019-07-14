using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eatery.DB;
using Eatery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eatery.Controllers
{
    public class HomeController : Controller
    {
        private readonly EateryDb _context;
        public HomeController(EateryDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                MainSliders = _context.MainSliders,
                Products = _context.Products,
                DishTypography = _context.DishTypographies.FirstOrDefault(),
                DishItems = _context.DishItems,
                MenuTypography = _context.MenuTypographies.FirstOrDefault(),
                MenuItems = _context.MenuItems,
                TestimonialTypography = _context.TestimonialTypographies.FirstOrDefault(),
                TestimonialItems = _context.TestimonialItems,
                BlogTypography = _context.BlogTypographies.FirstOrDefault(),
                BlogItems = _context.BlogItems
            };
            return View(homeVM);
        }
      
    }
}
