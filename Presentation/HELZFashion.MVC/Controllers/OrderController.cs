using HELZFashion.Domain.Entities;
using HELZFashion.Domain.Enums;
using HELZFashion.Domain.Identity;
using HELZFashion.MVC.Extensions;
using HELZFashion.MVC.ViewModels;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HELZFashion.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly HELZFashionDbContext _context;

        public OrderController(HELZFashionDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Items).ThenInclude(o => o.Clothes).ToList();
            return View(orders);
        }
        public IActionResult OrderSuccess()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            var basket = HttpContext.Session.Get<Basket>("Basket");
            BasketAndOrderViewModel basketAndOrderViewModel = new BasketAndOrderViewModel();
            if (basket == null)
            {
                basket = new Basket
                {
                    Items = new List<BasketItem>()
                };
            }
            basketAndOrderViewModel.Basket = basket;
            return View(basketAndOrderViewModel);
        }
        [HttpPost]
        public IActionResult AddOrder(string orderShippingAddress, PaymentMethod orderPaymentMethod)
        {
            var sessionBasket = HttpContext.Session.Get<Basket>("Basket");
            var basket = _context.Baskets.Include(x => x.Items).ThenInclude(x => x.Clothes).FirstOrDefault(x => x.Id == sessionBasket.Id);

            var order = new Order()
            {
                Id = Guid.NewGuid(),
                ShippingAddress = orderShippingAddress,
                Payment = orderPaymentMethod,
                OrderItems = basket,
                CreatedOn = DateTime.UtcNow,
                OrderDate = DateTime.UtcNow,
            };

            _context.Orders.Add(order);

            _context.SaveChanges();

            var viewModel = new BasketAndOrderViewModel()
            {
                Basket = basket,
                Payment = orderPaymentMethod,
                ShippingAddress = orderShippingAddress
            };
            HttpContext.Session.Remove("Basket");
            return RedirectToAction("OrderSuccess");

        }

        [HttpGet]
        public IActionResult DeleteOrder(string id)
        {
            var order = _context.Orders.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _context.Orders.Remove(order);

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
