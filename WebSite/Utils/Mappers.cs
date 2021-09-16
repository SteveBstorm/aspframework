using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using D = DALFilm.Data;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Utils
{
    public static class Mappers
    {
        public static User ToLocal(this D.User u)
        {
            return new User
            {
                Id = u.Id,
                Login = u.Login,
                Pwd = u.Pwd,
                isAdmin = u.isAdmin,
                isActive = u.isActive
            };
        }

        public static D.User ToGlobal(this User u)
        {
            return new D.User
            {
                Id = u.Id,
                Login = u.Login,
                Pwd = u.Pwd,
                isAdmin = u.isAdmin,
                isActive = u.isActive
            };
        }

        public static Film ToLocal(this D.Film u)
        {
            return new Film
            {
                Id = u.Id,
                Titre = u.Titre,
                AnneeDeSortie = u.AnneeDeSortie,
                Description = u.Description
            };
        }

        public static D.Film ToGlobal(this Film u)
        {
            return new D.Film
            {
                Id = u.Id,
                Titre = u.Titre,
                AnneeDeSortie = u.AnneeDeSortie,
                Description = u.Description
            };
        }

        public static User SignInToUser(this SignInUser u)
        {
            return new User
            {
                Login = u.Login,
                Pwd = u.Password
            }; 
        }
    }
}