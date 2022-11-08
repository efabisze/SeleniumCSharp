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
    class OrderPaymentPage
    {
        String test_url = "http://automationpractice.com/index.php?controller=order&multi-shipping=";

        private IWebDriver driver;
        private WebDriverWait wait;

        public OrderPaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "bankwire")]
        [CacheLookup]
        private IWebElement payByBankWire;

        [FindsBy(How = How.ClassName, Using = "cheque")]
        [CacheLookup]
        private IWebElement payByCheck;

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
        public void clickPayByCheck()
        {
            payByCheck.Click();
        }
        public void clickPayByBankWire()
        {
            payByCheck.Click();
        }

    }
}