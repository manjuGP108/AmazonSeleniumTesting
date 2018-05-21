using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class IFrame
    {
        [TestMethod]
        public void testing_IFrame()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            var numberOfIFrames = driver.FindElements(By.TagName("iframe")).Count;
            driver.SwitchTo().Frame("a077aa5e");
            driver.FindElement(By.XPath("/html/body/a/img")).Click();
        }
    }
}