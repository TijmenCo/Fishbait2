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

        [TestInitialize]
        public void TestInitialize()
        {
        }
        [TestMethod]
        public void AddPost_AddAPost_ReturnsDataSaveSuccessfully()
        {
            var mock = new Mock<IPost>();
            mock.Setup(m => m.AddPost(mock.Object)).Returns("Data save Successfully");
            //Configure Mocks
            mock.Setup(m => m.title).Returns("lepel");
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
        [TestMethod]
        public void AddPost_AddAPostWithTitleOver50Chars_ReturnsDataSaveFailed()
        {
            iPost = PostFactory.GetPost();
            var mock = new Mock<IPost>();
            mock.Setup(m => m.AddPost(mock.Object)).Returns("Data save Failed");
            //Configure Mocks
            mock.Setup(m => m.title).Returns("abcdefghijklmnopqrstuvwxzyabcdefghijklmnopqrstuvwxzyabcdefghijklmnopqrstuvwxzy");
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
            iPost = PostFactory.GetPost();
            var posts = new List<IPost>();
           // var mock = new Mock<IPost>();
           // mock.Setup(m => m.GetPosts()).Returns(posts);
          
            //Save Result
            posts = iPost.GetPosts();
            if(posts.Any())
            {
                exists = true;
            }
            //Check if GetPosts went succesfully
            Assert.AreEqual(exists, true);
        }
        [TestMethod]
        public void DeletePost_PostGetsDeleted_ReturnsTrue()
        {
            iPost = PostFactory.GetPost();
            var mock = new Mock<IPost>();
            mock.Setup(m => m.DeletePost(mock.Object.id)).Returns("Data deletion Succes");
            mock.Setup(m => m.id).Returns(16);
            var result = mock.Object.DeletePost(mock.Object.id);
            Assert.AreEqual(result, "Data deletion Succes");
            //Save Result

            //Check if GetPosts went succesfully
            //Assert.AreEqual(exists, true);
        }
    }
}
