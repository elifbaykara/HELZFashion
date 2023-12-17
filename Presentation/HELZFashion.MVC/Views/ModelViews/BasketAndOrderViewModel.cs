using HELZFashion.Domain.Entities;
using HELZFashion.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HELZFashion.MVC.ViewModels
{
    public class BasketAndOrderViewModel
    {
        public Basket Basket { get; set; }

        [Required(ErrorMessage = "Shipping Address is required.")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Payment Method is required.")]
        public PaymentMethod Payment { get; set; }
    }
}
