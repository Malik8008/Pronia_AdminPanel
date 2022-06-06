using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpcontext;

        public LayoutService(AppDbContext context,IHttpContextAccessor httpcontext)
        {
            _context = context;
            _httpcontext = httpcontext;
        }

        public async Task<List<Setting>> GetDatas()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }

        public async Task<BasketVM> GetBasket()
        {
            string BasketStr = _httpcontext.HttpContext.Request.Cookies["Basket"];
            BasketVM basketVM = new BasketVM();
            if (!string.IsNullOrEmpty(BasketStr))
            {
                BasketVM basketData = JsonConvert.DeserializeObject<BasketVM>(BasketStr);
                return basketData;
            }
            else
            {
                return null;
            }
        }
    }
}
