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
        private IWebHostEnvironment environment;
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
                    var uploads = Path.Combine(environment.WebRootPath, "Images");
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
                    realmodel.image = post.image;
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
