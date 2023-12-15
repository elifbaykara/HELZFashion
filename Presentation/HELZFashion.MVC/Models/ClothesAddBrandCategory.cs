using HELZFashion.Domain.Entities;

namespace HELZFashion.MVC.Models
{
    public class ClothesAddBrandCategory
    {
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}
