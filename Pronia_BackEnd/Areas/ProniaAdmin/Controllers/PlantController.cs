using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Extensions;
using Pronia_BackEnd.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class PlantController: Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PlantController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Models.Plant> plants = await _context.Plants.Include(p=>p.PlantImages).ToListAsync();
            return View(plants);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Models.Plant plant)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid) return View();
            if (plant.MainImage==null || plant.AnotherImage==null)
            {
                ModelState.AddModelError("", "Please choose mainImage or anotherImage");
                return View();
            }
            if (!plant.MainImage.IsOkay(1))
            {
                ModelState.AddModelError("MainImage", "Please choose mainImage 1MB place");
                return View();
            }
            foreach (var anot in plant.AnotherImage)
            {
                if (!anot.IsOkay(1))
                {
                    ModelState.AddModelError("AnotherImage", "Please choose AnotherImage 1MB place");
                    return View();
                }
            }

            plant.PlantImages = new List<Models.PlantImage>();

            Models.PlantImage mainImage = new Models.PlantImage
            {
                ImagePath = await plant.MainImage.FileCreate(_env.WebRootPath, @"assets/images/website-images"),
                IsMain=true,
                Plant=plant
            };

            plant.PlantImages.Add(mainImage);   

            foreach (var image in plant.AnotherImage)
            {
                Models.PlantImage anotherImage = new Models.PlantImage
                {
                    ImagePath = await image.FileCreate(_env.WebRootPath, @"assets/images/website-images"),
                    IsMain = false,
                    Plant = plant
                };

                plant.PlantImages.Add(anotherImage);    
            }

            await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Models.Plant plant = await _context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(p => p.Id == id);
            if (plant == null) return NotFound();

            return View(plant);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(Models.Plant plant ,int id)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Models.Plant existed = await _context.Plants.FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) return View();

            return RedirectToAction(nameof(Index));
        }
    }
}
