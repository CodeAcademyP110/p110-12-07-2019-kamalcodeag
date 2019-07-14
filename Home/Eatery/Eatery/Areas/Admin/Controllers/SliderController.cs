using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eatery.DB;
using Eatery.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Eatery.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly EateryDb _context;
        private readonly IHostingEnvironment _env;
        public SliderController(EateryDb context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.MainSliders);
        }

        [HttpGet]
        [ActionName("Create")]
        public IActionResult CreateGet()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(MainSlider mainSlider)
        {
            if(!ModelState.IsValid)
            {
                return View(mainSlider);
            }

            if(mainSlider.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil yükləyin");
                return View(mainSlider);
            }

            if(mainSlider.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + mainSlider.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                //await mainSlider.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await mainSlider.Photo.CopyToAsync(fileStream);
                }

                MainSlider newMainSlider = new MainSlider()
                {
                    Background = fileName,
                    Title = mainSlider.Title,
                    Info = mainSlider.Info
                };

                _context.MainSliders.Add(newMainSlider);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainSlider mainSliderFromDb = _context.MainSliders.Find(id);

            if (mainSliderFromDb == null)
            {
                return NotFound();
            }

            return View(mainSliderFromDb);
        }

        [HttpGet]
        [ActionName("Edit")]
        public IActionResult EditGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            MainSlider mainSliderFromDb = _context.MainSliders.Find(id);
            
            if(mainSliderFromDb == null)
            {
                return NotFound();
            }

            return View(mainSliderFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? id, MainSlider mainSlider)
        {
           if(id == null)
           {
                return NotFound();
           }

            MainSlider mainSliderFromDb = _context.MainSliders.Find(id);

            if (mainSliderFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
           {
                return View(mainSlider);
           }

            if (mainSlider.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil yükləyin");
                return View(mainSlider);
            }

            string currentFilePath = Path.Combine(_env.WebRootPath, "img", mainSliderFromDb.Background);
            if (System.IO.File.Exists(currentFilePath))
            {
                System.IO.File.Delete(currentFilePath);
            }

            if (mainSlider.Photo.ContentType.Contains("image/"))
           {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + mainSlider.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                //string result = filePath.Replace(@"\", @"/");
                //await mainSlider.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));

                using(FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await mainSlider.Photo.CopyToAsync(fileStream);
                }

                mainSliderFromDb.Background = fileName;
                mainSliderFromDb.Title = mainSlider.Title;
                mainSliderFromDb.Info = mainSlider.Info;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult DeleteGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainSlider mainSliderFromDb = _context.MainSliders.Find(id);

            if(mainSliderFromDb == null)
            {
                return NotFound();
            }

            return View(mainSliderFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            MainSlider mainSliderFromDbToBeDeleted = _context.MainSliders.Find(id);

            if (mainSliderFromDbToBeDeleted == null)
            {
                return NotFound();
            }

            string currentFilePath = Path.Combine(_env.WebRootPath, "img", mainSliderFromDbToBeDeleted.Background);
            if (System.IO.File.Exists(currentFilePath))
            {
                System.IO.File.Delete(currentFilePath);
            }

            _context.MainSliders.Remove(mainSliderFromDbToBeDeleted);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}