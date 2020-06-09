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
        [TestMethod]
        public void AddPost_AddAPost_ReturnsDataSaveSuccessfully()
        {
            /*
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
            */
        }
        [TestMethod]
        public void AddPost_AddAPostWithTitleOver50Chars_ReturnsDataSaveFailed()
        {
            iPost = PostFactory.GetPost();
            var mock = new Mock<IPost>();
            mock.Setup(m => m.AddPost(mock.Object)).Returns("Data save Failed");
            //Configure Mocks
            mock.Setup(m => m.title).Returns("");
            mock.Setup(m => m.description).Returns("Nieuwe soort lepel");
            mock.Setup(m => m.image).Returns("lepel.png");
            mock.Setup(m => m.tag).Returns("Tech");
            //Save Result
            var result = mock.Object.AddPost(mock.Object);
            //Check if add went succesfully
            Assert.AreEqual(result, "Data save Failed");

        }
        [TestMethod]
        public void GetPosts_PostsGetSavedFromDB_ReturnsTrue()
        {
            List<IPostDto> postsDto = new List<IPostDto>();
            List<IPostDto> posts = GivePosts();
            var dalMock = new Mock<IPostDBAccesLayer>();
            dalMock.Setup(m => m.GetPosts()).Returns(posts);
            var epic = new Post(dalMock.Object);
            var gottenPosts = epic.GetPosts();
           
            //Check if GetPosts went succesfully
            Assert.AreEqual(gottenPosts.Count(), posts.Count());
        }
        [TestMethod]
        public void DeletePost_PostGetsDeleted_ReturnsTrue()
        {
            var mock = new Mock<IPost>();
            mock.Setup(m => m.DeletePost(mock.Object.id)).Returns("Data deletion Succes");
            mock.Setup(m => m.id).Returns(16);
            var result = mock.Object.DeletePost(mock.Object.id);
            Assert.AreEqual(result, "Data deletion Succes");
            //Save Result

            //Check if GetPosts went succesfully
            //Assert.AreEqual(exists, true);
        }
        public List<IPostDto> GivePosts()
        {
            IPostDto[] postDto = new IPostDto[3];
            List<IPostDto> posts = new List<IPostDto>();
            for (int i = 0; i < 3; i++)
            {
                postDto[i] = PostDBFactory.GetPost();
             }
            postDto[0].title = "Help";
            postDto[0].description = "Beschrijving";
            postDto[0].image = "foto.png";
            postDto[0].tag = "Tech";
            posts.Add(postDto[0]);

           
            postDto[1].title = "Help";
            postDto[1].description = "Beschrijving";
            postDto[1].image = "foto.png";
            postDto[1].tag = "Tech";
            posts.Add(postDto[1]);

            postDto[2].title = "Help";
            postDto[2].description = "Beschrijving";
            postDto[2].image = "foto.png";
            postDto[2].tag = "Tech";
            posts.Add(postDto[2]);
            return posts;

        }
    }
}
