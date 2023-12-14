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
        public string ProductName { get; set; }
      

        public Brand Brand  { get; set; }
        public ColorType ColorType { get; set; }
        public Gender Gender{ get; set; }
        public SizeType SizeType { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
