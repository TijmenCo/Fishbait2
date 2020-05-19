using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    class NotificationDto : INotificationDto
    {
        public int id { get; set; }
        public int accountID { get; set; }
        public int postID { get; set; }
    }
}
