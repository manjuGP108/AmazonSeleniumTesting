using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApplication3
{
    [TestClass]
    public class Program
    {
        private static readonly IWebDriver Driver = new ChromeDriver();

        [TestMethod]
        public void IjavaScriptExecuterTesting()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.in");
            var querry = "document.getElementById('twotabsearchtextbox').value = 'test'";
            var querry2 = "document.getElementsByClassName('nav-input')[0].click()";
            JavaScriptExecutor(querry);
            JavaScriptExecutor(querry2);
        }

        public static object JavaScriptExecutor(string querry)
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(querry);
        }
    }
}