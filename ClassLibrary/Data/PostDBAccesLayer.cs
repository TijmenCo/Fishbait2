//using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostDBAccesLayer : IPostDBAccesLayer
    {
        MySqlConnection con = new MySqlConnection("Server=localhost; Database=fishbait;Uid=Tijmen;Pwd=Suckmycred123");
        public string AddPost(IPostDto post)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO post (title, description, tag, image) VALUES('" + post.title + "', '" + post.description + "', '" + post.tag + "', '" + post.image + "');";
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
        public List<IPostDto> GetPosts()
        {
            List<IPostDto> posts = new List<IPostDto>();

            using (MySqlCommand query = new MySqlCommand("select * from post", con))
            {
                con.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    PostDto post = new PostDto();
                    post.id = reader.GetInt32(0);
                    post.title = reader.GetString(1);
                    post.description = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        post.image = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        post.tag = reader.GetString(4);
                    }
                    posts.Add(post);
                }
                con.Close();
            }

            return posts;
        }
        public void DeletePost(int id)
        {
            using (MySqlCommand query = new MySqlCommand("DELETE FROM post WHERE id=@id", con))
            {
                MySqlParameter param = new MySqlParameter("@id", id);
                query.Parameters.Add(param);
                con.Open();
                var reader = query.ExecuteReader();
            }
            con.Close();
        }
        public void DeleteUpdate(int id)
        {
            using (MySqlCommand query = new MySqlCommand("DELETE FROM updatepost WHERE id=@id", con))
            {
                MySqlParameter param = new MySqlParameter("@id", id);
                query.Parameters.Add(param);
                con.Open();
                var reader = query.ExecuteReader();
            }
            con.Close();
        }
        public string EditPost(IPostDto post)
        {
            try
            {
                con.Open();
                string sql = "UPDATE post SET title = '" + post.title + "', description = '" + post.description + "', tag = '" + post.tag + "', image = '" + post.image + "' WHERE id= '" + post.id + "'";
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
        public string AddUpdatePost(IPostUpdateDto post)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO updatepost (postID, title, description, image) VALUES('" + post.postID + "', '" + post.title + "', '" + post.description + "', '" + post.image + "');";
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
        public List<IPostUpdateDto> GetUpdatePosts()
        {
            List<IPostUpdateDto> updateposts = new List<IPostUpdateDto>();

            using (MySqlCommand query = new MySqlCommand("select * from updatepost", con))
            {
                con.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    PostUpdateDto post = new PostUpdateDto();
                    post.id = reader.GetInt32(0);
                    post.postID = reader.GetInt32(1);
                    post.title = reader.GetString(2);
                    post.description = reader.GetString(3);
                    if (!reader.IsDBNull(3))
                    {
                        post.image = reader.GetString(4);
                    }
                    updateposts.Add(post);
                }
            }

            return updateposts;
        }

    }
}



