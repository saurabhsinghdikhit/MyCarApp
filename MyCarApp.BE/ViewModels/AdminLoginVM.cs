using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class AdminLoginVM
    {
        [Required(ErrorMessage ="Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }
    }
}
