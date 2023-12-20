using HELZFashion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Entities
{
    public class Basket : EntityBase<Guid>
    {
        public Order Order { get; set; }
        public List<BasketItem> Items { get; set; }

    }
    public class BasketItem : EntityBase<Guid>
    {
        public Clothes Clothes { get; set; }
        public int Quantity { get; set; }
    }
}

