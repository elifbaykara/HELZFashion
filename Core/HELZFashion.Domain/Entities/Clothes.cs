using HELZFashion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Entities
{
    public class Clothes
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public string ImageUrl { get; set; }
        public Brand Brand { get; set; }
        public ColorType ColorType { get; set; }
        public Gender Gender { get; set; }
        public SizeType SizeType { get; set; }
        public Category Category { get; set; }
    }
}
