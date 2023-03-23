using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class ProductFunctionality
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
        public void TestSortingFunctionality()
        {
            // Login with valid credentials
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Navigate to the Products page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");


            // Verify that the products are sorted correctly
            var productPrices = driver.FindElements(By.CssSelector(".inventory_item_price"));
            for (int i = 1; i < productPrices.Count; i++)
            {
                var previousPrice = double.Parse(productPrices[i - 1].Text.Substring(1));
                var currentPrice = double.Parse(productPrices[i].Text.Substring(1));
                Assert.IsTrue(previousPrice <= currentPrice);
            }
        }

        [Test]
        public void TestAddProductToCart()
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

            // Verify that the cart badge is updated to 1
            var cartBadge = driver.FindElement(By.CssSelector(".shopping_cart_badge"));
            Assert.AreEqual("1", cartBadge.Text);
        }

        [Test]
        public void TestRemoveProductFromCart()
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

            // Remove the product from the cart
            driver.FindElement(By.CssSelector(".cart_item")).FindElement(By.CssSelector(".btn_secondary")).Click();

            // Verify that the cart is empty
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='cart_list']")).Text.Contains("Your cart is empty"));
        }
    }
}
