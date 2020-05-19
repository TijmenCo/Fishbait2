namespace DAL.Models
{
    interface INotificationDto
    {
        int accountID { get; set; }
        int id { get; set; }
        int postID { get; set; }
    }
}