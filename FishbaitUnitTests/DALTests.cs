using System;
using DAL.Models;
using DALFactories;
using Factories;
using Fishbait2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FishbaitUnitTests
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void AddPostTest()
        {
            IPost post = PostFactory.GetPost();
            var mock = new Mock<IPost>();
            var mockDB = new Mock<IPostDBAccesLayer>();
            mock.Setup(m => m.AddPost(post)).Returns("Failed");
            mock.SetupGet(m => m.title).Returns("lepel");
            mock.SetupGet(m => m.description).Returns("Nieuwe soort lepel");
            mock.SetupGet(m => m.image).Returns("lepel.png");
            mock.SetupGet(m => m.tag).Returns("Tech");
            var posty = mock.Object;
            var succes = post.AddPost(posty);

            Assert.AreEqual(succes, "Data save Successfully");
        }
    }
}
