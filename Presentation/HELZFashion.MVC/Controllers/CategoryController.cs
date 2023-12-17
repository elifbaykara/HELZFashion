﻿using HELZFashion.Domain.Entities;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public IActionResult Add(string categoryName)
        {
            Category category = new();
            category.CategoryName = categoryName;
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

        //Update
        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Update([FromRoute] string id)
        {
            var category = _dbcontext.Categories.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            return View(category);
        }

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


    }
}
