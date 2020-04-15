using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class Post
    {
        public int id { get; set; }
        public int accountID { get; set; }
        public string username { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string image { get; set; }
        public string tag { get; set; }

    }
}
