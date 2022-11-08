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
    class OrderAddressPage
    {
        String test_url = "http://automationpractice.com/index.php?controller=order&step=1&multi-shipping=0";

        private IWebDriver driver;
        private WebDriverWait wait;

        public OrderAddressPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "processAddress")]
        [CacheLookup]
        private IWebElement proceedToCheckoutButton;


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
        public void clickProceedToCheckoutButton()
        {
            proceedToCheckoutButton.Click();
        }
        

    }
}