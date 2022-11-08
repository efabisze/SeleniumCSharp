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
    class ProductAddedPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Webelements
        /// </summary>

        public ProductAddedPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "login")]
        [CacheLookup]
        private IWebElement signinButton;

        [FindsBy(How = How.Id, Using = "layer_cart")]
        [CacheLookup]
        private IWebElement addedCartPage;


        private By successMessage = new ByChained(By.TagName("h2"));
        private By productAddedName = new ByChained(By.ClassName("layer_cart_product_title"));
        private By productAddedColorSize = new ByChained(By.ClassName("layer_cart_product_attributes"));
        private By productAddedQuantity = new ByChained(By.Id("layer_cart_product_quantity"));
        private By productAddedPrice = new ByChained(By.ClassName("layer_cart_product_price"));

        private By totalProductsElement = new ByChained(By.ClassName("ajax_block_products_total"));
        private By totalShippingElement = new ByChained(By.ClassName("ajax_cart_shipping_cost"));
        private By totalElement = new ByChained(By.ClassName("ajax_block_cart_total"));
        private By continueShoppingButton = new ByChained(By.CssSelector(".continue.btn.btn-default.button.exclusive-medium"));
        private By proceedToCheckoutButton = new ByChained(By.CssSelector(".btn.btn-default.button.button-medium"));

        /// <summary>
        /// Functions section//////////////////////
        /// </summary>
        /// 

        // Returns the Page Title

        public ProductAddedPage verifySuccessAdded(Product product, string totalProducts, string totalShipping, string total)
        {
            Assert.That(addedCartPage.FindElement(successMessage).Text, Is.EqualTo("Product successfully added to your shopping cart"));
            Assert.That(addedCartPage.FindElement(productAddedName).Text, Is.EqualTo(product.ProductName));
            Assert.That(addedCartPage.FindElement(productAddedQuantity).Text, Is.EqualTo(product.Quantity.ToString()));
            Assert.That(addedCartPage.FindElement(productAddedPrice).Text, Is.EqualTo(product.UnitPrice));

            if (product.Size != null || product.Color != null)
                Assert.That(addedCartPage.FindElement(productAddedColorSize).Text, Is.EqualTo(product.Color + "," + product.Size));
            else
                productAddColorAndSize(product, addedCartPage.FindElement(productAddedColorSize).Text);

            Assert.That(addedCartPage.FindElement(totalProductsElement).Text, Is.EqualTo(totalProducts));
            Assert.That(addedCartPage.FindElement(totalShippingElement).Text, Is.EqualTo(totalShipping));
            Assert.That(addedCartPage.FindElement(totalElement).Text, Is.EqualTo(total));

            return this;
        }

        public ProductAddedPage clickContinueShoppping()
        {
            addedCartPage.FindElement(continueShoppingButton).Click();
            return this;
        }

        public ProductAddedPage clickProceedToCheckout()
        {
            addedCartPage.FindElement(proceedToCheckoutButton).Click();
            return this;
        }




        /// <summary>
        /// Helper if the product is added from homepage, wont know color or size before added 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="colorSize"></param>
        public void productAddColorAndSize(Product product, string colorSize)
        {
            string[] colorAndSize = colorSize.Split(',');
            product.Color = colorAndSize[0];
            product.Size = colorAndSize[1];

            return;
        }
    }
}