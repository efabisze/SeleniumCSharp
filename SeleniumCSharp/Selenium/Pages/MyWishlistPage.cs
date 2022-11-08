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
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace SeleniumCSharp.Selenium.Pages
{
    class MyWishlistPage
    {
        String test_url = "http://automationpractice.com/index.php?controller=my-account";

        private IWebDriver driver;
        private WebDriverWait wait;

        public MyWishlistPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".page-table.table-bordered")]
        [CacheLookup]
        private IWebElement wishListNameTable;

        [FindsBy(How = How.ClassName, Using = ".wlp_bought")]
        [CacheLookup]
        private IWebElement wishListProductTable;
        
        private By wishList = new ByChained(By.LinkText("My Wishlist"));
        private By removeFromWishlist = new ByChained(By.ClassName("icon-remove-sign"));
        private By productContainer = new ByChained(By.ClassName("row"));
        private By productName = new ByChained(By.ClassName("product-name"));

        // Go to the designated page
        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

        // Returns the search string

        public void clickWishList()
        {
            wishListNameTable.FindElement(wishList).Click();
        }

        public void verifyProductInWishlist(Product product)
        {
            List<IWebElement> prodOptions = wishListProductTable.FindElements(productContainer).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productName).Text == product.ProductName);
            
            Assert.That(matches.Count, Is.EqualTo(1));
        }

        public void removeProductFromWishlist(Product product)
        {
            List<IWebElement> prodOptions = wishListProductTable.FindElements(productContainer).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productName).Text == product.ProductName);

            matches.First().FindElement(removeFromWishlist).Click();

        }

        public void productNotInWishlist(Product product)
        {
            List<IWebElement> prodOptions = wishListProductTable.FindElements(productContainer).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productName).Text == product.ProductName);

            Assert.That(matches.Count, Is.EqualTo(0));

        }
    }
}