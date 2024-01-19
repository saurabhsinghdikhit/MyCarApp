using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class UserRegistrationVM
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Compare Password is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm Password does not matched")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name should be between 3-50 character", MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        
    }
}
