using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Controllers
{
    public class PlantController : Controller
    {
        private readonly AppDbContext _context;

        public PlantController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AddBasket(int id)
        {
            Plant plant = await _context.Plants.FirstOrDefaultAsync(p=>p.Id==id);
            if (plant == null) return NotFound();
            string BasketStr = HttpContext.Request.Cookies["Basket"];
            BasketVM baskets;
            string itemsStr;
            if (string.IsNullOrEmpty(BasketStr))
            {
                baskets = new BasketVM();
                BasketItemVM basketItem = new BasketItemVM 
                { 
                    Plant=plant,
                    Count=1,
                };
                baskets.BasketItemVMs.Add(basketItem);
                baskets.TotalPrice = basketItem.Plant.Price;
                baskets.Count = 1;
                itemsStr = JsonConvert.SerializeObject(baskets);
                

            }
            else
            {
                baskets = JsonConvert.DeserializeObject<BasketVM>(BasketStr);
                BasketItemVM existedItem = baskets.BasketItemVMs.FirstOrDefault(p => p.Plant.Id == id);
                if (existedItem==null)
                {
                    BasketItemVM basketItem = new BasketItemVM
                    {
                        Plant = plant,
                        Count = 1,
                    };
                    baskets.BasketItemVMs.Add(basketItem);
                }
                else
                {
                    existedItem.Count++;
                }
                decimal total = default;
                foreach (BasketItemVM item in baskets.BasketItemVMs)
                {
                    total += item.Plant.Price * item.Count;
                    baskets.TotalPrice = total;
                }
                baskets.Count = baskets.BasketItemVMs.Count;

                itemsStr  = JsonConvert.SerializeObject(baskets);

            }
            
            HttpContext.Response.Cookies.Append("Basket", itemsStr);
            return RedirectToAction("Index","Home");
        }

        public ActionResult ShowBasket()
        {
            return Content(HttpContext.Request.Cookies["Basket"]);
        }
    }
}
