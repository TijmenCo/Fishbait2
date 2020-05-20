using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.ViewModels
{
    public class NotificationViewModel
    {
        public int id { get; set; }
        public int accountID { get; set; }
        public int postID { get; set; }
        public List<String> notifications { get; set; }
    }
}
