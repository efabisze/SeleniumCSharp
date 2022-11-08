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
    class MyAccountPage
    {
        String test_url = "http://automationpractice.com/index.php?controller=my-account";

        private IWebDriver driver;
        private WebDriverWait wait;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "page-heading")]
        [CacheLookup]
        private IWebElement myAccountHeader;

        [FindsBy(How = How.ClassName, Using = "lnk_wishlist")]
        [CacheLookup]
        private IWebElement wishlist;

        
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
        public void verifyMyAccountPage()
        {
            Assert.IsTrue(myAccountHeader.Displayed);
            Assert.IsTrue(myAccountHeader.Text.Equals("MY ACCOUNT"));
        }

        public void clickWishList()
        {
            wishlist.Click();
        }
    }
}