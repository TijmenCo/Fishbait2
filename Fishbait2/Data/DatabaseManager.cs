using Fishbait2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Data
{
    public class DatabaseManager
    {
        public string connectionString = "server=localhost;user id=Tijmen;persistsecurityinfo=True;database=fishbait";
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("select * from user"))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.id = reader.GetInt32(0);
                        user.username = reader.GetString(1);
                        user.password = reader.GetString(2);
                        user.mail = reader.GetString(3);

                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
