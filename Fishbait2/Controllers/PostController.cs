using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fishbait2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            return View();
        }
    }
}