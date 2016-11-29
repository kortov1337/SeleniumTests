using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
namespace SeleniumWebDriverTests
{
    public class Steps
    {
        IWebDriver driver;
        IWebElement loggedUsername;

        public void Init()
        {
            driver = DDriver.GetInstance();
        }       

        public void LogIn(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);
        }

        public void LogOut()
        {
            try
            {
                driver.Navigate().GoToUrl("http://pikabu.ru");
                driver.FindElement(By.ClassName("b-user-menu__logout")).Click();
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            }
            catch
            {

            }
        }

        public bool IsLoggedIn(string username)
        {
            try
            {
                loggedUsername = driver.FindElement(By.LinkText(username));
                return (loggedUsername.Text.Trim().ToLower().Equals(username.Trim().ToLower()));
            }
            catch
            {
                return false;
            }
        }      

        public void AddPost(PostData data)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.OpenPostEditor();
            mainPage.FillPost(data);
            mainPage.AddPost();
        }

        public bool ChahgeProfilePic(string picture)
        {
            try
            {
                Pages.SettingsPage settingsPage = new Pages.SettingsPage(driver);
                settingsPage.OpenPage();              
                settingsPage.UploadPicture(picture);
                settingsPage.ConfirmPicture();
                settingsPage.Terebonk();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddComment(string commentContent)
        {
            Pages.PostPage postPage = new Pages.PostPage(driver);
            postPage.OpenPage();
            postPage.FillCommentPlaceholder(commentContent);
            postPage.SendComment();
        }

        public bool RatingUp()
        {
            Pages.PostPage postPage = new Pages.PostPage(driver);
            postPage.OpenPage();
            postPage.GetRating(1);//get rating before up
            postPage.PressRatingUp();
            postPage.GetRating(2);//get rating after up
            return (postPage.GetRatingUpResult()==1);
        }

        public bool RatingDown()
        {
                Pages.PostPage postPage = new Pages.PostPage(driver);
                postPage.OpenPage();
                postPage.GetRating(1);//get rating before up
                postPage.PressRatingDown();
                postPage.GetRating(2);//get rating after up
                return (postPage.GetRatingUpResult() == -1);
        }

        public bool TagSearch()
        {
            Pages.PostPage postPage = new Pages.PostPage(driver);
            postPage.OpenPage();
            postPage.DoTagSearch();
            return postPage.GetTagSearchResult();
        }

        public void ReplyComment(string replyContent)
        {
            Pages.PostPage postPage = new Pages.PostPage(driver);
            postPage.OpenPage();
            postPage.PressReplyButton();
            postPage.FillReply(replyContent);
            postPage.SubmitReply();
        }
              
    }
}
