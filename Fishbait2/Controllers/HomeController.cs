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
        public IActionResult Index()
        {
            PostDBAccesLayer postsDB = new PostDBAccesLayer();
            var posts = postsDB.GetPosts();
            return View(posts);
        }
    }
}