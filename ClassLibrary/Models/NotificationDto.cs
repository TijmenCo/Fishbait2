using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class NotificationDto : INotificationDto
    {
        [Key]
        public int id { get; set; }
        public int accountID { get; set; }
        public int postID { get; set; }
    }
}
