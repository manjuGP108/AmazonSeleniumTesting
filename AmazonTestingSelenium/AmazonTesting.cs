using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace AmazonTestingSelenium
{
    [TestClass]
    public class AmazonTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            // Maximise the screen
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("powerbanks");
            //By Xpaths
            //driver.FindElement(By.XPath("//*[@id='twotabsearchtextbox']")).SendKeys("a");
            //* in the above line tells that it can be of any type of controller
            //driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']")).SendKeys("b");
            //since the controller is of type input so we can explicitly specify it.
            // https://www.guru99.com/xpath-selenium.html for more information
            //driver.FindElement(By.XPath("//input[contains(@id, 'twotabsearchtext')]")).SendKeys("c"); // driver.FindElement(By.XPath("//*[contains(@id, 'twotabsearchtext')]")).SendKeys("power");
            //driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox' or @name = 'field-keywords']")).SendKeys("d");
            //driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox' and @name = 'field-keywords']")).SendKeys("e");
            //driver.FindElement(By.XPath("//*[contains(@id, 'twotabsearchtextbox') and @name = 'field-keywords']")).Clear();
            //driver.FindElement(By.XPath("//input[contains(@id, 'twotabsearchtextbox') and @name = 'field-keywords']")).Clear();
            //Thread.Sleep(2000);
            //Clicks on search button
            //driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
            //Thread.Sleep(2000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(2000);
            //SendKeys.SendWait("{DOWN}");
            //SendKeys.SendWait("{DOWN}");
            //SendKeys.SendWait("{DOWN}");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class = 'nav-search-submit nav-sprite']//input[@value = 'Go']")).Click();
            Thread.Sleep(2000);
            var element = driver.FindElement(By.XPath("//div[@id = 'nav-tools']//span[@class = 'nav-line-1']"));

            var actionObject = new Actions(driver);
            actionObject.MoveToElement(element).Perform();
            Thread.Sleep(5000);
            var yourAccount = driver.FindElement(By.XPath("//div[@id = 'nav-flyout-yourAccount']//*[@href = '/gp/css/homepage.html/ref=nav_youraccount_ya']"));
            //actionObject.MoveToElement(yourAccount).Click();
            actionObject.MoveToElement(yourAccount).Click().Perform();
        }
    }
}