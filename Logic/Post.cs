using System;
using Fishbait2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace Fishbait2.Models
{
    public class Post
    {
        PostDBAccesLayer postDB = new PostDBAccesLayer();

        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
       
        public string image { get; set; }
        public string tag { get; set; }
        public string AddPost(Post model)
        {
            PostDto realmodel = new PostDto();
            realmodel.id = model.id;
            realmodel.title = model.title;
            realmodel.description = model.description;
            realmodel.image = model.image;
            realmodel.tag = model.tag;
            string resp = postDB.AddPost(realmodel);
            return (resp);
        }
        public List<Post> GetPosts()
        {
            List<PostDto> AllPosts = new List<PostDto>();
            List<Post> RealAllPosts = new List<Post>();
            AllPosts = postDB.GetPosts();
            foreach (var item in AllPosts)
            {
                Post post = new Post();
                post.id = item.id;
                post.title = item.title;
                post.description = item.description;
                post.image = item.image;
                post.tag = item.tag;
                RealAllPosts.Add(post);
            }
            return (RealAllPosts);
        }
        public void DeletePost(int id)
        {
            postDB.DeletePost(id);
        }
        public string EditPost(Post model)
        {
            PostDto realmodel = new PostDto();
            realmodel.id = model.id;
            realmodel.title = model.title;
            realmodel.description = model.description;
            realmodel.image = model.image;
            realmodel.tag = model.tag;
            string resp = postDB.EditPost(realmodel);
            return (resp);
        }
    
    }

   
}
