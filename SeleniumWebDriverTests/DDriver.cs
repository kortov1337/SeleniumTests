using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverTests
{
    class DDriver
    {
        private static IWebDriver driver;

        private DDriver() { }

        public static IWebDriver GetInstance()
        {
            if(driver==null)
            {
                driver = new ChromeDriver();
                
            }
            return driver;
        }
    }
}
