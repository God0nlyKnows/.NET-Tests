using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class LoginFunctionality
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArguments("start-maximized");

            driver = new EdgeDriver(options);
        }

        [Test]
        public void TestLoginWithValidCredentials()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Enter valid credentials
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");

            // Click the login button
            driver.FindElement(By.Id("login-button")).Click();

            // Verify that the user is logged in successfully
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
        }

        [Test]
        public void TestLoginWithInvalidCredentials()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Enter invalid credentials
            driver.FindElement(By.Id("user-name")).SendKeys("invalid_user");
            driver.FindElement(By.Id("password")).SendKeys("invalid_password");

            // Click the login button
            driver.FindElement(By.Id("login-button")).Click();

            // Verify that the user is not logged in and an error message is displayed
            Assert.IsTrue(driver.FindElement(By.CssSelector("h3[data-test='error']")).Displayed);
        }
    }
}
