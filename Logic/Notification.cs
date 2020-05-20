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
        private List<INotification> notifications { get; set; }
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
        public List<INotification> GetNotifications() //DONE
        {
            notifications = new List<INotification>();
            List<INotificationDto> AllNotifications = notificationDB.GetNotifications(); //Returnt alle posts van de database
            foreach (INotificationDto model in AllNotifications)
            {
                notifications.Add(new Notification() //Zet alle IPostDtos om in IPost
                {
                    id = model.id,
                    postID = model.postID,
                    accountID = model.accountID
                });
            }
            return (notifications);
        }
    }
}
