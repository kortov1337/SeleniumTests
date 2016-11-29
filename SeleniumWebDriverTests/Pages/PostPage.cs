using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace SeleniumWebDriverTests.Pages
{
    class PostPage
    {
        private IWebDriver driver;
        string ratingCountBefore = "";
        string ratingCountAfter = "";
        private const string BASE_URL = "http://pikabu.ru/story/ytsutsyu_4505451";

        #region WEbElemets declaration
        [FindsBy(How = How.XPath, Using = ".//div[@data-placeholder='Написать комментарий']")]
        private IWebElement commentPlaceholder;

        [FindsBy(How = How.XPath, Using = ".//button[@type='submit' and text()='Отправить']")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='comment_73500936']/div/div/div[@class='b-comment__rating-count']")]
        private IWebElement ratingCounter;

        [FindsBy(How = How.XPath, Using = "//div[@id='comment_73500936']/div/div/ul/li[@class='b-comment__rating-up']")]
        private IWebElement ratingUpButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='comment_73500936']/div/div/ul/li[@class='b-comment__rating-down']")]
        private IWebElement ratingDownButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Поиск по тегу \"проверка\"']")]
        private IWebElement tagSearchButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='comment_73113618']/div/noindex[2]/div/button[text()='ответить']")]
        private IWebElement replyCommentButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='comment_73113618']/div/noindex[2]/div[@class='b-comment__reply-wrapper']/div/div/div[@data-placeholder=\"Введите текст комментария\"]")]
        private IWebElement replyCommentPlaceholder;

        [FindsBy(How = How.XPath, Using = "//div[@id='comment_73113618']/div/noindex[2]/div[@class='b-comment__reply-wrapper']/div/ul/li/button")]
        private IWebElement submitReplyButton;
        #endregion

        public PostPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl(BASE_URL);
            //Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void FillCommentPlaceholder(string content)
        {
            commentPlaceholder.SendKeys(content);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        public void SendComment()
        {
            submitButton.Click();
        }

        public int RatingComporator(string before, string after)
        {
            //-1 - уменьшился
            //0 - косяк
            //+1 - увеличился
            if (before.Contains('+') || before.Contains('-'))
                before.Remove(0, 1);
            if (after.Contains('+') || after.Contains('-'))
                after.Remove(0, 1);
            return String.Compare(before, after);
        }

        public void GetRating(int mode)
        {
            //mode = 1 рейтинг до изменения
            //mode = 2 рейтинг после измененя
            if (mode == 1)
                ratingCountBefore = ratingCounter.Text;
            else if (mode == 2)
                ratingCountAfter = ratingCounter.Text;
        }

        public void PressRatingUp()
        {
            ratingUpButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void PressRatingDown()
        {
            ratingDownButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public int GetRatingUpResult()
        {
            return RatingComporator(ratingCountBefore, ratingCountAfter) ;
        }

        public void DoTagSearch()
        {
            tagSearchButton.Click();
        }

        public bool GetTagSearchResult()
        {
            try
            {
                IWebElement tagSearchFailedMessage = driver.FindElement(By.XPath("//div[@class='search-result-msg']"));
                return false;
            }
            catch (NoSuchElementException e)
            {
                return true;
            }
        }

        public void PressReplyButton()
        {
            replyCommentButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void FillReply(string content)
        {
            replyCommentPlaceholder.SendKeys(content);
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void SubmitReply()
        {
            submitReplyButton.Click();
        }
    }
}
