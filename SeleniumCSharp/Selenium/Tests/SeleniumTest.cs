using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumCSharp.Selenium.Pages;

namespace SeleniumCSharp.Selenium.Tests

{

    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class SeleniumTest<TWebDriver> where TWebDriver : IWebDriver, new()

    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()

        {
                this.driver = new TWebDriver();

            // string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            // driver = new ChromeDriver(path + @"\drivers\");

        }

        [Test]
        [Category("Regression")]
        public void verifyLogin()

        {
            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            home_page.clickSignin();

            SigninPage signin_page = new SigninPage(driver);
            signin_page.enterCredentials("efab@test.com", "Test1234");
            signin_page.clickSignin();

            MyAccountPage account_page = new MyAccountPage(driver);
            account_page.verifyMyAccountPage();

        }


        [Test]
        [Category("Regression")]
        public void verifyAddingToCart()

        {
            Product product = new Product();

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            product = home_page.addRandomProdToCart();
            home_page.verifyCartCount(product);
        }

        [Test]
        [Category("Regression")]

        public void verifyRemovingFromCart()

        {
            Product product = new Product();

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            product = home_page.addRandomProdToCart();
            home_page.verifyCartCount(product);

        }

        [Test]
        [Category("Regression")]
        public void verifyAddingToWishList()

        {
            Product product = new Product();
            product.ProductName = "Printed Chiffon Dress";
            product.UnitPrice = "$16.40";

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            home_page.clickSignin();

            SigninPage signinPage = new SigninPage(driver);
            signinPage.enterCredentials("efab@test.com", "Test1234");

            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            searchResultsPage.searchProducts(product.ProductName);
            searchResultsPage.addProductToWishlist(product);
            searchResultsPage.goToMyAccount();

            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.clickWishList();

            MyWishlistPage myWishlistPage = new MyWishlistPage(driver);
            myWishlistPage.verifyProductInWishlist(product);
        }

        [Test]
        [Category("Regression")]
        public void verifyRemovingToWishList()

        {

            Product product = new Product();
            product.ProductName = "Printed Chiffon Dress";
            product.UnitPrice = "$16.40";

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            home_page.clickSignin();

            SigninPage signinPage = new SigninPage(driver);
            signinPage.enterCredentials("efab@test.com", "Test1234");

            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            searchResultsPage.searchProducts(product.ProductName);
            searchResultsPage.addProductToWishlist(product);
            searchResultsPage.goToMyAccount();

            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.clickWishList();

            MyWishlistPage myWishlistPage = new MyWishlistPage(driver);
            myWishlistPage.removeProductFromWishlist(product);
            myWishlistPage.productNotInWishlist(product);
        }

        [Test]
        [Category("Regression")]
        public void verifySearching()

        {

            Product product = new Product();
            product.ProductName = "Printed Chiffon Dress";
            product.UnitPrice = "$16.40";

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            home_page.searchProducts(product.ProductName);

            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            searchResultsPage.verifyProductInResults(product);
        }

        [Test]
        [Category("Checkout")]
        [Category("Regression")]
        public void verifyCheckout()

        {
            Product product = new Product();

            HomePage home_page = new HomePage(driver);
            home_page.goToPage();
            product = home_page.addRandomProdToCart();

            home_page.goToCart();
            OrderPage orderPage = new OrderPage(driver);
            orderPage.clickProceedToCheckout();

            SigninPage signin_page = new SigninPage(driver);
            signin_page.enterCredentials("efab@test.com", "Test1234");
            signin_page.clickSignin();

            OrderAddressPage orderAddressPage = new OrderAddressPage(driver);
            orderAddressPage.clickProceedToCheckoutButton();

            OrderShippingPage orderShippingssPage = new OrderShippingPage(driver);
            orderShippingssPage.clickAgreeToTerms();
            orderShippingssPage.clickProceedToCheckoutButton();

            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(driver);
            orderPaymentPage.clickPayByCheck();

            OrderCheckPaymentPage orderCheckPaymentPage = new OrderCheckPaymentPage(driver);
            orderCheckPaymentPage.clickConfirmOrder();
            orderCheckPaymentPage.verifySuccessMessage();
            orderCheckPaymentPage.verifyPaymentAmount(product.UnitPrice);
        }


        [TearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}
