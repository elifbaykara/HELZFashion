using HELZFashion.Domain.Entities;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using HELZFashion.MVC.Extensions;

namespace HELZFashion.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly TeamHELZDbContext _context;

        public BasketController(TeamHELZDbContext context)
        {
            _context = context;
  
        }
        public IActionResult Index()
        {
            var basket = HttpContext.Session.Get<Basket>("Basket");

            if (basket == null)
            {
                basket = new Basket
                {
                    Items = new List<BasketItem>()
                };
            }
            return View(basket);
        }

        [HttpPost]
        [HttpGet]
        public IActionResult AddToBasket(Guid productId, int quantity)
        {
            var basket = HttpContext.Session.Get<Basket>("Basket");
            var clothes = _context.ClothesList.Include(x => x.Brand).FirstOrDefault(x => x.Id == productId);

            if (basket == null)
            {
                basket = new Basket
                {
                    Id = Guid.NewGuid(),
                    Items = new List<BasketItem>(),
                };

                _context.Baskets.Add(basket);
            }

            var basketItem = basket.Items.FirstOrDefault(x => x.Clothes.Id == productId);

            if (basketItem == null)
            {
                basketItem = new BasketItem
                {
                    Id = Guid.NewGuid(),
                    Clothes = clothes,
                    Quantity = quantity
                };

                _context.BasketItems.Add(basketItem);
                basket.Items.Add(basketItem);
            }
            else
            {
                basketItem.Quantity += quantity;
            }

            HttpContext.Session.Set("Basket", basket);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateBasket(Guid basketId, Guid productId, int quantity)
        {
            var basket = HttpContext.Session.Get<Basket>("Basket");

            if (basket != null)
            {
                var item = basket.Items.FirstOrDefault(i => i.Clothes.Id == productId);
                if (item != null)
                {
                    item.Quantity = quantity;
                    HttpContext.Session.Set("Basket", basket);
                }
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveFromBasket(Guid productId)
        {
            var basket = HttpContext.Session.Get<Basket>("Basket");

            if (basket != null)
            {
                var item = basket.Items.FirstOrDefault(i => i.Clothes.Id == productId);
                if (item != null)
                {
                    basket.Items.Remove(item);
                    HttpContext.Session.Set("Basket", basket);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
