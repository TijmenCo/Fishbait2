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

        bool AddPost(IPost model);
        bool DeletePost(int id);
        bool EditPost(IPost model);
        List<IPost> Filter(string tag);
        IPost GetEditID(int id);
        IPost GetPostID(int id);
        List<IPost> GetPosts();
        List<IPost> Search(string result);
    }
}