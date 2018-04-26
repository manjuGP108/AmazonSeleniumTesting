using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AmazonTestingSelenium
{
    [TestClass]
    public class HDFC
    {
        [TestMethod]
        public void hdfcBankTest()
        {
            IWebDriver driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));
            driver.Navigate().GoToUrl("https://www.hdfcbank.com/personal/ways-to-bank/bank-online/netbanking");
            driver.FindElement(By.XPath("//div[@class = 'mainloginBox']//div[@class = 'loginetbank']")).Click();
            Thread.Sleep(2000);
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("netbanking")));
            wait.Until(d => d.FindElement(By.Id("netbanking"))).Click();
            //driver.FindElement(By.Id("netbanking")).Click();
            driver.FindElement(By.Id("loginsubmit")).Click();

            //How to find name of window
            //Try the following:
            //Open Console tab in Firebug;
            //Execute window.name or window.document.title

            //To switch to another browser by browser name
            //driver.SwitchTo().Window("NetBanking");
            // to switch to latest opened window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[1]/a")).Click();
            Thread.Sleep(2000);
            var a = driver.CurrentWindowHandle;
            SendKeys.SendWait("55007970");
            // switch back to previous page
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.FindElement(By.Id("loginsubmit")).Click();
            Thread.Sleep(2000);
            //close current browser
            driver.Close();
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}