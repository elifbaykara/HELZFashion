using HELZFashion.Domain.Entities;
using HELZFashion.MVC.Models;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HELZFashion.MVC.Controllers;


public class BrandController : Controller
{
    private readonly TeamHELZDbContext _context;

    public BrandController(TeamHELZDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var brands = _context.Brands.ToList();
        return View(brands);
    }
    [HttpGet]
    public IActionResult AddBrand()
    {
        return View();
    }


    [HttpPost]
    public IActionResult AddBrand(string brandName, string brandDescription)
    {
        var brand = new Brand()
        {
            Id = Guid.NewGuid(),
            Name = brandName,
            Description = brandDescription,
            CreatedOn = DateTime.UtcNow,
            IsDeleted = false,
            CreatedByUserId = "LivanurErdem",

        };

        _context.Brands.Add(brand);

        _context.SaveChanges();

        return View();
    }

    [HttpGet]
    public IActionResult Delete(string id)
    { 

        var brand = _context.Brands.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

        _context.Brands.Remove(brand);

        brand.DeletedByUserId = "LivanurErdem";
        brand.DeletedOn = DateTime.UtcNow;
        brand.IsDeleted = true;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Update(Guid id)
    {

        var brands = _context.Brands.ToList();

        var upClothes = new ClothesAddBrandCategory
        {
          Brands = brands 
        };

        return View(upClothes);
    }
    [HttpPost]
    public IActionResult Update(Guid id, string Name, string Description)
    {
        var brand = _context.Brands.FirstOrDefault(x => x.Id == id);

        if (brand != null)
        {
            brand.Name = Name;
            brand.Description = Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

}