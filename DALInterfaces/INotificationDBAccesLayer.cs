using DAL.Models;

namespace DAL.Data
{
    public interface INotificationDBAccesLayer
    {
        string AddFollow(INotificationDto notification);
    }
}