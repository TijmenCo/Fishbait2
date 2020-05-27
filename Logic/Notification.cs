using DAL.Data;
using DAL.Models;
using DALFactories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<INotification> GetNotifications() 
        {
            notifications = new List<INotification>();
            List<INotificationDto> AllNotifications = notificationDB.GetNotifications(); 
            foreach (INotificationDto model in AllNotifications)
            {
                notifications.Add(new Notification() 
                {
                    id = model.id,
                    postID = model.postID,
                    accountID = model.accountID
                });
            }
            return (notifications);
        }
        public void DeleteNotification(int id)
        {
            List<INotificationDto> AllNotifications = notificationDB.GetNotifications();
            List<INotificationDto> IDNotifications = AllNotifications.Where(x => x.postID == id).ToList();
            INotificationDto currentmodel = IDNotifications[0];
            notificationDB.DeleteNotification(currentmodel.id);
        }
    }
}
