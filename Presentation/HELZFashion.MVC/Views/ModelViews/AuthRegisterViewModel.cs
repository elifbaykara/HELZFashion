using HELZFashion.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HELZFashion.MVC.ModelViews
{
    public class AuthRegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTimeOffset BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}