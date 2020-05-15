using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class PostDto : IPostDto
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public string image { get; set; }
        public string tag { get; set; }

    }
}
