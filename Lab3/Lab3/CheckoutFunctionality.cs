using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class CheckoutFunctionality
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
        public void TestCheckoutWithOneItem()
        {
            // Login with valid credentials
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Navigate to the Products page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

            // Add the first product to the cart
            driver.FindElement(By.CssSelector(".btn_primary")).Click();

            // Navigate to the Cart page
            driver.FindElement(By.CssSelector(".shopping_cart_link")).Click();

            // Click the Checkout button
            driver.FindElement(By.CssSelector(".checkout_button")).Click();

            // Enter the checkout information
            driver.FindElement(By.Id("first-name")).SendKeys("John");
            driver.FindElement(By.Id("last-name")).SendKeys("Doe");
            driver.FindElement(By.Id("postal-code")).SendKeys("12345");

            // Click the Continue button
            driver.FindElement(By.CssSelector(".cart_button")).Click();

            // Verify that the user is on the Checkout: Overview page
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", driver.Url);
        }

        [Test]
        public void TestCompleteCheckoutProcess()
        {
            // Login with valid credentials
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Navigate to the Products page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

            // Add the first product to the cart
            driver.FindElement(By.CssSelector(".btn_primary")).Click();

            // Click the cart icon to go to the cart page
            driver.FindElement(By.CssSelector(".shopping_cart_link")).Click();

            // Click the Checkout button
            driver.FindElement(By.CssSelector(".btn_action.checkout_button")).Click();

            // Enter checkout information
            driver.FindElement(By.Id("first-name")).SendKeys("John");
            driver.FindElement(By.Id("last-name")).SendKeys("Doe");
            driver.FindElement(By.Id("postal-code")).SendKeys("12345");

            // Click the Continue button
            driver.FindElement(By.CssSelector(".btn_primary.cart_button")).Click();

            // Verify that the correct items are in the cart
            var items = driver.FindElements(By.CssSelector(".cart_item"));
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("Sauce Labs Backpack", items[0].FindElement(By.CssSelector(".cart_item_label a")).Text);

            // Click the Finish button
            driver.FindElement(By.CssSelector(".btn_action.cart_button")).Click();

            // Verify that the checkout complete message is displayed
            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", driver.Url);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".complete-header")).Displayed);
        }

        [Test]
        public void TestLogout()
        {
            // Login with valid credentials
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Click the menu icon
            driver.FindElement(By.CssSelector(".bm-burger-button")).Click();

            // Click the Logout button
            driver.FindElement(By.Id("logout_sidebar_link")).Click();

            // Verify that the user is logged out and on the login page
            Assert.AreEqual("https://www.saucedemo.com/", driver.Url);
        }
    }
}
