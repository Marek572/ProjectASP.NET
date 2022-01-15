using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
