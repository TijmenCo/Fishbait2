//using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System.Collections.Generic;

namespace Fishbait2.Models
{
    public interface IPostDBAccesLayer
    {
        string AddPost(IPostDto post);
        string AddUpdatePost(IPostUpdateDto post);
        string DeletePost(int id);
        void DeleteUpdate(int id);
        string EditPost(IPostDto post);
        List<IPostDto> GetPosts();
        List<IPostUpdateDto> GetUpdatePosts();
    }
}