using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALFilm.Repository;
using D = DALFilm.Services;
using DM = DALFilm.Data;
using WebSite.Models;
using WebSite.Utils;

namespace WebSite.Services
{
    public class UserRepoAsp : IRepository<User>
    {
        private static IRepository<User> _instance;

        public static IRepository<User> Instance
        {
            get { return _instance ?? (_instance = new UserRepoAsp()); }
        }

        private UserRepoAsp()
        {
            _dalService = D.UserRepo.Instance;
        }

        private IRepository<DM.User> _dalService;

        


        public void Create(User t)
        {
            _dalService.Create(t.ToGlobal());
        }

        public void Delete(int id)
        {
            _dalService.Delete(id);
        }

        public List<User> GetAll()
        {
            return _dalService.GetAll().Select(x => x.ToLocal()).ToList();
        }

        public User GetOne(int id)
        {
            return _dalService.GetOne(id).ToLocal();
        }

        public void Update(User t)
        {
            _dalService.Update(t.ToGlobal());
        }
    }
}