using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class SeleniumCshapTutorial04
    {
        [Test]
        [Author("Łukasz", "lopata_l@wp.pl")]
        [Description("Facebook login Verify")]
        [TestCaseSource("DataDrivenTesting")]
        public void Test1(String urlName)
        {
            IWebDriver driver = null;

            try
            {
                ChromeOptions options = new ChromeOptions() { BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe" };
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                // driver.Url = "https://www.facebook.com/";
                driver.Url = urlName;

                IWebElement cookiesAcceptation = driver.FindElement(By.XPath(".//*[@id='u_0_h']"));
                cookiesAcceptation.Click();

                //IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
                IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='asdas']"));
                emailTextField.SendKeys("Selenium C#");
            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\lukas\\OneDrive\\Pulpit\\SeleniumCSharpSessions\\SeleniumCSharp\\SeleniumCSharpTutorials\\Screenshots\\s1.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if(driver != null)
                {
                    driver.Quit();
                }
            }
            
        }

        static IList DataDrivenTesting()
        {
            ArrayList list = new ArrayList();
            list.Add("https://www.facebook.com/");
            //list.Add("https://www.youtube.com/");
            //list.Add("https://www.gmail.com/");

            return list;
        }

        //[Test]
        //[Author("Łukasz", "lopata_l@wp.pl")]
        //[Description("Facebook login Verify")]
        //public void Test2()
        //{
        //    ChromeOptions options = new ChromeOptions() { BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe" };
        //    IWebDriver driver = new ChromeDriver(options);
        //    driver.Manage().Window.Maximize();
        //    driver.Url = "https://www.facebook.com/";

        //    IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
        //    emailTextField.SendKeys("Selenium C#");

        //    driver.Quit();
        //}
    }
}
