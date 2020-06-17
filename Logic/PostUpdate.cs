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
        private readonly IPostDBAccesLayer postDB;
        public int id { get; set; }
        public int postID { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public string image { get; set; }
        public PostUpdate(IPostDBAccesLayer _dependancy)
        {
            postDB = _dependancy; 
        }
        public string AddUpdatePost(IPostUpdate model) 
        {
            IPostUpdateDto postUpdateDto = PostDBFactory.GetPostUpdate(); 
            postUpdateDto.id = model.id;
            postUpdateDto.postID = model.postID;
            postUpdateDto.title = model.title;
            postUpdateDto.description = model.description;
            postUpdateDto.image = model.image;
            string resp = postDB.AddUpdatePost(postUpdateDto);
            return (resp);
        }
        public List<IPostUpdate> GetUpdatePosts()
        {
            List<IPostUpdateDto> AllPostUpdates = new List<IPostUpdateDto>();
            List<IPostUpdate> RealAllPostUpdates = new List<IPostUpdate>();
            AllPostUpdates = postDB.GetUpdatePosts();
            foreach (var item in AllPostUpdates)
            {
                PostUpdate post = new PostUpdate(postDB);
                post.id = item.id;
                post.postID = item.postID;
                post.title = item.title;
                post.description = item.description;
                post.image = item.image;
                RealAllPostUpdates.Add(post);
            }
            return (RealAllPostUpdates);
        }
        public string DeleteUpdate(int id) 
        {
            string resp = postDB.DeleteUpdate(id);
            return (resp);
        }
 
        public List<IPostUpdate> GetUpdateIDPosts(int id)
        {
            List<IPostUpdate> DBUpdatePosts = GetUpdatePosts();
            List<IPostUpdate> IDUpdatePosts = DBUpdatePosts.Where(x => x.postID == id).ToList();
            return IDUpdatePosts;
        }
    }

}
