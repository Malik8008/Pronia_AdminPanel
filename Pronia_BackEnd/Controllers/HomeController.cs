using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.ViewModel.HomeVM;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            this._context = context;
        }


        public async Task<ActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Clients = await _context.Clients.ToListAsync(),
                Plants = await _context.Plants.Include(p=>p.PlantImages).ToListAsync(),
            };
            return View(model);  
        }
    }
}
