using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pwd { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }
}