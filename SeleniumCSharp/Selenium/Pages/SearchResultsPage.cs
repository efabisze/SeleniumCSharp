using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
using SeleniumExtras.PageObjects;

namespace SeleniumCSharp.Selenium.Pages
{
    class SearchResultsPage : BasePage
    {
        String test_url = "http://automationpractice.com/";

        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Webelements
        /// </summary>

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".product_list.grid.row")]
        [CacheLookup]
        private IWebElement productsTable;

        [FindsBy(How = How.Id, Using = "homefeatured")]
        [CacheLookup]
        private IWebElement featuredProductsTable;


        [FindsBy(How = How.CssSelector, Using = ".fancybox-overlay.fancybox-overlay-fixed")]
        [CacheLookup]
        private IWebElement overlayPage;

        private By productContainers = new ByChained(By.ClassName("product-container"));
        private By productToAddName = new ByChained(By.ClassName("product-name"));
        private By productToAddPrice = new ByChained(By.CssSelector(".price.product-price"));

         private By productAddToCartButton = new ByChained(By.CssSelector(".button.ajax_add_to_cart_button.btn.btn-default"));
        private By productAddToWishList = new ByChained(By.ClassName("wishlist"));

        private By addedWishlist = new ByChained(By.ClassName("fancybox-error"));
        private By addedWishlistCloseButton = new ByChained(By.CssSelector(".fancybox-item.fancybox-close"));


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

        public void addProductToWishlist(Product product)
        {
            List<IWebElement> prodOptions = featuredProductsTable.FindElements(productContainers).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productToAddName).Text == product.ProductName);

            matches.First().FindElement(productAddToWishList).Click();

            overlayPage.FindElement(addedWishlistCloseButton).Click();
        }
        public void verifyProductInResults(Product product)
        {
            List<IWebElement> prodOptions = featuredProductsTable.FindElements(productContainers).ToList();
            var matches = prodOptions.Where(p => p.FindElement(productToAddName).Text == product.ProductName);

            Assert.That(matches.Count, Is.EqualTo(1));
        }
        public void closeWishlistAdd() 
        {
            overlayPage.FindElement(addedWishlistCloseButton).Click();
        }
    }
}