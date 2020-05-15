using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Factories;
using Fishbait2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class PostController : Controller
    {
        private IPost iPost;
        private IPostUpdate iPostUpdate;
        
        private readonly IWebHostEnvironment _environment;
     
        public PostController(IWebHostEnvironment environment)
        {
            iPost = PostFactory.GetPost();
            iPostUpdate = PostFactory.GetPostUpdate();
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
            List<Post> events = new List<Post>();
            events = refPost.GetPosts().Where(s => s.title.Contains(result)).ToList();
            if (!events.Any())
            {
                return View("~/Views/Post/ErrorPost.cshtml");
            }
            home.Posts = events;
            return View("~/Views/Home/Index.cshtml", home);
        }
        public IActionResult Filter(HomeViewModel home)
        {
            List<Post> events = new List<Post>();
            home.tag = home.tags.ToString();
            events = refPost.GetPosts().Where(s => s.tag.Equals(home.tag)).ToList();
            home.Posts = events;
            return View("~/Views/Home/Index.cshtml", home);
        }
        public IActionResult GoToPost(int id)
        {
            PostAndUpdateViewModel realmodel = new PostAndUpdateViewModel();
            PostViewModel realpostmodel = new PostViewModel();
            PostUpdateViewModel realupdatemodel = new PostUpdateViewModel();

            List<Post> DBPosts = refPost.GetPosts();
            List<Post> IDPosts = DBPosts.Where(x => x.id == id).ToList();
            Post currentmodel = IDPosts[0];

            realpostmodel.id = currentmodel.id;
            realpostmodel.title = currentmodel.title;
            realpostmodel.description = currentmodel.description;
            realpostmodel.tag = currentmodel.tag;
            realpostmodel.image = currentmodel.image;

            List<PostUpdate> DBUpdatePosts = refPostUpdate.GetUpdatePosts();
            List<PostUpdate> IDUpdatePosts = DBUpdatePosts.Where(x => x.postID == id).ToList();
            PostUpdate currentupdatemodel = DBUpdatePosts[0];

            realupdatemodel.id = currentupdatemodel.id;
            realupdatemodel.postID = currentupdatemodel.postID;
            realupdatemodel.title = currentupdatemodel.title;
            realupdatemodel.description = currentupdatemodel.description;
            realupdatemodel.image = currentupdatemodel.image;

            List<PostUpdateViewModel> RealUpdateList = new List<PostUpdateViewModel>();
            RealUpdateList.Add(realupdatemodel);


            realmodel.postupdate = IDUpdatePosts;
            realmodel.post = realpostmodel;
            return View("~/Views/Post/ViewPost.cshtml", realmodel);
        }
        public IActionResult DeletePost(int id)
        {
            refPost.DeletePost(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteUpdate(int id)
        {
            refPostUpdate.DeleteUpdate(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditPost(int id)
        {
            List<Post> DBPosts = refPost.GetPosts();
            List<Post> IDPosts = DBPosts.Where(x => x.id == id).ToList();
            Post model = IDPosts[0];
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
            Post realmodel = new Post();
            try
            {
                if (ModelState.IsValid)
                {
                    if (post.files != null)
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
                    }
                    realmodel.id = post.id;
                    realmodel.title = post.title;
                    realmodel.description = post.description;
                    realmodel.tag = post.tag;
                    if (post.files == null)
                    {
                        realmodel.image = post.image;
                    }

                    string resp = refPost.EditPost(realmodel);

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index", "Home");
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
                    iPost.id = post.id;
                    iPost.title = post.title;
                    iPost.description = post.description;
                    iPost.tag = post.tags.ToString();

                    string resp = iPost.AddPost(iPost);

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult UpdatePost(int id, PostUpdateViewModel update)
        {
            update.postID = id;
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
                    iPostUpdate.postID = update.postID;
                    iPostUpdate.title = update.title;
                    iPostUpdate.description = update.description;

                    string resp = iPostUpdate.AddUpdatePost(iPostUpdate);

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
