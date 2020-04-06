using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fishbait2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to put in an username!")]
        [Display(Name = "Username:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You have to enter a password!")]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You have to enter an e-mail!")]
        [Display(Name = "E-Mail:")]
        public string Mail { get; set; }
    }
}
