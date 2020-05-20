namespace Logic
{
    public interface INotification
    {
        int accountID { get; set; }
        int id { get; set; }
        int postID { get; set; }

        string AddFollow(INotification model);
    }
}