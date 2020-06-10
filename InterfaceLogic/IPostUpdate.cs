using System.Collections.Generic;

namespace Fishbait2.Models
{
    public interface IPostUpdate
    {
        string description { get; set; }
        int id { get; set; }
        string image { get; set; }
        int postID { get; set; }
        string title { get; set; }

        string AddUpdatePost(IPostUpdate model);
        void DeleteUpdate(int id);
        List<IPostUpdate> GetUpdateIDPosts(int id);
        List<IPostUpdate> GetUpdatePosts();
    }
}