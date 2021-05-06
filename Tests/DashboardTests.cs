using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestClass]
    public class DashboardTests
    {
        /// <summary>
        /// Tests the content of the Dashboard: Buttons and title
        /// </summary>
        [TestMethod]
        public void ContentCheck()
        {

            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == "https://localhost:5001/Dashboard/Index");

            string expectedTitle = "Dashboard - AppAdeptsApp";

            //Chat
            driver.FindElementByXPath("/html/body/div[1]/ul/li[2]/a");
            //Submit Issue
            driver.FindElementByXPath("/html/body/div[1]/ul/li[3]/a");
            //Logout
            driver.FindElementByXPath("/html/body/div[1]/a");

            Assert.IsTrue(driver.Title == expectedTitle);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests after login, user can navigate to Chat page both url and button
        /// </summary>
        [TestMethod]
        public void NavigateToChat()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";
            string chatUrl = "https://localhost:5001/Chat/Index";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);

            driver.FindElementByXPath("/html/body/div[1]/ul/li[2]/a").Click();
            wait.Until(wt => wt.Url == chatUrl);

            driver.Navigate().GoToUrl(dashUrl);
            driver.Navigate().GoToUrl(chatUrl);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests after login, user can navigate to Submit page both url and button
        /// </summary>
        [TestMethod]
        public void NavigateToSubmit()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";
            string submitUrl = "https://localhost:5001/Submit/Index";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);

            driver.FindElementByXPath("/html/body/div[1]/ul/li[3]/a").Click();
            wait.Until(wt => wt.Url == submitUrl);

            driver.Navigate().GoToUrl(dashUrl);
            driver.Navigate().GoToUrl(submitUrl);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests after login, user can navigate to Edit
        /// </summary>
        [TestMethod]
        public void NavigateToEdit()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);
            
            driver.FindElementByXPath("/html/body/div[2]/div/div/div[1]/a").Click();
            wait.Until(wt => wt.Url.Contains("Edit/Index"));

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if a user can logout
        /// </summary>
        [TestMethod]
        public void Logout()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);

            driver.FindElementByXPath("/html/body/div[1]/a").Click();
            wait.Until(wt => wt.Url == url);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if a user can logout, then navigate to Dashboard
        /// </summary>
        [TestMethod]
        public void LogoutNavigateToDashboard()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);

            driver.FindElementByXPath("/html/body/div[1]/a").Click();
            wait.Until(wt => wt.Url == url);

            driver.Navigate().GoToUrl(dashUrl);
            wait.Until(wt => wt.Url == url);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if a user can logout, then navigate to Chat
        /// </summary>
        [TestMethod]
        public void LogoutNavigateToChat()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";
            string chatUrl = "https://localhost:5001/Chat/Index";

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);

            driver.FindElementByXPath("/html/body/div[1]/a").Click();
            wait.Until(wt => wt.Url == url);

            driver.Navigate().GoToUrl(chatUrl);
            wait.Until(wt => wt.Url == url);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if a user can logout, then navigate to Submit
        /// </summary>
        [TestMethod]
        public void LogoutNavigateToSubmit()
        {
            string url = "https://localhost:5001/";
            string dashUrl = "https://localhost:5001/Dashboard/Index";
            string submitUrl = "https://localhost:5001/Submit/Index";

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == dashUrl);

            driver.FindElementByXPath("/html/body/div[1]/a").Click();
            wait.Until(wt => wt.Url == url);

            driver.Navigate().GoToUrl(submitUrl);
            wait.Until(wt => wt.Url == url);

            driver.Close();
            driver.Dispose();
        }
    }
}
