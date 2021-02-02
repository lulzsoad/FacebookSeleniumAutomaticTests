// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpTutorials.BaseClass;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class OrderSkipAttribute
    {

        // CHROME TEST
        [Test, Order(2), Category("OrderSkipAttribute")]
        public void TestMethod1()
        {
            Assert.Ignore("Reason for skipping case"); //Skips the case with descripted reson
            ChromeOptions options = new ChromeOptions() { BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe" };
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";

            IWebElement cookiesAcceptation = driver.FindElement(By.XPath(".//*[@id='u_0_h']"));

            cookiesAcceptation.Click();
            Thread.Sleep(1000);

            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");

            driver.Close();
        }

        // FIREFOX TEST
        [Test, Order(1), Category("OrderSkipAttribute")]
        public void TestMethod2()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";

            IWebElement cookiesAcceptation = driver.FindElement(By.XPath(".//*[@id='u_0_h']"));

            cookiesAcceptation.Click();
            Thread.Sleep(1000);

            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");

            driver.Close();
        }

        // EDGE TEST
        [Test, Order(0), Category("OrderSkipAttribute")]
        public void TestMethod3()
        {
            EdgeOptions options = new EdgeOptions() { UseChromium = true };
            IWebDriver driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";

            IWebElement cookiesAcceptation = driver.FindElement(By.XPath(".//*[@id='u_0_h']"));

            cookiesAcceptation.Click();
            Thread.Sleep(1000);

            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");

            driver.Close();
        }
    }
}
