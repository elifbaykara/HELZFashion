using HELZFashion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HELZFashion.Domain.Common;

namespace HELZFashion.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        public string ShippingAddress { get; set; }
        public PaymentMethod Payment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public Basket OrderItems { get; set; }

    }
}