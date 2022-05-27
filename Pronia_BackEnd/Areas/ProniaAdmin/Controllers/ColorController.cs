using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class ColorController:Controller
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            List<Models.Color> colors = await _context.Colors.ToListAsync();
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Color color)
        {
            if (!ModelState.IsValid) return View();

            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Color color)
        {

            Models.Color existedColor = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);
            if (existedColor == null) return NotFound();
            if (id != color.Id) return BadRequest();

            //existedSize.Name = size.Name;
            //_context.Sizes.Update(size);
            _context.Entry(existedColor).CurrentValues.SetValues(color);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);
            if (color == null) return NotFound();

            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
