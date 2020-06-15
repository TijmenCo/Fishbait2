using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostUpdateViewModel
    {
        [Key]
        public int id { get; set; }
        public int postID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string image { get; set; }
        public ICollection<IFormFile> files { get; set; }
    }
}
