﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static readonly IWebDriver driver = new ChromeDriver();

        private static void Main(string[] args)
        {
            driver.Navigate().GoToUrl("https://www.amazon.in");
            var querry = "document.getElementById('twotabsearchtextbox').value = 'test'";
            var querry2 = "document.getElementsByClassName('nav-input')[0].click()";
            JavaScriptExecutor(querry);
            JavaScriptExecutor(querry2);
        }

        public static object JavaScriptExecutor(string querry)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(querry);
        }
    }
}