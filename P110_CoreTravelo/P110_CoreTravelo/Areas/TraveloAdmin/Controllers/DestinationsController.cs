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
using Microsoft.EntityFrameworkCore;

namespace P110_CoreTravelo.Areas.TraveloAdmin.Controllers
{
    [Area("TraveloAdmin")]
    public class DestinationsController : Controller
    {
        private readonly TraveloDbContext _context;
        private readonly IHostingEnvironment _env;

        public DestinationsController(TraveloDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Destinations);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Destination destination = await _context.Destinations.FindAsync(id);
            if (destination == null) return NotFound();

            return View(destination);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (!ModelState.IsValid) return View(destination);

            if(destination.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo should be selected");
                return View(destination);
            }

            if(!destination.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File type is not valid");
                return View(destination);
            }

            if(destination.Photo.Length/1024/1024 > 2)
            {
                ModelState.AddModelError("Photo", "File size can not be more than 2 mb");
                return View(destination);
            }

            destination.Image = await destination.Photo.SaveAsync(_env.WebRootPath, "destinations");

            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            Destination destination = await _context.Destinations.FindAsync(id);
            if (destination == null) return NotFound();

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Destination destination)
        {
            if (!ModelState.IsValid) return View(destination);

            Destination destinationFromDb = await _context.Destinations.FindAsync(destination.Id);

            if (destination.Photo != null)
            {
                if (!destination.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "File type is not valid");
                    return View(destination);
                }

                if (!destination.Photo.IsLessThan(2))
                {
                    ModelState.AddModelError("Photo", "File size can not be more than 2 mb");
                    return View(destination);
                }

                //remove old image
                RemoveImage(_env.WebRootPath, destinationFromDb.Image);

                //save new image
                destinationFromDb.Image = await destination.Photo.SaveAsync(_env.WebRootPath, "destinations");
            }

            destinationFromDb.Name = destination.Name;
            destinationFromDb.Price = destination.Price;
            destinationFromDb.City = destination.City;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #region Update with ModifiedState
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Destination destination)
        //{
        //    if (!ModelState.IsValid) return View(destination);

        //    _context.Entry(destination).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Destination destination = await _context.Destinations.FindAsync(id);
            if (destination == null) return NotFound();

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();

            Destination destination = await _context.Destinations.FindAsync(id);

            if (destination == null) return NotFound();

            RemoveImage(_env.WebRootPath, destination.Image);
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}