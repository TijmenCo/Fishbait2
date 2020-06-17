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
        private readonly INotificationDBAccesLayer notificationDB;
        private List<INotification> notifications { get; set; }
        private bool followed { get; set; }
        public int id { get; set; }
        public int accountID { get; set; }
        public int postID { get; set; }
        public Notification(INotificationDBAccesLayer _dependancy)
        {
            notificationDB = _dependancy;
        }
        public bool AddFollow(INotification model)
        {
            INotificationDto notificationDto = NotificationDBFactory.GetNotification();
            notificationDto.accountID = model.accountID;
            notificationDto.postID = model.postID;
            bool resp = notificationDB.AddFollow(notificationDto);
            return (resp);
        }
        public List<INotification> GetNotifications() 
        {
            notifications = new List<INotification>();
            List<INotificationDto> AllNotifications = notificationDB.GetNotifications(); 
            foreach (INotificationDto model in AllNotifications)
            {
                notifications.Add(new Notification(notificationDB) 
                {
                    id = model.id,
                    postID = model.postID,
                    accountID = model.accountID
                });
            }
            return (notifications);
        }
        public void DeleteNotification(int id, bool registered)
        {
            if (registered == true)
            {
                List<INotificationDto> AllNotifications = notificationDB.GetNotifications();
                List<INotificationDto> IDNotifications = AllNotifications.Where(x => x.postID == id).ToList();
                INotificationDto currentmodel = IDNotifications[0];
                notificationDB.DeleteNotification(currentmodel.id);
            }
        }
        public bool IsFollowed(int id)
        {  
            List<INotification> DBNotifications = GetNotifications();
            List<INotification> IDNotifications = DBNotifications.Where(x => x.accountID == 1 && x.postID == id).ToList();
            foreach (var notification in DBNotifications)
            {
                if (notification.accountID == 1 && notification.postID == id)
                {
                    followed = true;
                }
            }
            return followed;
        }
    }
}
