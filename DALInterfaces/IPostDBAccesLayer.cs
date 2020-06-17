//using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System.Collections.Generic;

namespace Fishbait2.Models
{
    public interface IPostDBAccesLayer
    {
        bool AddPost(IPostDto post);
        bool AddUpdatePost(IPostUpdateDto post);
        bool DeletePost(int id);
        bool DeleteUpdate(int id);
        bool EditPost(IPostDto post);
        List<IPostDto> GetPosts();
        List<IPostUpdateDto> GetUpdatePosts();
    }
}