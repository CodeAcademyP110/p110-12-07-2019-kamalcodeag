using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatery.DB;
using Microsoft.AspNetCore.Mvc;

namespace Eatery.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly EateryDb _context;
        public DashboardController(EateryDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}