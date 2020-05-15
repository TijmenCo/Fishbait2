using System.Collections.Generic;

namespace Fishbait2.Models
{
    public interface IPost
    {
        string description { get; set; }
        int id { get; set; }
        string image { get; set; }
        string tag { get; set; }
        string title { get; set; }

     //   string AddPost(Post model);
       void DeletePost(int id);
     //   string EditPost(Post model);
       List<Post> GetPosts();
    }
}