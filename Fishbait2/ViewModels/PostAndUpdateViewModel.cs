using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Models
{
    public class PostAndUpdateViewModel
    {
        public PostViewModel post { get; set; }

        public List<IPostUpdate> postupdate { get; set; }
    }
}
