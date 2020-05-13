using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    class PostUpdateDto
    {
        [Key]
        public int id { get; set; }
        public int postID { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public string image { get; set; }
    }
}
