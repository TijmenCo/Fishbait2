using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fishbait2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            var posts = databaseManager.GetPosts();
            return View(posts);
        }
    }
}