using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Services;
using WebSite.Utils;

namespace WebSite.Areas.Admin.Controllers
{
    //Appel l'attribut custom mis en place dans /Utils
    //Il se charge de vérifier le statut de la connexion ainsi que le role utilisateur
    //Dans le cas ou l'un ou l'autre ne serait pas valide, s'occupe de rediriger vers la page d'accueil
    [AdminRequiredAttribute]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            //Test si l'utilisateur est connecté et s'il est admin
            //dans le cas contraire, le redirige vers l'acceuil du site principal
            //Mis en commentaire pour laisser l'attribut custom prendre le relais

            //if (SessionTool.user != null && SessionTool.user.isAdmin == true)
            //{
                return View();
            //}
            //else return RedirectToAction("../");
        }

        public ActionResult ListFilm()
        {
                return View(FilmRepoAsp.Instance.GetAll());
            
        }

        public ActionResult DetailFilm(int id)
        {
            
                return View(FilmRepoAsp.Instance.GetOne(id));
           
        }
        [HttpGet]
        public ActionResult EditFilm(int id)
        {
            
                return View(FilmRepoAsp.Instance.GetOne(id));
            
        }

        public ActionResult EditFilm(Film f)
        {
            if (ModelState.IsValid)
            {
                FilmRepoAsp.Instance.Update(f);
                return RedirectToAction("ListFilm");
            }
            else return View(f);
        }

        [HttpGet]
        public ActionResult CreateFilm()
        {
            return View(new Film());
            
        }

        public ActionResult CreateFilm(Film f)
        {
            if (ModelState.IsValid)
            {
                FilmRepoAsp.Instance.Create(f);
                return RedirectToAction("ListFilm");
            }
            else return View(f);
        }

        public ActionResult ListUser()
        {
            
                return View(UserRepoAsp.Instance.GetAll());

        }

        //Permet de switcher le statut d'un utilisateur Actif/Inactif
        public ActionResult ToggleUser(int id)
        {
            User uUpdate = UserRepoAsp.Instance.GetOne(id);
            uUpdate.isActive = !uUpdate.isActive;
            UserRepoAsp.Instance.Update(uUpdate);
            return RedirectToAction("ListUser");
        }

        //Permet de donner/retirer les droits admin à un utilisateur
        public ActionResult ToggleAdmin(int id)
        {
            User uUpdate = UserRepoAsp.Instance.GetOne(id);
            uUpdate.isAdmin = !uUpdate.isAdmin;
            UserRepoAsp.Instance.Update(uUpdate);
            return RedirectToAction("ListUser");
            
        }
    }
}