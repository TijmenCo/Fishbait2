using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class Post
    {
        public int id { get; set; }
        public int accountID { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string tag { get; set; }

    }
}
