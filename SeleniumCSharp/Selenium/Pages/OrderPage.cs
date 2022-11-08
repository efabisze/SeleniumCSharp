using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
using SeleniumExtras.PageObjects;

namespace SeleniumCSharp.Selenium.Pages
{
    class OrderPage : BasePage
    {
        String test_url = "http://automationpractice.com/";

        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Webelements
        /// </summary>

        public OrderPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "cart_summary")]
        [CacheLookup]
        private IWebElement featuredProductsTable;

        [FindsBy(How = How.Id, Using = "total_product")]
        [CacheLookup]
        private IWebElement productsTotal;

        [FindsBy(How = How.Id, Using = "total_shipping")]
        [CacheLookup]
        private IWebElement totalShipping;

        [FindsBy(How = How.Id, Using = "total_price_without_tax")]
        [CacheLookup]
        private IWebElement totalNoTax;

        [FindsBy(How = How.Id, Using = "total_tax")]
        [CacheLookup]
        private IWebElement taxElement;

        [FindsBy(How = How.Id, Using = "total_price")]
        [CacheLookup]
        private IWebElement cartTotal;

        [FindsBy(How = How.CssSelector, Using = ".button.btn.btn-default.standard-checkout.button-medium")]
        [CacheLookup]
        private IWebElement proceedToCheckout;

        private By cartItems = new ByChained(By.ClassName("cart_item"));
        private By productImage = new ByChained(By.ClassName("cart_product"));
        private By productDescription = new ByChained(By.ClassName("cart_description"));
        private By productName = new ByChained(By.ClassName("product-name"));
        private By productPrice = new ByChained(By.ClassName("cart_unit"));
        private By productQuantity = new ByChained(By.CssSelector(".cart_quantity.text-center"));
        private By productTotal = new ByChained(By.ClassName("cart_total"));
        private By trashIcon = new ByChained(By.ClassName("icon-trash"));

        /// <summary>
        /// Functions section//////////////////////
        /// </summary>
        /// 

        public void verifyProductInCart (Product product)
        {


        }
        public void verifyWholeCart(List<Product> productList)
        {


        }
        public void removeProductFromCart(Product product)
        {
            List<IWebElement> prodOptions = featuredProductsTable.FindElements(cartItems).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productDescription).FindElement(productName).Text == product.ProductName);

            matches.First().FindElement(trashIcon).Click();

        }
        public void verifyProductNotInCart(Product product)
        {
            List<IWebElement> prodOptions = featuredProductsTable.FindElements(cartItems).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productDescription).FindElement(productName).Text == product.ProductName);

            Assert.That(matches.Count, Is.EqualTo(0));

        }

        public void clickProceedToCheckout()
        {
            proceedToCheckout.Click();
        }
    }
}