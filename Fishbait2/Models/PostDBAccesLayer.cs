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
        MySqlConnection con = new MySqlConnection("Server =localhost; Database=fishbait;Uid=Tijmen;Pwd=Suckmycred123");
        public string AddPost(Post post)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("add_post", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", post.title);
                cmd.Parameters.AddWithValue("@description", post.description);
                cmd.Parameters.AddWithValue("@image", post.image);
                cmd.Parameters.AddWithValue("pag", post.tag);
                con.Open();
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

