using DAL.Data;
using DAL.Models;
using DALFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Notification : INotification
    {
        private INotificationDBAccesLayer notificationDB;
        public int id { get; set; }
        public int accountID { get; set; }
        public int postID { get; set; }
        public Notification()
        {
            notificationDB = NotificationDBFactory.GetNotificationDB();
        }
        public string AddFollow(INotification model) 
        {
            INotificationDto notificationDto = NotificationDBFactory.GetNotification();
            notificationDto.accountID = model.accountID;
            notificationDto.postID = model.postID;
            string resp = notificationDB.AddFollow(notificationDto);
            return (resp);
        }
    }
}
