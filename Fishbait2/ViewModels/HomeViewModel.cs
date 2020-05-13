using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public string tag { get; set; }
        public Tags tags { get; set; }
    }
}
