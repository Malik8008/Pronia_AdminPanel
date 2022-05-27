using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class CategoryController:Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            List<Models.Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Category categories)
        {
            if (!ModelState.IsValid) return View();

            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Models.Category categories = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (categories == null) return NotFound();
            return View(categories);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Models.Category categories = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (categories == null) return NotFound();
            return View(categories);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Category categories)
        {

            Models.Category  existedCategory = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (existedCategory == null) return NotFound();
            if (id != categories.Id) return BadRequest();

            //existedSize.Name = size.Name;
            //_context.Sizes.Update(size);
            _context.Entry(existedCategory).CurrentValues.SetValues(categories);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Models.Category categories = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (categories == null) return NotFound();
            return View(categories);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            Models.Category categories = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (categories == null) return NotFound();

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
