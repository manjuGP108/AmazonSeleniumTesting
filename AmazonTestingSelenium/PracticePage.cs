using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPracticeSolution
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);
            // By Xpath
            //driver.FindElement(By.XPath("//*[@id= 'content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[5]/a")).Click();
            //System.Threading.Thread.Sleep(2000);
            // By CSS Selector
            //driver.FindElement(By.CssSelector("#content > div.vc_row.wpb_row.vc_row-fluid.dt-default > div > div > div > div.wpb_text_column.wpb_content_element > div > form > fieldset > div:nth-child(8) > a")).Click();
            //driver.Navigate().Back();
            driver.FindElement(By.Name("firstname")).SendKeys("Manjunath");
            //System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@name = 'lastname']")).SendKeys("Padasalagi");
            driver.FindElement(By.XPath("//input[@value = 'Male']")).Click();
            //var yearsOfExp = driver.FindElement(By.XPath("//label[text()='Years of Experience']"));
            var yearsOfExp = driver.FindElement(By.XPath("//label[@for = 'exp']"));
            yearsOfExp.FindElement(By.XPath("//input[@value = '2']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'datepicker']")).SendKeys("08/07/1993");
            var profession = driver.FindElement(By.XPath("//label[@for = 'profession']"));
            profession.FindElement(By.XPath("//input[@value = 'Manual Tester']")).Click();
            profession.FindElement(By.XPath("//input[@value = 'Automation Tester']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'photo']")).Click();
            Thread.Sleep(2000);
            //driver.SwitchTo().ActiveElement();
            SendKeys.SendWait("20-07-2017 9-28 PM.jpg");
            Thread.Sleep(2000);
            SendKeys.SendWait("{ENTER}");
            driver.FindElement(By.LinkText("Test File to Download")).Click();
            var automationToolsGroup = driver.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[29]"));
            automationToolsGroup.FindElement(By.Id("tool-0")).Click();
            driver.FindElement(By.XPath("//input[@value = 'Selenium IDE']")).Click();
            automationToolsGroup.FindElement(By.XPath("//input[@value = 'Selenium Webdriver']")).Click();
            var Continents = driver.FindElement(By.XPath("//select[@id = 'continents']/option[4]"));
            Continents.Click();
            //var Continents1 = driver.FindElement(By.XPath("//select[@id = 'continents']/option[@value = 'Australia']"));
            //var Continents2 = driver.FindElement(By.XPath("//select[@id = 'continents']/option[4]"));
            var multiSelect = driver.FindElement(By.XPath("//select[@id = 'selenium_commands']"));
            var navigationCommands = driver.FindElement(By.XPath("//select[@id = 'selenium_commands']/option[2]"));
            var waitCommand = driver.FindElement(By.XPath("//select[@id = 'selenium_commands']/option[4]"));
            var webElementCommand = driver.FindElement(By.XPath("//select[@id = 'selenium_commands']/option[5]"));
            //Actions builder = new Actions(driver);
            //builder.Click(navigationCommands);
            //builder.Click(waitCommand);
            //builder.Click(webElementCommand);
            //builder.Build().Perform();

            // Multiple Selection web elements
            var isMultiSelectElement = new SelectElement(multiSelect).IsMultiple;
            if (isMultiSelectElement)
            {
                new SelectElement(multiSelect).SelectByIndex(1);
                new SelectElement(multiSelect).SelectByIndex(3);
            }
        }
    }
}