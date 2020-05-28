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
    public class LogicTests
    {
        [TestMethod]
        public void AddPostTest()
        {
            IPost postDto = PostFactory.GetPost();
            var mock = new Mock<IPost>();
            postDto.id = 1;
            postDto.title = "Lepel";
            postDto.description = "Nieuwe soort lepel";
            postDto.image = "lepel.png";
            postDto.tag = "Tech";
            mock.Setup(foo => foo.AddPost(postDto)).Returns("Data save Successfully");
        }
    }
}
