using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fishbait2.Data;
using Fishbait2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost refPost;
       // private Post refPost;
        public HomeController(IPost post)
        {
            refPost = post;
        }
        public IActionResult Index()
        {
            var posts = refPost.GetPosts();
            HomeViewModel home = new HomeViewModel();
            home.Posts = posts;
            return View(home);
        }
    }
}