using DAL.Models;
using DALFactories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostUpdate : IPostUpdate
    {
        PostDBAccesLayer postDB = new PostDBAccesLayer();
        [Key]
        public int id { get; set; }
        public int postID { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public string image { get; set; }

        public string AddUpdatePost(IPostUpdate model)
        {
            IPostUpdateDto postUpdateDto = PostDBFactory.GetPost();
            postUpdateDto.id = model.id;
            postUpdateDto.title = model.title;
            postUpdateDto.description = model.description;
            postUpdateDto.image = model.image;
            postUpdateDto.tag = model.tag;
            string resp = postDB.AddPost(postDto);
            return (resp);
        }
        public List<IPostUpdate> GetUpdatePosts()
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
