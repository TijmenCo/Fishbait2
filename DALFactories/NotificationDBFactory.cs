using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALFactories
{
    public static class NotificationDBFactory
    {
        public static INotificationDto GetNotification()
        {
            return new NotificationDto();
        }
    }
}
