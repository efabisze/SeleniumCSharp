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
using System.Diagnostics;

namespace SeleniumCSharp.Selenium.Pages
{
    class HomePage : BasePage
    {
        String test_url = "http://automationpractice.com/";

        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Webelements
        /// </summary>

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "login")]
        [CacheLookup]
        private IWebElement signinButton;

        [FindsBy(How = How.Id, Using = "homefeatured")]
        [CacheLookup]
        private IWebElement featuredProductsTable;


        private By featuredProducts = new ByChained(By.ClassName("product-container"));
        private By productToAddName = new ByChained(By.ClassName("product-name"));
        //     private By productToAddPrice = new ByChained(By.CssSelector("price"));
        private By productToAddPrice = new ByChained(By.CssSelector(".price.product-price"));

         private By productAddToCartButton = new ByChained(By.CssSelector(".button.ajax_add_to_cart_button.btn.btn-default"));


        /// <summary>
        /// Functions section//////////////////////
        /// </summary>
        /// 
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

        public SigninPage clickSignin()
        {
            signinButton.Click();
            return new SigninPage(driver);

        }

        public Product addRandomProdToCart()
        {
            Random rnd = new Random();
            List<IWebElement> prodOptions = featuredProductsTable.FindElements(featuredProducts).ToList();
            int r = rnd.Next(prodOptions.Count);

            Product product = new Product();
            product.ProductName = prodOptions[r].FindElement(productToAddName).Text;
            //There are 2 separate prices, one is invisible
            product.UnitPrice = prodOptions[r].FindElement(By.CssSelector(".right-block")).FindElement(productToAddPrice).Text;
            
            //Using in case added random item that already is in cart
            product.Quantity = (product.Quantity == null) ? 1 : product.Quantity + 1;

            prodOptions[r].FindElement(productAddToCartButton).Click();

            return product;
        }
    }
}