using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Utils
{
    public class SessionTool
    {
        //Mise en place d'une variable session prenant un objet de Type User

        public static User user
        {
            get { return (User)HttpContext.Current.Session["user"]; }
            set { HttpContext.Current.Session["user"] = value; }
        }

        //Variable session permettant de passer des messages d'une classe/vue à une autre
        public static string message
        {
            get { return (string)HttpContext.Current.Session["message"]; }
            set { HttpContext.Current.Session["message"] = value; }
        }

        //Methode session vidant le contenu du message
        public static void setMessageNull()
        {
            message = "";
        }
    }
}