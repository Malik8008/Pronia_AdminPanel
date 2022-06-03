using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Extensions;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Models.Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Models.Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (slider.Photo!=null)
            {
                //if (!slider.Photo.IsImage())
                //{
                //    ModelState.AddModelError("Photo", "Please choose supported file");
                //    return View();
                //}

                //if (slider.Photo.IsGreater(1))
                //{
                //    ModelState.AddModelError("Photo", "Please choose !MB image file");
                //    return View();
                //}

                if (!slider.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Please choose supported file");
                    return View();
                }

                //string Filename = slider.Photo.FileName;
                //string path = Path.Combine(_env.WebRootPath, "assets", "images", "website-images");
                //string fullPath = Path.Combine(path, Filename);

                //using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                //{
                //    await slider.Photo.CopyToAsync(stream);
                //}
                //slider.Image = Filename;


                slider.Image = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\images\website-images");
                await _context.Sliders.AddAsync(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose file");
                return View();
            }   
        }

        public async Task<IActionResult> Detail(int id)
        {
            Models.Slider slider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id);
            if (slider == null) return NotFound();

            return View(slider);
        }


        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            Models.Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {

            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (existedSlider == null) return NotFound();
            if (id != slider.Id) return BadRequest();

            existedSlider.Title = slider.Title;
            existedSlider.Subtitle = slider.Subtitle;
            existedSlider.Discount = slider.Discount;
            existedSlider.Order = slider.Order;
            existedSlider.Image = slider.Image;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
