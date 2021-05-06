using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestClass]
    public class HomeTests
    {
        /// <summary>
        /// Tests the content of the Login page: Title, text boxes, and button
        /// </summary>
        [TestMethod]
        public void ContentCheck()
        {
            string expectedTitle = "Login - AppAdeptsApp";
            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            //Email
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input");
            //Password
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input");
            //Login Button
            driver.FindElementByXPath("/html/body/div/div[2]/form/button");

            Assert.IsTrue(driver.Title == expectedTitle);

            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Testing a successful login
        /// </summary>
        [TestMethod]
        public void SuccessfulLogin()
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
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// This test is to determine if no password will direct to the login after attempting
        /// </summary>
        [TestMethod]
        public void FailedLogin1()
        {
            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests a password with valid length, but no special characters
        /// </summary>
        [TestMethod]
        public void FailedLogin2()
        {
            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword11");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests a password with only invalid capital letters
        /// </summary>
        [TestMethod]
        public void FailedLogin3()
        {
            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@email.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testpassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests invalid email address without '@'
        /// </summary>
        [TestMethod]
        public void FailedLogin4()
        {
            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billrobertsemail.com");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests invalid email address withoug '.'
        /// </summary>
        [TestMethod]
        public void FailedLogin5()
        {
            string url = "https://localhost:5001/";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPath("/html/body/div/div[2]/form/div[1]/input").SendKeys("billroberts@emailcom");
            driver.FindElementByXPath("/html/body/div/div[2]/form/div[2]/input").SendKeys("testPassword1!");
            driver.FindElementByXPath("/html/body/div/div[2]/form/button").Click();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if before login, user can navigate to Chat page
        /// </summary>
        [TestMethod]
        public void NavigateToChat()
        {
            string url = "https://localhost:5001/";
            string navTo = "https://localhost:5001/Chat/Index";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(navTo);

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if before login, user can navigate to Dashboard
        /// </summary>
        [TestMethod]
        public void NavigateToDashboard()
        {
            string url = "https://localhost:5001/";
            string navTo = "https://localhost:5001/Dashboard/Index";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(navTo);

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if before login, user can navigate to Submit page
        /// </summary>
        [TestMethod]
        public void NavigateToSubmit()
        {
            string url = "https://localhost:5001/";
            string navTo = "https://localhost:5001/Submit/Index";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(navTo);

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }

        /// <summary>
        /// Tests if before login, user can navigate to Edit page
        /// </summary>
        [TestMethod]
        public void NavigateToEdit()
        {
            string url = "https://localhost:5001/";
            string navTo = "https://localhost:5001/Edit/Index";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(navTo);

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.Url == url);
            driver.Close();
            driver.Dispose();
        }
    }
}
