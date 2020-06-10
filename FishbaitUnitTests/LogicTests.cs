using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DALFactories;
using Factories;
using Fishbait2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FishbaitUnitTests
{
    [TestClass]
    public class LogicTests
    {
        public bool exists;
        private IPost iPost;
        private IPostDBAccesLayer postDB;

        [TestInitialize]
        public void TestInitialize()
        {
        }
        /*
        [TestMethod]
        public void AddPost_AddAPost_ReturnsDataSaveSuccessfully()
        {
            
            var dalMock = new Mock<IPostDBAccesLayer>();
            var postMock = new Mock<IPostDBAccesLayer>();
            dalMock.Setup(m => m.AddPost(It.IsAny<IPostDto>())).Returns("Data save succesfull");
            //Configure Mocks
            mock.Setup(m => m.title).Returns("Lepel");
            mock.Setup(m => m.description).Returns("Nieuwe soort lepel");
            mock.Setup(m => m.image).Returns("lepel.png");
            mock.Setup(m => m.tag).Returns("Tech");
            //Save Result
            var result = mock.Object.AddPost(mock.Object);
            //Check if add went succesfully
            Assert.AreEqual(result, "Data save Successfully");

            // Demonstrate that the configuration works
            //   Assert.AreEqual("lepel", mock.Object.title);

            // Verify that the mock was invoked
            //    mock.VerifyGet(x => x.title);
          
        }
    */
        [TestMethod]
        public void GetPosts_PostsGetCorrectlySavedFromDB_ReturnsTrue()
        {

            List<IPostDto> postsDto = new List<IPostDto>();
            List<IPostDto> posts = GivePostsDto();
            var dalMock = new Mock<IPostDBAccesLayer>();
            dalMock.Setup(m => m.GetPosts()).Returns(posts);
            var epic = new Post(dalMock.Object);
            var gottenPosts = epic.GetPosts();
           
            //Check if GetPosts went succesfully
            Assert.AreEqual(gottenPosts.Count(), posts.Count());
        }
        [TestMethod]
        public void GetPostID_PostGetCorrectlyWithID_ReturnsTrue()
        {
            List<IPostDto> posts = GivePostsDto();
            var mock = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.GetPosts()).Returns(posts);
            var post = new Post(mock.Object);
            var resultID = posts.Where(x => x.id == 3).ToList();
            var result = post.GetPostID(3);
            Assert.AreEqual(result.id, resultID[0].id);
        }

            public List<IPostDto> GivePostsDto()
        {
            IPostDto[] postDto = new IPostDto[3];
            List<IPostDto> posts = new List<IPostDto>();
            for (int i = 0; i < 3; i++)
            {
                postDto[i] = PostDBFactory.GetPost();
             }
            postDto[0].id = 1;
            postDto[0].title = "Nieuwe schep!";
            postDto[0].description = "Een nieuwe soort schep!";
            postDto[0].image = "schep.png";
            postDto[0].tag = "Nature";
            posts.Add(postDto[0]);

            postDto[1].id = 2;
            postDto[1].title = "Nieuwe Auto!";
            postDto[1].description = "Een snellere auto!";
            postDto[1].image = "auto.png";
            postDto[1].tag = "Tech";
            posts.Add(postDto[1]);

            postDto[2].id = 3;
            postDto[2].title = "Nieuwe soort pen!";
            postDto[2].description = "Deze pen heeft een nieuwe kleur!";
            postDto[2].image = "pen.png";
            postDto[2].tag = "Creative";
            posts.Add(postDto[2]);
            return posts;

        }
     
    }
}
