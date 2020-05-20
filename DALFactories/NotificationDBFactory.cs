using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALFactories
{
    public static class NotificationDBFactory
    {
        public static INotificationDBAccesLayer GetNotificationDB()
        {
            return new NotificationDBAccesLayer();
        }
        public static INotificationDto GetNotification()
        {
            return new NotificationDto();
        }
    }
}
