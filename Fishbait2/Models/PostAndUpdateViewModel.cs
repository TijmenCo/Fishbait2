using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostAndUpdateViewModel
    {
        public IEnumerable<Post> post { get; set; }
        public IEnumerable<PostUpdate> postUpdate { get; set; }
    }
}
