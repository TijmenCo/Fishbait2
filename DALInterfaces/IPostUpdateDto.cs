namespace DAL.Models
{
    public interface IPostUpdateDto
    {
        string description { get; set; }
        int id { get; set; }
        string image { get; set; }
        int postID { get; set; }
        string title { get; set; }
    }
}