using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fishbait2.Models;
using Logic;
using LogicFactories;
using Microsoft.AspNetCore.Mvc;

namespace Fishbait2.Controllers
{
    public class NotificationController : Controller
    {
        private INotification iNotification;
        public NotificationController()
        {
            iNotification = NotificationFactory.GetNotification();
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
    }
}