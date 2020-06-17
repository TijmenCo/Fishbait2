using DAL.Models;
using System.Collections.Generic;

namespace DAL.Data
{
    public interface INotificationDBAccesLayer
    {
        bool AddFollow(INotificationDto notification);
        void DeleteNotification(int id);
        List<INotificationDto> GetNotifications();
    }
}