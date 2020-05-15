namespace DAL.Models
{
    public interface IPostDto
    {
        string description { get; set; }
        int id { get; set; }
        string image { get; set; }
        string tag { get; set; }
        string title { get; set; }
    }
}