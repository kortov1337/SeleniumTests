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
    class MainPage
    {
        private IWebDriver driver;
        private const string BASE_URL = "http://www.pikabu.ru/";

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement usernameTextbox;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordTextbox;

        [FindsBy(How = How.XPath, Using = ".//button[text()='войти']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = ".//a[@href='http://pikabu.ru/add']")]
        private IWebElement buttonAddPost;

        [FindsBy(How = How.XPath, Using = ".//input[@name='title']")]
        private IWebElement postTitle;

        [FindsBy(How = How.XPath, Using = ".//div[@class='b-gtpost-panel-adding__wrapper' and not(@style)]/button[@name='текст']")]
        private IWebElement addTextButton;

        [FindsBy(How = How.XPath, Using = ".//div[@data-placeholder='Введите текст']")]
        private IWebElement postTextContent;

        [FindsBy(How = How.XPath, Using = ".//input[@name='avatarfile' and not(@style)]")]
        private IWebElement postPicture;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='От 2 до 8 тегов через запятую...' and @style='width: 213px;']")]
        private IWebElement tags;

        [FindsBy(How = How.XPath, Using = ".//button[@type='submit' and text()='Добавить пост']")]
        private IWebElement submitPostButton;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        public void OpenPostEditor()
        {
            buttonAddPost.Click();
        }
        public void Login(string username, string password)
        {
            usernameTextbox.SendKeys(username);
            passwordTextbox.SendKeys(password);
            buttonSubmit.Click();
        }

        public void FillPost(PostData data)
        {
            postTitle.SendKeys(data.Header);
            addTextButton.Click();
            postTextContent.SendKeys(data.Text);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            postPicture.SendKeys(data.PicturePath);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            tags.SendKeys(data.Tag);
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void AddPost()
        {
            submitPostButton.Click();
        }

    }
}
