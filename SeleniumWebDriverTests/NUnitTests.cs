using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SeleniumWebDriverTests
{
    class NUnitTests
    {
        private Steps step = new Steps();
        private PostData postData = new PostData("Header " + DateTime.Now.ToShortTimeString(),"проверка,тестирование сайтов",
                                                 "Test text " + DateTime.Now.ToShortTimeString(),
                                                 Path.GetFullPath("SeleniumWebDriverTests\\Data\\Pictures\\1.jpg"));
                      
        private string comment = "Test comment " + DateTime.Now.ToShortTimeString();
        private string replyContent = "Test reply " + DateTime.Now.ToShortTimeString();
        private const string username = "testUser14";
        private const string password = "SupaPass3k";
        private string picture = Path.GetFullPath(@"SeleniumWebDriverTests\\Data\\Pictures\\av1.png");

        [SetUp]
        public void Init()
        {
            step.Init();
        }

         /*[Test]
         public void AddPostTest()
         {
            step.LogIn(username, password);
            step.AddPost(postData);         
         }*/
         
        [Test]
        public void ChangePicTest()
        {
                step.LogIn(username, password);
                Assert.True(step.ChahgeProfilePic(picture));
        }

        [Test]
        public void LogInTest()
        {
            step.LogIn(username, password);
            Assert.True(step.IsLoggedIn(username));
        }

        [Test]
        public void AddCommentTest()
        {
                step.LogIn(username, password);          
                step.AddComment(comment);
        }
        
        [Test]
        public void RatingUpTest()
        {
            step.LogIn(username, password);
            Assert.True(step.RatingUp());
        }

        [Test]
        public void RatingDownTest()
        {
            step.LogIn(username, password);
            Assert.True(step.RatingDown());
        }

        [Test]
        public void TagSearchTest()
        {
            step.LogIn(username, password);
            Assert.True(step.TagSearch());
        }

        [Test]
        public void ReplyComment()
        {
            step.LogIn(username, password);
            step.ReplyComment(replyContent);
        }

        [TearDown]
        public void EndTest()
        {
            step.LogOut();
        }
    }
}
