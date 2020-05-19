using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class Notification : INotification
    {
        public int id { get; set; }
        public int accountID { get; set; }
        public int postID { get; set; }
    }
}
