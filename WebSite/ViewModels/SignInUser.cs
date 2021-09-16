using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.ViewModels
{
    /*Classe utilisée pour générer le formulaire d'inscription
     * nous permettant de définir les validations par Data-Annotations et d'ajouter un champ "Password Repeat" sans modifier la classe model
     */
    public class SignInUser
    {
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string Login { get; set; }
        [DataType("password")]
        [Display (Name = "Mot de passe")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Les mots de passe saisis ne correspondent pas")]
        [DataType("password")]
        [Display(Name ="Répétez le mot de passe")]
        public string PwdRepeat { get; set; }
    }
}