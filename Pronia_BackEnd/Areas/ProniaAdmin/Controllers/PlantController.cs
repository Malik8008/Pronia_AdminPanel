using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Extensions;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task<IActionResult> Create(Plant plant)
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

            plant.PlantImages = new List<PlantImage>();

            PlantImage mainImage = new PlantImage
            {
                ImagePath = await plant.MainImage.FileCreate(_env.WebRootPath, @"assets\images\website-images"),
                IsMain=true,
                Plant=plant
            };

            plant.PlantImages.Add(mainImage);   

            foreach (var anot in plant.AnotherImage)
            {
                PlantImage anotherImage = new PlantImage
                {
                    ImagePath = await anot.FileCreate(_env.WebRootPath, @"assets\images\website-images"),
                    IsMain = false,
                    Plant = plant
                };

                plant.PlantImages.Add(anotherImage);    
            }

            plant.PlantCategories = new List<PlantCategory>();
            foreach (var item in plant.CategoryIds)
            {
                PlantCategory plantCategory = new PlantCategory
                { 
                    Plant=plant,
                    CategoryId=(int)item                   
                };

                plant.PlantCategories.Add(plantCategory);

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
        public async Task<ActionResult> Edit(Plant plant ,int id)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Plant existed = await _context.Plants.Include(p=>p.PlantImages).Include(p=>p.PlantCategories).FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) return NotFound();
            if (plant.ImageIds==null && plant.AnotherImage==null)
            { 
                ModelState.AddModelError("", "You cannot delete all images in anotherImage");
                return View(existed);
            }

            List<PlantImage> removableMainImg = existed.PlantImages.Where(i => i.IsMain == true && plant.MainImageId != id).ToList();
            existed.PlantImages.RemoveAll(p => removableMainImg.Any(mi => mi.Id == id));

            if (plant.MainImage == null && plant.MainImageId == null)
            {
                ModelState.AddModelError("", "You cannot delete all images before add mainImage");
                return View(existed);
            }

            if (plant.MainImage != null)
            {
                plant.PlantImages = new List<PlantImage>();
                PlantImage mainImage = new PlantImage
                {
                    ImagePath = await plant.MainImage.FileCreate(_env.WebRootPath, "assets/images/website-images"),
                    IsMain = true,
                    Plant = plant

                };
                plant.PlantImages.Add(mainImage);

            }



            List<PlantImage> removableImages = existed.PlantImages.Where(i => i.IsMain == false && !plant.ImageIds.Contains(i.Id)).ToList();
            existed.PlantImages.RemoveAll(p => removableImages.Any(rp => rp.Id == p.Id));


            List<PlantCategory> removableCategories = existed.PlantCategories.Where(i => !plant.CategoryIds.Contains(i.CategoryId)).ToList();
            foreach (var item in plant.CategoryIds)
            {
                existed.PlantCategories.RemoveAll(p => removableCategories.Any(rc => plant.Id == p.Id));

                PlantCategory plantCategory = new PlantCategory 
                {
                    PlantId=existed.Id,
                    CategoryId=(int)item
                };
                existed.PlantCategories.Add(plantCategory);

            }


            foreach (var image in removableImages)
            {
                FileUtility.FileDelete(_env.WebRootPath, @"assets\images\website-images", image.ImagePath);
            }

            if (plant.AnotherImage != null)
            {
                foreach (var anot in plant.AnotherImage)
                {
                    PlantImage plantImage = new PlantImage
                    {
                        ImagePath = await anot.FileCreate(_env.WebRootPath, @"assets\images\website-images"),
                        IsMain = false,
                        PlantId = existed.Id
                    };

                    existed.PlantImages.Add(plantImage);
                }
            }
           

            _context.Entry(existed).CurrentValues.SetValues(plant);
            await _context.SaveChangesAsync();  


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();


            Plant plants = await _context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(p => p.Id == id);
            return View(plants);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Plant plants = await _context.Plants.Include(p=> p.PlantImages).FirstOrDefaultAsync(p=> p.Id == id);

            return View(plants);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePlant(Plant plant, int id)
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            plant = await _context.Plants.Include(p => p.PlantImages).FirstOrDefaultAsync(p => p.Id == id);

            if (plant == null) return NotFound();


            PlantImage plantImage = new PlantImage();
            string Path = $"~/assets/images/website-images/{plantImage.ImagePath}";
            FileInfo file = new FileInfo(Path);
            if (file.Exists)
            {
                file.Delete();
            }
            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }


    }
}
