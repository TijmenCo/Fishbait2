using System;
using Fishbait2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
       
        public string image { get; set; }
        public string tag { get; set; }
        
    }
   
}
