using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TimeSheetTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));
            wait.Timeout = TimeSpan.FromMinutes(5);

            driver.Navigate().GoToUrl("https://tts.eurofins.local/dashboard");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("txtUsername")).SendKeys("KHN2");
            driver.FindElement(By.Id("txtPassword")).SendKeys("Manju@108125");
            driver.FindElement(By.Id("btnLogin")).Click();
            // to move to timeshet panel
            var timeSheetMenu = driver.FindElement(By.XPath("//div[@class = 'menu']//*[@id = 'menu_time_viewTimeModule']"));
            var actionObject = new Actions(driver);
            actionObject.MoveToElement(timeSheetMenu).Perform();
            //actionObject.MoveToElement(timeSheetMenu).Click().Perform();
            Thread.Sleep(1000);
            // to click sub timesheet menu
            var subTimeSheetMenu = driver.FindElement(By.XPath("//div[@class = 'menu']//*[@id = 'menu_time_Timesheets']"));
            Thread.Sleep(1000);
            actionObject.MoveToElement(subTimeSheetMenu).Perform();
            //actionObject.MoveToElement(timeSheetMenu).Click().Perform();
            Thread.Sleep(1000);
            // to click on my timesheet
            var myTimeSheetMenu = driver.FindElement(By.XPath("//div[@class = 'menu']//*[@href = '/time/viewMyTimesheet']"));
            //myTimeSheetMenu.Click();
            //actionObject.MoveToElement(subTimeSheetMenu).Click(myTimeSheetMenu).Perform();
            driver.FindElement(By.XPath("//a[@href = '/time/viewMyTimesheet']")).Click();
            var tableRowElements = driver.FindElements(By.XPath("//div[@class = 'box timesheet noHeader']//div[@class = 'tableWrapper']//tbody//tr")).Count;
            if (tableRowElements == 1)
            {
                driver.FindElement(By.Id("btnEdit")).Click();
                //var groupActivities = driver.FindElement(By.XPath("//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//tbody//tr[1]//td[2]"));
                var groupActivitiesDropDownSelectTag = driver.FindElement(By.XPath("//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//tbody/tr[1]//td[2]//select[@id = 'initialRows_0_projectName']"));

                //var activityName = driver.FindElement(By.XPath("//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//tbody//tr[1]//td[3]"));
                var activityNameDropDownSelectTag = driver.FindElement(By.XPath("//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//tbody/tr[1]/td[3]/select[@id = 'initialRows_0_projectActivityName']"));


                // Drop down actions comes under package Selenium.Support and we need to install the package
                new SelectElement(groupActivitiesDropDownSelectTag).SelectByText("RECUR0065 - ComLIMS-OFFER  Evolution and Maintenance");
                new SelectElement(activityNameDropDownSelectTag).SelectByValue("3560");


                // To get all header elements
                var tableHeaders = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//thead/tr//th")));
                var rowCount = 3;

                while (rowCount < tableHeaders.Count)
                {
                    var text1 = "//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//tbody/tr[1]//td[" + (rowCount + 1) + "]//input";
                    var hourTextBox = driver.FindElement(By.XPath("//div[@class = 'box editTimesheet noHeader']//div[@class = 'tableWrapper']//tbody/tr[1]//td[" + (rowCount + 1) + "]//input"));
                    if (tableHeaders[rowCount].Text.Contains("Sat") || tableHeaders[rowCount].Text.Contains("Sun"))
                    {
                        hourTextBox.SendKeys("0");
                        rowCount++;
                    }
                    else
                    {
                        hourTextBox.SendKeys("8");
                        rowCount++;
                    }
                }
            }
        }
    }
}