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
      
        [TestInitialize]
        public void TestInitialize()
        {
        }
       
        [TestMethod]
        public void GetPosts_PostsGetCorrectlySavedFromDB_ReturnsSuccesfully()
        {

            List<IPostDto> postsDto = new List<IPostDto>();
            List<IPostDto> posts = GivePostsDto();
            var dalMock = new Mock<IPostDBAccesLayer>();
            dalMock.Setup(m => m.GetPosts()).Returns(posts);
            var post = new Post(dalMock.Object);
            var gottenPosts = post.GetPosts();
           
            //Check if GetPosts has the same amount of Posts
            Assert.AreEqual(gottenPosts.Count(), posts.Count());
        }
        [TestMethod]
        public void GetPostID_PostGetCorrectlyWithID_ReturnsSuccesfully()
        {
            List<IPostDto> posts = GivePostsDto();
            var mock = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.GetPosts()).Returns(posts);
            var post = new Post(mock.Object);
            var resultID = posts.Where(x => x.id == 9).ToList();
            var result = post.GetPostID(9);

            //Check if GetPostID gets the same ID
            Assert.AreEqual(result.id, resultID[0].id);
        }
        [TestMethod]
        public void GetEditID_PostEditGetCorrectlyWithID_ReturnsSuccesfully()
        {
            List<IPostDto> posts = GivePostsDto();
            var mock = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.GetPosts()).Returns(posts);
            var post = new Post(mock.Object);
            var inputresultID = posts.Where(x => x.id == 8).ToList();
            var resultID = post.GetEditID(8);

            //Check if GetEditID gets the same ID
            Assert.AreEqual(resultID.id, inputresultID[0].id);
        }
        [TestMethod]
        public void Search_GetPostCorrectlyWithSearch_ReturnsSuccesfully()
        {
            List<IPostDto> posts = GivePostsDto();
            var mock = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.GetPosts()).Returns(posts);
            var post = new Post(mock.Object);
            var inputresultID = posts.Where(x => x.title == "Nieuwe Auto!").ToList();
            var resultID = post.Search("Auto");

            //Check if the search function finds the same ID
            Assert.AreEqual(resultID[0].id, inputresultID[0].id);
        }
        [TestMethod]
        public void Filter_FilterPostsCorrectlyWithRightTag_ReturnSuccesfully()
        {
            List<IPostDto> posts = GivePostsDto();
            var mock = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.GetPosts()).Returns(posts);
            var post = new Post(mock.Object);
            var inputresultCount = posts.Where(x => x.tag == "Tech").Count();
            var resultCount = post.Filter("Tech").Count();

            //Check if the it filters the same amount of posts
            Assert.AreEqual(resultCount, inputresultCount);
        }

        public List<IPostDto> GivePostsDto()
        {
            //Seed list with posts
            IPostDto[] postDto = new IPostDto[3];
            List<IPostDto> posts = new List<IPostDto>();
            for (int i = 0; i < 3; i++)
            {
                postDto[i] = PostDBFactory.GetPost();
             }
            postDto[0].id = 7;
            postDto[0].title = "Nieuwe schep!";
            postDto[0].description = "Een nieuwe soort schep!";
            postDto[0].image = "schep.png";
            postDto[0].tag = "Nature";
            posts.Add(postDto[0]);

            postDto[1].id = 8;
            postDto[1].title = "Nieuwe Auto!";
            postDto[1].description = "Een snellere auto!";
            postDto[1].image = "auto.png";
            postDto[1].tag = "Tech";
            posts.Add(postDto[1]);

            postDto[2].id = 9;
            postDto[2].title = "Nieuwe soort pen!";
            postDto[2].description = "Deze pen heeft een nieuwe kleur!";
            postDto[2].image = "pen.png";
            postDto[2].tag = "Creative";
            posts.Add(postDto[2]);
            return posts;

        }
     
    }
}
