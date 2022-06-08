using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_BackEnd.DAL;
using Pronia_BackEnd.Models;
using Pronia_BackEnd.ViewModel;
using System;
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
        public async Task<IActionResult> Index(int page=1)
        {
            var query =  _context.Plants.AsQueryable();
            ViewBag.TotalPage = Math.Ceiling((decimal)await query.CountAsync() /3);
            ViewBag.CurrentPage = page;
            List<Plant> plants = await query.Include(p => p.PlantImages).Skip((page-1)*3).Take(3).ToListAsync();
            return View(plants);
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            Plant plant = await _context.Plants.FirstOrDefaultAsync(p=>p.Id==id);
            if (plant == null) return NotFound();
            string BasketStr = HttpContext.Request.Cookies["Basket"];
            List<BasketCookieItemVM> basket;
            //BasketVM baskets;
            //string itemsStr;
            if (string.IsNullOrEmpty(BasketStr))
            {
                basket = new List<BasketCookieItemVM>();
                //BasketItemVM basketItem = new BasketItemVM 
                //{ 
                //    Plant=plant,
                //    Count=1,
                //};
                BasketCookieItemVM cookie = new BasketCookieItemVM 
                { 
                    Id=plant.Id,
                    Count=1,
                };
                basket.Add(cookie);
                //basket.BasketItemVMs.Add(basketItem);
                //basket.TotalPrice = basketItem.Plant.Price;
                //basket.Count = 1;
                BasketStr = JsonConvert.SerializeObject(basket);
                

            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(BasketStr);

                //basket = JsonConvert.DeserializeObject<BasketVM>(BasketStr);
                BasketCookieItemVM existedCookie = basket.FirstOrDefault(p => p.Id == plant.Id);
                //BasketItemVM existedItem = baskets.BasketItemVMs.FirstOrDefault(p => p.Plant.Id == id);
                if (existedCookie==null)
                {
                    BasketCookieItemVM cookie = new BasketCookieItemVM
                    {
                        Id = plant.Id,
                        Count = 1,
                    };
                    //BasketItemVM basketItem = new BasketItemVM
                    //{
                    //    Plant = plant,
                    //    Count = 1,
                    //};
                    //baskets.BasketItemVMs.Add(basketItem);
                    basket.Add(cookie);
                }
                else
                {
                    existedCookie.Count++;
                }
                //decimal total = default;
                //foreach (BasketItemVM item in basket.BasketItemVMs)
                //{
                //    total += item.Plant.Price * item.Count;
                //    baskets.TotalPrice = total;
                //}
                //baskets.Count = baskets.BasketItemVMs.Count;

                BasketStr  = JsonConvert.SerializeObject(basket);

            }
            
            HttpContext.Response.Cookies.Append("Basket", BasketStr);
            return RedirectToAction("Index","Home");
        }

        public ActionResult ShowBasket()
        {
            return Content(HttpContext.Request.Cookies["Basket"]);
        }
    }
}
