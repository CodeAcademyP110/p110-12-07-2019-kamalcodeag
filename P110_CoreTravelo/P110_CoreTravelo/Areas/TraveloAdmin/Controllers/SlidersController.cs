using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P110_CoreTravelo.DAL;
using P110_CoreTravelo.Models;
using static P110_CoreTravelo.Extensions.IFormFileExtensions;
using static P110_CoreTravelo.Utilities.Utilities;

namespace P110_CoreTravelo.Areas.TraveloAdmin.Controllers
{
    [Area("TraveloAdmin")]
    public class SlidersController : Controller
    {
        private readonly TraveloDbContext _context;
        private readonly IHostingEnvironment _env;

        public SlidersController(TraveloDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            Slider slider = await _context.Sliders.FindAsync(id);

            if(slider == null) return NotFound();

            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider) //model binding
        {
            if(ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            
            if(!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "File type should be image");
                return View();
            }

            if(!slider.Photo.IsLessThan(2))
            {
                ModelState.AddModelError("Photo", "Image size can not be more than 2 mb.");
                return View();
            }

            string filename = await slider.Photo.SaveAsync(_env.WebRootPath, "sliders");
            slider.Image = filename;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGet(int? id)
        {
            if (id == null) return NotFound();

            Slider slider = await _context.Sliders.FindAsync(id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            RemoveImage(_env.WebRootPath, slider.Image);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}