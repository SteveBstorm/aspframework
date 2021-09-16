using DALFilm.Data;
using DALFilm.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFilm.Services
{
    public class FilmRepo : IRepository<Film>
    {
       

        private static IRepository<Film> _instance;

        public static IRepository<Film> Instance
        {
            get
            {
                return _instance ?? (_instance = new FilmRepo());
            }
        }

        private SqlConnection _connection;
        private string Cs = ConfigurationManager.ConnectionStrings["AspExo"].ConnectionString;

        private FilmRepo()
        {
            _connection = new SqlConnection(Cs);
            _connection.Open();
        }

        


        public void Create(Film t)
        {
            
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Film (Titre, Description, Annee) VALUES (@Titre, @Desc, @Annee)";
            cmd.Parameters.AddWithValue("Titre", t.Titre);
            cmd.Parameters.AddWithValue("Desc", t.Description);
            cmd.Parameters.AddWithValue("Annee", t.AnneeDeSortie);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Film WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Film> GetAll()
        {
            List<Film> filmlist = new List<Film>();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Film";
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    filmlist.Add(new Film
                    {
                        Id = (int)dr["Id"],
                        Titre = dr["Titre"].ToString(),
                        Description = dr["Description"].ToString(),
                        AnneeDeSortie = (int)dr["Annee"]
                    });
                }
            }
            return filmlist;
        }

        public Film GetOne(int id)
        {
            Film f = new Film();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Film WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read()) 
                {

                    f.Id = (int)dr["Id"];
                    f.Titre = dr["Titre"].ToString();
                    f.Description = dr["Description"].ToString();
                    f.AnneeDeSortie = (int)dr["Annee"];
                };
            }
            return f;

        }
           


        public void Update(Film t)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "UPDATE Film SET Titre = @titre, Annee = @annee, Description = @desc WHERE Id = @id";
            cmd.Parameters.AddWithValue("titre", t.Titre);
            cmd.Parameters.AddWithValue("annee", t.AnneeDeSortie);
            cmd.Parameters.AddWithValue("desc", t.Description);
            cmd.Parameters.AddWithValue("id", t.Id);
            cmd.ExecuteNonQuery();
        }
    }
}
