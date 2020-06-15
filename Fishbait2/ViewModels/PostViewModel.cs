using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostViewModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string image { get; set; }
        public string tag { get; set; }

        public ICollection<IFormFile> files { get; set; }
        public Tags tags { get; set; }
        public bool registered { get; set; }
    }
}
