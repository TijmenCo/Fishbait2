using DAL.Data;
using DAL.Models;
using DALFactories;
using Fishbait2.Models;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishbaitUnitTests
{
    [TestClass]
    public class NotificationTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }
        [TestMethod]
        public void GetUpdatePosts_GetAllNotificationsCorrectlyFromDB_Returns3()
        {
            List<INotificationDto> postsDto = new List<INotificationDto>();
            List<INotificationDto> follows = GiveNotificationsDto();
            var dalMock = new Mock<INotificationDBAccesLayer>();
            dalMock.Setup(m => m.GetNotifications()).Returns(follows);
            var notification = new Notification(dalMock.Object);
            var gottenFollows = notification.GetNotifications();

            //Check if GetPosts went succesfully
            Assert.AreEqual(gottenFollows.Count(), follows.Count());
        }
        [TestMethod]
        public void IsFollowed_GetFollowsCorrectlyFromDB_ReturnsTrue()
        {
            
            List<INotificationDto> postsDto = new List<INotificationDto>();
            List<INotificationDto> follows = GiveNotificationsDto();
            var dalMock = new Mock<INotificationDBAccesLayer>();
            dalMock.Setup(m => m.GetNotifications()).Returns(follows);
            var notification = new Notification(dalMock.Object);

            int postid = 7; //PostID = 7 de postID van 7 bestaat in het lijstje van GiveNotificationDto (postDto[0])
            var followed = notification.IsFollowed(postid);

            //Check if the person follows the post (account ID is always 1 in this case).
            Assert.AreEqual(followed, true);
        }
        public List<INotificationDto> GiveNotificationsDto()
        {
            INotificationDto[] notificationDto = new INotificationDto[3];
            List<INotificationDto> notifications = new List<INotificationDto>();
            for (int i = 0; i < 3; i++)
            {
                notificationDto[i] = NotificationDBFactory.GetNotification();
            }
            notificationDto[0].id = 1;
            notificationDto[0].accountID = 1;
            notificationDto[0].postID = 7;
            notifications.Add(notificationDto[0]);

            notificationDto[1].id = 2;
            notificationDto[1].accountID = 1;
            notificationDto[1].postID = 8;
            notifications.Add(notificationDto[1]);

            notificationDto[2].id = 3;
            notificationDto[2].accountID = 1;
            notificationDto[2].postID = 9;
            notifications.Add(notificationDto[2]);
            return notifications;

        }
    }
}
