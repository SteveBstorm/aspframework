using DALFilm.Data;
using DALFilm.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DALFilm.Services
{
    public class UserRepo : IRepository<User>
    {
        private static IRepository<User> _instance;

        public static IRepository<User> Instance
        {
            get
            {
                return _instance ?? (_instance = new UserRepo());
            }
        }

        private SqlConnection _connection;

        private UserRepo()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-RGPQP6I\TFTIC2014;Initial Catalog=ExoAspNet;User ID=sa;Password=steve1983");
            _connection.Open();
        }


        public void Create(User t)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Users (login, pwd) VALUES (@login, @pwd)";
            cmd.Parameters.AddWithValue("login", t.Login);
            cmd.Parameters.AddWithValue("pwd", t.Pwd);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public List<User> GetAll()
        {
            List<User> userlist = new List<User>();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users";
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    userlist.Add( new User
                    {
                        Id = (int)dr["Id"],
                        Login = dr["Login"].ToString(),
                        Pwd = dr["Pwd"].ToString(),
                        isAdmin = (bool)dr["IsAdmin"],
                        isActive = (bool)dr["IsActive"]
                    });
                }
            }
            return userlist;
        }

        public User GetOne(int id)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);
            User u = new User();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {

                    u.Id = (int)dr["Id"];
                    u.Login = dr["Login"].ToString();
                    u.Pwd = dr["Pwd"].ToString();
                    u.isAdmin = (bool)dr["IsAdmin"];
                    u.isActive = (bool)dr["IsActive"];
                    
                }
            }
            return u;
            
        }

        public void Update(User t)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = "UPDATE Users SET Login = @login, Pwd = @pwd, IsAdmin = @isAdmin, IsActive = @isActive WHERE Id = @id";
            cmd.Parameters.AddWithValue("login", t.Login);
            cmd.Parameters.AddWithValue("pwd", t.Pwd);
            cmd.Parameters.AddWithValue("isAdmin", t.isAdmin);
            cmd.Parameters.AddWithValue("isActive", t.isActive);
            cmd.Parameters.AddWithValue("id", t.Id);

            cmd.ExecuteNonQuery();
        }
    }
}
