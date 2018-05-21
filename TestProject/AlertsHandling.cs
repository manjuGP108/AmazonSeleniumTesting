using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AmazonTestingSelenium
{
    [TestClass]
    public class AlertsHandling
    {
        [TestMethod]
        public void AlertsHandlingTesting()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";

            ////This step produce an alert on screen
            driver.Manage().Window.Maximize();
            //Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();

            //// Get the alert window text // Alerts are implemented in the IAlert interface
            ////driver.SwitchTo().Alert();
            //var alertMessage = driver.SwitchTo().Alert();
            //var alertMessageText = alertMessage.Text;

            ////Click on OK
            //alertMessage.Accept();

            ////Popup alert
            //Thread.Sleep(3000);
            //var actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/p[8]/button")));

            ////actions.MoveToElement(driver.FindElement(By.XPath("//*[@id='content']/p[8]/button"))).Click().Perform();  not working
            //var a = driver.FindElement(By.XPath("//*[@id='content']/p[8]/button"));
            ////driver.FindElement(By.XPath("//*[@id='content']/p[8]/button")).Click();
            //Thread.Sleep(3000);
            ////driver.SwitchTo().Alert().Accept();
            ////Thread.Sleep(2000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);
            //SendKeys.SendWait("{DOWN}");
            //Thread.Sleep(1000);

            //driver.FindElement(By.XPath("//*[@id='content']/p[8]/button")).Click();
            //Thread.Sleep(2000);
            //driver.SwitchTo().Alert().Dismiss();
            //Thread.Sleep(2000);

            ////Prompt Popup
            //driver.FindElement(By.XPath("//*[@id='content']/p[11]/button")).Click();
            //Thread.Sleep(2000);
            //var alert = driver.SwitchTo().Alert();
            //SendKeys.SendWait("Alert is accepted go Ahead");
            //Thread.Sleep(2000);
            //alert.Accept();
            driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-switch-windows/");
            driver.FindElement(By.Id("button1")).Click();
            Thread.Sleep(2000);
            // move to 2nd window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//span[@class = 'menu-text']")).Click();
            Thread.Sleep(1000);
            //close 2nd window
            driver.Close();
            Thread.Sleep(2000);
            // go to 1st window actions
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.FindElement(By.XPath("//*[@id='content']/p[3]/button")).Click();
            // move to 2nd window and maximize
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Window.Maximize();
            // close 2nd window and move to first window
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            Thread.Sleep(2000);
            // check new browser navigation testing
            driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();
            Thread.Sleep(2000);
            //new browser action
            driver.SwitchTo().Window(driver.WindowHandles.Last()); // same command to move to newly opened window and browser
            driver.FindElement(By.XPath("//span[@class = 'menu-text']")).Click();
            Thread.Sleep(1000);
            //move back to 1st browser
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            //driver.SwitchTo().ParentFrame();  //move to parent window
            //driver.SwitchTo().ActiveElement();  //moves to active element currently
            Thread.Sleep(2000);
            //javascript alert
            driver.FindElement(By.Id("alert")).Click();
            driver.SwitchTo().Alert().Accept();
            //timing alert
            driver.FindElement(By.Id("timingAlert")).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            var alertmessage = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
        }
    }
}