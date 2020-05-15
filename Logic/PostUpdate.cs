using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostUpdate
    {
        PostDBAccesLayer postDB = new PostDBAccesLayer();
        [Key]
        public int id { get; set; }
        public int postID { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public string image { get; set; }
        public List<PostUpdate> GetUpdatePosts()
        {
            List<PostUpdateDto> AllPostUpdates = new List<PostUpdateDto>();
            List<PostUpdate> RealAllPostUpdates = new List<PostUpdate>();
            AllPostUpdates = postDB.GetUpdatePosts();
            foreach (var item in AllPostUpdates)
            {
                PostUpdate post = new PostUpdate();
                post.id = item.id;
                post.postID = item.postID;
                post.title = item.title;
                post.description = item.description;
                post.image = item.image;
                RealAllPostUpdates.Add(post);
            }
            return (RealAllPostUpdates);
        }
        public void DeleteUpdate(int id)
        {
            postDB.DeleteUpdate(id);
        }
    }
    
}
