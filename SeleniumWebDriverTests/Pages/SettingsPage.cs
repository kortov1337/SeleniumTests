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
    class SettingsPage
    {
        private IWebDriver driver;
        private const string BASE_URL = "http://pikabu.ru";

        [FindsBy(How = How.LinkText, Using = "Настройки")]
        private IWebElement settingsLink;

        [FindsBy(How = How.XPath, Using = ".//input[@type='file']")]
        private IWebElement fileInput;

        [FindsBy(How = How.ClassName, Using = "b-profile__avatar-success")]
        private IWebElement confirmPictureButton;

        [FindsBy(How = How.XPath, Using = ".//label[@for='is_scrollmode']")]
        private IWebElement terebonkProvider;
        

        public SettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            settingsLink.Click();
        }

        public void UploadPicture(string picturePath)
        {
            fileInput.SendKeys(picturePath);
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        public void ConfirmPicture()
        {
            confirmPictureButton.Click();
        }

        public void Terebonk()
        {
            terebonkProvider.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            terebonkProvider.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

    }
}
