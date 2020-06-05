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
            try
            {
                iNotification.AddFollow(iNotification);
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GetNotifications() //WIP
        {
            List<INotification> follows = new List<INotification>();
            follows = iNotification.GetNotifications().Where(s => s.accountID == 1).ToList();
            return View();
        }
        public IActionResult SendNotification(int id) //WIP
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
    }
}