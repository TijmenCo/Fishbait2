using DAL.Models;
using System.Collections.Generic;

namespace DAL.Data
{
    public interface INotificationDBAccesLayer
    {
        string AddFollow(INotificationDto notification);
        void DeleteNotification(int id);
        List<INotificationDto> GetNotifications();
    }
}