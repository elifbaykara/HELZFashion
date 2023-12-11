using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HELZFashion.Domain.Common;

namespace HELZFashion.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string ProductName { get; set; }

    }
}
