//using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System.Collections.Generic;

namespace Fishbait2.Models
{
    public interface IPostDBAccesLayer
    {
        string AddPost(PostDto post);
        string AddUpdatePost(PostUpdateDto post);
        void DeletePost(int id);
        void DeleteUpdate(int id);
        string EditPost(PostDto post);
        List<PostDto> GetPosts();
        List<PostUpdateDto> GetUpdatePosts();
    }
}