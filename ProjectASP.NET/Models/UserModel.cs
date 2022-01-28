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
        [Key]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter your name!")]
        [MaxLength(20, ErrorMessage = "Your name cannot be longer than 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your surname!")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /*public Gender Gender { get; set; }*/

        public Role role { get; set; }

        [Required(ErrorMessage = "Enter your login!")]
        [MaxLength(20, ErrorMessage = "Your login cannot be longer than 20 characters")]
        public string Username { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Enter correct email!")]
        public string Email { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter your email again!")]
        [Compare("Email", ErrorMessage = "The Email and Confirm Email fields do not match.")]
        public string ConfirmEmail { get; set; }

        [Phone(ErrorMessage = "Your phone number have to contain only digits")]
        public string Phone { get; set; }

        public enum Gender
        {
            Male = 0,
            Female = 1,
            Nonspecified = 2
        }

        public enum Role
        {
            [Display(Name = "User")] Low = 1,
            [Display(Name = "Admin")] High = 2
        }
    }
}
