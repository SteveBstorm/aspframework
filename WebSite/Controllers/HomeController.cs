using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.ViewModels;
using WebSite.Services;
using WebSite.Utils;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inscription()
        {
            return View(new SignInUser());
        }
        [HttpPost]
        public ActionResult Inscription(SignInUser u)
        {
            if (ModelState.IsValid)
            {
                if (!(UserRepoAsp.Instance.GetAll().Select(x => x.Login).FirstOrDefault() == u.Login))
                {
                    UserRepoAsp.Instance.Create(u.SignInToUser());
                    SessionTool.message = "L'inscription s'est déroulée avec succès !";
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Nom d'utilisateur déjà utilisé";
                    return View(u);
                } 
                   
                
            }
            else return View(u);
        }

        public ActionResult SignOut()
        {
            SessionTool.user = null;
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View(new LoginUser());
        }
        [HttpPost]
        public ActionResult Login(LoginUser lu)
        {
            if (ModelState.IsValid)
            {

                foreach (User u in UserRepoAsp.Instance.GetAll().Where(x => x.Login == lu.Login))
                {
                    if (u.isActive)
                    {

                        if (lu.Login == u.Login && lu.Password == u.Pwd)
                        {
                            SessionTool.user = u;
                            SessionTool.message = "Connexion Réussie";
                            
                            return RedirectToAction("Index");
                        }

                        else
                        {
                            ViewBag.ErrorMessage = "Login ou mot de passe Incorrect";
                            return View(lu);
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Votre compte est desactivé";
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else return View(lu);

        }



        public ActionResult ListFilm()
        {
            return View(FilmRepoAsp.Instance.GetAll());
        }
        [AuthRequiredAttribute]
        public ActionResult FilmDetails(int id)
        {
            
            if (SessionTool.user != null)
                return View(FilmRepoAsp.Instance.GetOne(id));
            else return RedirectToAction("Index");
            
        }
    }
}