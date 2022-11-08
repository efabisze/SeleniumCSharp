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
using System;
using OpenQA.Selenium.Interactions;
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
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCSharp.Selenium.Pages
{

    class BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Cart")]
        [CacheLookup]
        private IWebElement viewCartButton;

        [FindsBy(How = How.ClassName, Using = "ajax_cart_quantity")]
        [CacheLookup]
        private IWebElement cartCount;


        [FindsBy(How = How.ClassName, Using = "shopping_cart")]
        [CacheLookup]
        private IWebElement dropdownCart;

        [FindsBy(How = How.ClassName, Using = ".cart_block_shipping_cost.ajax_cart_shipping_cost")]
        [CacheLookup]
        private IWebElement dropdownCartShipping;

        [FindsBy(How = How.ClassName, Using = ".price.cart_block_total.ajax_block_cart_total")]
        [CacheLookup]
        private IWebElement dropdownCartTotal;

        [FindsBy(How = How.Id, Using = "button_order_cart")]
        [CacheLookup]
        private IWebElement dropdownCheckoutButton;

        [FindsBy(How = How.Id, Using = "search_query_top")]
        [CacheLookup]
        private IWebElement searchInput;

        [FindsBy(How = How.ClassName, Using = "submit_search")]
        [CacheLookup]
        private IWebElement searchButton;

        [FindsBy(How = How.ClassName, Using = "class")]
        [CacheLookup]
        private IWebElement myAccountButton;


        private By dropdownProductsBlocks= new ByChained(By.ClassName("products")); 
        private By dropdownProdPrice = new ByChained(By.ClassName("price"));
        private By dropdownProdColorSize = new ByChained(By.ClassName("product-atributes"));
        private By dropdownProdQuantity = new ByChained(By.ClassName("quantity"));
        private By dropdownProdImage = new ByChained(By.ClassName("cart-images"));



        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }
        public void hoverCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(dropdownProdQuantity));

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public void verifyCartCount(Product product)
        {
            Assert.IsTrue(cartCount.Displayed);
            Assert.IsTrue(cartCount.Text.Equals(product.Quantity));
        }

        public void goToCart()
        {
            dropdownCart.Click();
        }

        public void searchProducts(string searchString)
        {
            searchInput.SendKeys(searchString);
            searchButton.Click();
        }

        public void goToMyAccount()
        {
            myAccountButton.Click();
        }

    }
}