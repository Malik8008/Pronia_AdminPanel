using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpcontext;

        public LayoutService(AppDbContext context, IHttpContextAccessor httpcontext)
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
            string basketStr = _httpcontext.HttpContext.Request.Cookies["Basket"];
            BasketVM basketData = new BasketVM();
            if (!string.IsNullOrEmpty(basketStr))
            {
                List<BasketCookieItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(basketStr);


                //List<Plant> query = await _context.Plants.Include(p=>p.PlantImages).ToListAsync();

                var query = _context.Plants.Include(p => p.PlantImages).AsQueryable();

                foreach (BasketCookieItemVM item in basket)
                {
                    Plant existedPlant = query.FirstOrDefault(p => p.Id == item.Id);

                    if (existedPlant != null)
                    {

                        BasketItemVM basketItem = new BasketItemVM
                        {
                            Plant = existedPlant,
                            Count = item.Count
                        };

                        basketData.BasketItemVMs.Add(basketItem);


                    }
                }
                decimal total = default;
                foreach (BasketItemVM item in basketData.BasketItemVMs)
                {
                    total += item.Plant.Price * item.Count;
                }
                basketData.TotalPrice = total;
                basketData.Count = basketData.BasketItemVMs.Count;

                //BasketVM basketData = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                return basketData;

            }
            else
            {
                return null;
            }
        }
    }
}
