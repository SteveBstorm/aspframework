using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int AnneeDeSortie { get; set; }
    }
}