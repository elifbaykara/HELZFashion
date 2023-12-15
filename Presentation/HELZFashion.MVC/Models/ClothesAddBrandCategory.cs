using HELZFashion.Domain.Entities;

namespace HELZFashion.MVC.Models
{
    public class ClothesAddBrandCategory
    {
        public Clothes Clothes { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}