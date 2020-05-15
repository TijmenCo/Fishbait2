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
        private Post refPost;
        public HomeController()
        {
            refPost = new Post();
        }
        public IActionResult Index()
        {
            Post post = new Post();
            var posts = post.GetPosts();
            HomeViewModel home = new HomeViewModel();
            home.Posts = posts;
            return View(home);
        }
    }
}