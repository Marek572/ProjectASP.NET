using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Models
{
    public class UserModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your name!")]
        [MaxLength(20, ErrorMessage = "Your name cannot be longer than 20 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter your surname!")]
        public string surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }

        public Gender gender { get; set; }

        [Required(ErrorMessage = "Enter your login!")]
        [MaxLength(20, ErrorMessage = "Your login cannot be longer than 20 characters")]
        public string login { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Enter correct email!")]
        public string email { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter your email again!")]
        [Compare("email", ErrorMessage = "The Email and Confirm Email fields do not match.")]
        public string confirmEmail { get; set; }

        [Phone(ErrorMessage = "Your phone number have to contain only digits")]
        public string phone { get; set; }

        
        [Required(ErrorMessage = "Enter your password!")]
        [MinLength(8, ErrorMessage = "Your name cannot be shorter than 8 characters")]
        [DataType(DataType.Password)]
        public string pass { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter your password again!")]
        [Compare("pass", ErrorMessage = "Passwords are not the same!")]
        [DataType(DataType.Password)]
        public string confirmPass { get; set; }

        public enum Gender
        {
            Male = 0,
            Female = 1,
            Nonspecified = 2
        }
    }
}
