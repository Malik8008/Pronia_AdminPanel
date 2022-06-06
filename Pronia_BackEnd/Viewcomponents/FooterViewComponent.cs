using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Viewcomponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Setting> setting = await _context.Settings.ToListAsync();
            return View(setting);
        }
    }
}
