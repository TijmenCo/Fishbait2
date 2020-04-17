using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostDBAccesLayer
    {
        MySqlConnection con = new MySqlConnection("Server=localhost; Database=fishbait;Uid=Tijmen;Pwd=Suckmycred123");
        public string query = "INSERT INTO post (title, description, tag) VALUES (@title,@description,@tag);";
        public string AddPost(Post post)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO post (title, description, tag) VALUES('" + post.title + "', '" + post.description + "', '" + post.tag + "');";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}

