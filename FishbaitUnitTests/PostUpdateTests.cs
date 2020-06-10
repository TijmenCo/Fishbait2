using DAL.Models;
using DALFactories;
using Fishbait2.Models;
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
    public class PostUpdateTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }
        [TestMethod]
        public void GetUpdatePosts_UpdatePostsGetCorrectlySavedFromDB_ReturnsTrue()
        {
            List<IPostUpdateDto> postsDto = new List<IPostUpdateDto>();
            List<IPostUpdateDto> posts = GiveUpdatePostsDto();
            var dalMock = new Mock<IPostDBAccesLayer>();
            dalMock.Setup(m => m.GetUpdatePosts()).Returns(posts);
            var postupdate = new PostUpdate(dalMock.Object);
            var gottenPosts = postupdate.GetUpdatePosts();

            //Check if GetUpdatesPosts went succesfully
            Assert.AreEqual(gottenPosts.Count(), posts.Count());
        }
        [TestMethod]
        public void GetUpdateIDPosts_UpdatePostsGetCorrectlyByPostIDFromDB_ReturnsTrue()
        {
            List<IPostUpdateDto> posts = GiveUpdatePostsDto();
            var mock = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.GetUpdatePosts()).Returns(posts);
            var postupdate = new PostUpdate(mock.Object);
            var resultID = posts.Where(x => x.postID == 7).ToList();
            var result = postupdate.GetUpdateIDPosts(7);

            //Check if the same PostUpdates get found
            Assert.AreEqual(result[0].id, resultID[0].id);
        }
            public List<IPostUpdateDto> GiveUpdatePostsDto()
        {
            IPostUpdateDto[] postDto = new IPostUpdateDto[3];
            List<IPostUpdateDto> postupdates = new List<IPostUpdateDto>();
            for (int i = 0; i < 3; i++)
            {
                postDto[i] = PostDBFactory.GetPostUpdate();
            }
            postDto[0].id = 1;
            postDto[0].postID = 7;
            postDto[0].title = "Nieuwe features";
            postDto[0].description = "Een dril functie";
            postDto[0].image = "dril.png";
            postupdates.Add(postDto[0]);

            postDto[1].id = 2;
            postDto[1].postID = 8;
            postDto[1].title = "Nieuwe banden!";
            postDto[1].description = "Anti plak banden";
            postDto[1].image = "banden.png";
            postupdates.Add(postDto[1]);

            postDto[2].id = 3;
            postDto[2].postID = 9;
            postDto[2].title = "Nieuwe soort inkt!";
            postDto[2].description = "Nu in blurple";
            postDto[2].image = "inkt.png";
            postupdates.Add(postDto[2]);
            return postupdates;

        }
    }
}
