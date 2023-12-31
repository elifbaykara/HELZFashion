﻿using HELZFashion.Domain.Entities;
using HELZFashion.Domain.Enums;
using HELZFashion.MVC.Models;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace HELZFashion.MVC.Controllers
{
    public class CategoryController : Controller
    {
       private readonly TeamHELZDbContext _dbcontext;
        public CategoryController(TeamHELZDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var category = _dbcontext.Categories.ToList(); 
            return View(category);
        }

        //Add

        /* [HttpGet]
         public IActionResult Add()
         {
             var model = new ClothesAddBrandCategory
             {
                 Clothes = new Clothes()

             };
             return View(model);
         }

         */
        // Add 
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Add(string categoryName, string gender)
         {
            if (string.IsNullOrEmpty(categoryName))
            {
                // Eğer categoryName null veya boşsa hata mesajı gönder veya işlem yap
                return BadRequest("Category name cannot be null or empty.");
            }
            Category category = new();
             category.CategoryName = categoryName;
             category.Gender = (HELZFashion.Domain.Enums.Gender)Convert.ToInt32(gender);
             category.CreatedOn = DateTime.UtcNow;
             category.IsDeleted = false;
             category.CreatedByUserId = "LivanurErdem";
             _dbcontext.Categories.Add(category);
             _dbcontext.SaveChanges();
             return View();
         }

        //Delete
        [HttpGet]
        public IActionResult Delete(string id) { 
            var category = _dbcontext.Categories.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
        _dbcontext.Categories.Remove(category);

            category.DeletedByUserId = "LivanurErdem";
            category.DeletedOn = DateTime.UtcNow;
            category.IsDeleted = true;
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        /*//Update
        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Update([FromRoute] string id)
        {
            var category = _dbcontext.Categories.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            return View(category);
        }*/

        /* // GetAll
         [HttpGet]
         [Route("[controller]/[action]/{categoryId}")]
         public IActionResult GetAllClothes(string categoryId)
         {

             var category = _dbcontext.Categories
                           .Include(c => c.Clothes)
                           .FirstOrDefault(c => c.Id == Guid.Parse(categoryId));


             return View(category);
         }*/

        [HttpGet]
        public IActionResult Update(Guid id)
        {
          
            var categories = _dbcontext.Categories.ToList();

            var upClothes = new ClothesAddBrandCategory
            {
                Categories = categories
            };

            return View(upClothes);
        }
        [HttpPost]
        public IActionResult Update(Guid id, string CategoryName)
        {
            var category = _dbcontext.Categories.FirstOrDefault(x => x.Id == id);

            if (category is not null)
            {
                category.CategoryName = CategoryName;
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
