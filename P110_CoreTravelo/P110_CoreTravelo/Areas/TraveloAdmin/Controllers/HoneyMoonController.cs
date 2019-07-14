using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using P110_CoreTravelo.DAL;
using P110_CoreTravelo.Models;
using static P110_CoreTravelo.Extensions.IFormFileExtensions;
using static P110_CoreTravelo.Utilities.Utilities;

namespace P110_CoreTravelo.Areas.TraveloAdmin.Controllers
{
    [Area("TraveloAdmin")]
    public class HoneyMoonController : Controller
    {
        private readonly TraveloDbContext _context;
        private readonly IHostingEnvironment _env;

        public HoneyMoonController(TraveloDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.HoneyMoon.First());
        }

        public IActionResult Edit()
        {
            return View(_context.HoneyMoon.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(include: "Info, Title")]HoneyMoon honeyMoon)
        {
            if (!ModelState.IsValid) return View(honeyMoon);

            HoneyMoon honeyMoonFromDb = _context.HoneyMoon.First();

            honeyMoonFromDb.Title = honeyMoon.Title;
            honeyMoonFromDb.Info = honeyMoon.Info;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}