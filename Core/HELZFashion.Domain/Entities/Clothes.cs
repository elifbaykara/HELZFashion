using HELZFashion.Domain.Common;
using HELZFashion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Entities
{
    public class Clothes : EntityBase<Guid> 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public string ImageUrl { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public ColorType ColorType { get; set; }
        public Gender Gender { get; set; }
        public SizeType SizeType { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
