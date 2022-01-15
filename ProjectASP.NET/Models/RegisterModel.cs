using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter your name!")]
        [MaxLength(20, ErrorMessage = "Your name cannot be longer than 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your surname!")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Phone(ErrorMessage = "Your phone number have to contain only digits")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter your login!")]
        [MaxLength(20, ErrorMessage = "Your login cannot be longer than 20 characters")]
        public string Username { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Enter correct email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        [MinLength(8, ErrorMessage = "Your password cannot be shorter than 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter your password again!")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }
    }
}
