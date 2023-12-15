using HELZFashion.Domain.Entities;
using HELZFashion.Domain.Enums;
using HELZFashion.MVC.Models;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HELZFashion.MVC.Controllers
{
    public class ClothesController : Controller
    {
        private readonly HELZFashionDbContext _context;
        public ClothesController()
        {
            _context = new();
        }
        public IActionResult Index()
        {
            var products = _context.ClothesList.Include(x => x.Brand).Include(x => x.Category).ToList();


            return View(products);
        }

        //Add method:
        [HttpGet]
        public IActionResult Add()
        {
            var brands = _context.Brands.ToList();

            var categories = _context.Categories.ToList();

            var model = new ClothesAddBrandCategory
            {
                Brands = brands,
                Categories = categories,
            
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string price, string pictureUrl, string categoryId, string color)
        {
            var brand = _context.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();
            var category = _context.Categories.Where(x => x.Id == Guid.Parse(categoryId)).FirstOrDefault();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) ||  string.IsNullOrEmpty(price))
            {
                // Gerekli alanlar boşsa veya null ise, hata mesajı oluşturun ve geri dönün.
                ModelState.AddModelError("Validation", "Name, Description and Price are required.");
                return View();
            }
            var clothing = new HELZFashion.Domain.Entities.Clothes()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = decimal.Parse(price),
                ImageUrl = pictureUrl, 
                ColorType = (HELZFashion.Domain.Enums.ColorType)Convert.ToInt32(color),
                Brand = brand,
                Category = category,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CreatedByUserId = "LivanurErdem",
            };

            _context.ClothesList.Add(clothing);

            _context.SaveChanges();

            return RedirectToAction("add");
        }
        [HttpGet]
        //Delete method:
        // [Route("[controller]/[action]/{id}")]
        public IActionResult Delete(string id)
        {
            var clothes = _context.ClothesList.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _context.ClothesList.Remove(clothes);

            clothes.DeletedByUserId = "LivanurErdem";
            clothes.DeletedOn = DateTime.UtcNow;
            clothes.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Details(string id)
        {
            var clothes = _context.ClothesList.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            if (clothes != null)
            {
            
                if (!string.IsNullOrEmpty(clothes.ImageUrl))
                {
                    return View(clothes);
                }
            }
            _context.SaveChanges();
            return View(clothes);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost] public IActionResult Update (Guid id, string name, string description, string brandId, decimal price, ColorType color, string pictureUrl, Category categoryId) {

            var brand = _context.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();
            var clothes = _context.ClothesList.FirstOrDefault(x => x.Id == id);

            if(clothes is not null)
            {
                clothes.Name = name;
                clothes.Description = description;
                clothes.Brand = brand;
                clothes.Price = price;
                clothes.ColorType = color;
                clothes.ImageUrl = pictureUrl;
                clothes.Category = categoryId;


                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("error");
        
        }

    }
}
