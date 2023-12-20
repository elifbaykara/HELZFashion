using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HELZFashion.Domain.Common;
using HELZFashion.Domain.Enums;

namespace HELZFashion.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string CategoryName {  get; set; }
        //public Brand Brand  { get; set; }
        public Gender Gender{ get; set; }
        public ICollection<Clothes> Clothes { get; set; }
    }
}
