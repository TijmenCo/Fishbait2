namespace DAL.Models
{
    public interface INotificationDto
    {
        int accountID { get; set; }
        int id { get; set; }
        int postID { get; set; }
    }
}