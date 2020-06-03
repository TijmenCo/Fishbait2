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
    }

}
