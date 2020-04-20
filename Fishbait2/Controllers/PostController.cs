using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fishbait2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class PostController : Controller
    {
        PostDBAccesLayer postDB = new PostDBAccesLayer();
        private readonly IWebHostEnvironment _environment;
        public PostController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        public IActionResult GoToPost(int id)
        {
            List<Post> DBPosts = postDB.GetPosts();
            List<Post> IDPosts = DBPosts.Where(x => x.id == id).ToList();
            Post model = IDPosts[0];
            return View("~/Views/Post/ViewPost.cshtml", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind] PostViewModel post)
        {
            Post realmodel = new Post();
            try
            {
                if (ModelState.IsValid)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "PostImages");
                    foreach (var file in post.files)
                    {
                        realmodel.image = file.FileName;
                        if (file.Length > 0)
                        {
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                    realmodel.id = post.id;
                    realmodel.title = post.title;
                    realmodel.description = post.description;
                    realmodel.tag = post.tag;

                    string resp = postDB.AddPost(realmodel);
                   
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
