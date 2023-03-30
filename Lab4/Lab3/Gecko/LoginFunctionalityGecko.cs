using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class LoginFunctionalityGecko
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void TestLoginWithValidCredentials()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Enter valid credentials
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input")).SendKeys("standard_user");
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input")).SendKeys("secret_sauce");

            // Click the login button
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input")).Click();

            // Verify that the user is logged in successfully
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
        }

        [Test]
        public void TestLoginWithInvalidCredentials()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Enter valid credentials
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input")).SendKeys("standard_user");
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input")).SendKeys("secret_sauce");

            // Click the login button
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input")).Click();

            // Verify that the user is not logged in and an error message is displayed
            Assert.IsTrue(driver.FindElement(By.CssSelector("h3[data-test='error']")).Displayed);
        }
    }
}
