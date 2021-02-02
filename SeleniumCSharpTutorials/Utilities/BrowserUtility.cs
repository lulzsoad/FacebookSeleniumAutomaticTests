using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCSharpTutorials.Utilities
{
    public class BrowserUtility
    {
        public IWebDriver Init(IWebDriver driver)
        {
            ChromeOptions options = new ChromeOptions() { BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe" };
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";

            IWebElement cookiesAcceptation = driver.FindElement(By.XPath(".//*[@id='u_0_h']"));

            cookiesAcceptation.Click();
            Thread.Sleep(1000);

            return driver;
        }
    }
}
