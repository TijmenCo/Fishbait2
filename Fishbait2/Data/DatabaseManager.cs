using Fishbait2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Data
{
    public class DatabaseManager
    {
        public string connectionString = "Server=localhost;Database=fishbait;Uid=Tijmen;Pwd=Suckmycred123";
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("select * from user", conn))
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
        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("select * from post", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        Post post = new Post();
                        post.id = reader.GetInt32(0);
                        post.accountID = reader.GetInt32(1);
                        post.username = reader.GetString(2);
                        post.title = reader.GetString(3);
                        post.description = reader.GetString(4);
                        post.image = reader.GetString(5);
                        if (!reader.IsDBNull(post.tag))
                        {
                            post.tag = reader.GetString(6);
                        }

                        posts.Add(post);
                    }
                }
            }
            return posts;
        }
    }
}
