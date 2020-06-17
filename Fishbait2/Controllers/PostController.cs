using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Factories;
using Fishbait2.Models;
using Logic;
using LogicFactories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost iPost;
        private readonly IPostUpdate iPostUpdate;
        private readonly INotification iNotification;

        private readonly IWebHostEnvironment _environment;
     
        public PostController(IWebHostEnvironment environment, IPost post, IPostUpdate postupdate, INotification notification)
        {
            iNotification = notification;
            iPost = post;
            iPostUpdate = postupdate; 
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
        public IActionResult Search(string result)
        {
            HomeViewModel home = new HomeViewModel();
            List<IPost> events = new List<IPost>();
            events = iPost.Search(result);

            if (!events.Any())
            {
                return View("~/Views/Post/ErrorPost.cshtml", home);
            }

            home.Posts = events;
            return View("~/Views/Home/Index.cshtml", home);
        }
        public IActionResult Filter(HomeViewModel home)
        {
            List<IPost> events = new List<IPost>();
            home.tag = home.tags.ToString();
            events = iPost.Filter(home.tag);

            if (!events.Any())
            {
                return View("~/Views/Post/ErrorPost.cshtml", home);
            }

            home.Posts = events;
            return View("~/Views/Home/Index.cshtml", home);
        }
        public IActionResult GoToPost(int id)
        {
            PostAndUpdateViewModel realmodel = new PostAndUpdateViewModel();
            PostViewModel realpostmodel = new PostViewModel();
            PostUpdateViewModel realupdatemodel = new PostUpdateViewModel();

          
            IPost currentmodel = iPost.GetPostID(id);

            realpostmodel.registered = iNotification.IsFollowed(id);
            realpostmodel.id = currentmodel.id;
            realpostmodel.title = currentmodel.title;
            realpostmodel.description = currentmodel.description;
            realpostmodel.tag = currentmodel.tag;
            realpostmodel.image = currentmodel.image;

            realmodel.postupdate = iPostUpdate.GetUpdateIDPosts(id);
            realmodel.post = realpostmodel;
            return View("~/Views/Post/ViewPost.cshtml", realmodel);
        }
        public IActionResult DeletePost(int id, bool registered)
        {
            iNotification.DeleteNotification(id, registered);
            string resp = iPost.DeletePost(id);
            if (resp == "Data deletion succes")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("DBError");
            }
        }
        public IActionResult DeleteUpdate(int id)
        {
            string resp = iPostUpdate.DeleteUpdate(id);
            if (resp == "Data deletion succes")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("DBError");
            }
        }
        public IActionResult EditPost(int id)
        {
            IPost model = iPost.GetEditID(id);
            PostViewModel realmodel = new PostViewModel();
            realmodel.id = model.id;
            realmodel.title = model.title;
            realmodel.description = model.description;
            realmodel.tag = model.tag;
            realmodel.image = model.image;

            return View("~/Views/Post/EditPost.cshtml", realmodel);
        }
        public async Task<IActionResult> EditPostChange(PostViewModel post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (post.files != null)
                    {
                        var uploads = Path.Combine(_environment.WebRootPath, "PostImages");
                        foreach (var file in post.files)
                        {
                            iPost.image = file.FileName;
                            if (file.Length > 0)
                            {
                                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                }
                            }
                        }
                    }
                 

                }
                else
                {
                    return View("~/Views/Post/EditPost.cshtml", post);
                }
            }
             
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            iPost.id = post.id;
            iPost.title = post.title;
            iPost.description = post.description;
            iPost.tag = post.tags.ToString();
            if (post.files == null)
            {
                iPost.image = post.image;
            }

            string resp = iPost.EditPost(iPost);
            if (resp == "Data save successful")
            {
                return RedirectToAction("GoToPost", "Post", new {id=post.id });
            }
            else
            {
                return View("DBError");
            }
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind] PostViewModel post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "PostImages");
                    foreach (var file in post.files)
                    {
                        iPost.image = file.FileName;
                        if (file.Length > 0)
                        {
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
                else { 
                return View("~/Views/Post/CreatePost.cshtml", post);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            iPost.id = post.id;
            iPost.title = post.title;
            iPost.description = post.description;
            iPost.tag = post.tags.ToString();

            string resp = iPost.AddPost(iPost);

            if (resp == "Data save successful")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("DBError");
            }
        }
        public IActionResult UpdatePost(int id, PostUpdateViewModel update)
        {
            update.postID = id;
            update.validated = false;
            return View("UpdatePost", update);
        }
        public async Task<IActionResult> CreateUpdatePost(PostUpdateViewModel update)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "PostImages");
                    foreach (var file in update.files)
                    {
                        iPostUpdate.image = file.FileName;
                        if (file.Length > 0)
                        {
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
                else
                {
                    update.validated = true;
                    return View("~/Views/Post/UpdatePost.cshtml", update);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            iPostUpdate.postID = update.postID;
            iPostUpdate.title = update.title;
            iPostUpdate.description = update.description;

            string resp = iPostUpdate.AddUpdatePost(iPostUpdate);
            if(resp == "Data save successful")
            {
                return RedirectToAction("GoToPost", "Post", new {id=update.postID});
            }
            else
            {
                return View("DBError");
            }
        }
    }
}
