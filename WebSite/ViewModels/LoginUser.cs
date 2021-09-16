using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.ViewModels
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Nom utilisateur")]
        public string Login { get; set; }
        [Required]
        [DataType("password")]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}