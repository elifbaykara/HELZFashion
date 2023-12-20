using HELZFashion.Domain.Entities;
using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult DeleteBrand(string id)
    {
        var brand = _context.Brands.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

        _context.Brands.Remove(brand);

        _context.SaveChanges();

        return RedirectToAction("index");
    }
}