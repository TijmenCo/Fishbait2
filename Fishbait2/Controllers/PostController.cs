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
        PostDBAccesLayer postDB = new PostDBAccesLayer();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePost()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        public IActionResult Create([Bind] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = postDB.AddPost(post);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
