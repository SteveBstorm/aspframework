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
    public class FilmRepoAsp : IRepository<Film>
    {

        private static IRepository<Film> _instance;

        public static IRepository<Film> Instance
        {
            get { return _instance ?? (_instance = new FilmRepoAsp()); }
        }

        private FilmRepoAsp()
        {
            _dalService = D.FilmRepo.Instance;
        }

        private IRepository<DM.Film> _dalService;



        public void Create(Film t)
        {
            _dalService.Create(t.ToGlobal());
        }

        public void Delete(int id)
        {
            _dalService.Delete(id);
        }

        public List<Film> GetAll()
        {
            return _dalService.GetAll().Select(x => x.ToLocal()).ToList();
        }

        public Film GetOne(int id)
        {
            return _dalService.GetOne(id).ToLocal();
        }

        public void Update(Film t)
        {
            _dalService.Update(t.ToGlobal());
        }
    }
}