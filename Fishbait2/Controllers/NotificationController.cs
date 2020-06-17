using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fishbait2.Models;
using Fishbait2.ViewModels;
using Logic;
using LogicFactories;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotification iNotification;
        public NotificationController(INotification _dependancy)
        {
            iNotification = _dependancy;
        }
        public IActionResult Follow(int postid, int accountid)
        {
            iNotification.accountID = accountid;
            iNotification.postID = postid;    
            string resp = iNotification.AddFollow(iNotification);
            if (resp == "Data save successful")
            {
                return RedirectToAction("GoToPost", "Post", new { id = postid });
            }
            else
            {
                return View("DBError");
            }

        }

        public IActionResult GetNotifications() 
        {
            List<INotification> follows = new List<INotification>();
            follows = iNotification.GetNotifications().Where(s => s.accountID == 1).ToList();
            return View();
        }
        /*
        public IActionResult SendNotification(int id) 
        {
            NotificationViewModel realmodel = new NotificationViewModel();
            List<INotification> follows = new List<INotification>();
            follows = iNotification.GetNotifications().Where(s => s.postID == id).ToList();
            foreach(var notification in follows)
            {
                if(notification.accountID == 1 )
                {
                    //
                }
            }
            return View();
        }
        */
 
    }
}