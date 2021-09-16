using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFilm.Data
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
