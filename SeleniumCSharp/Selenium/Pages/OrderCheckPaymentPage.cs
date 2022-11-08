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
    class OrderCheckPaymentPage
    {
        String test_url = "http://automationpractice.com/index.php?controller=order&multi-shipping=";

        private IWebDriver driver;
        private WebDriverWait wait;

        public OrderCheckPaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "amount")]
        [CacheLookup]
        private IWebElement totalAmount;

        [FindsBy(How = How.CssSelector, Using = ".button.btn.btn-default.button-medium")]
        [CacheLookup]
        private IWebElement confirmOrderButton;

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success")]
        [CacheLookup]
        private IWebElement orderSuccessMessage;
        
        [FindsBy(How = How.ClassName, Using = "price")]
        [CacheLookup]
        private IWebElement confirmedPaymentAmount;

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
        public void verifyAmount(string expectedAmount)
        {
            Assert.That(totalAmount.Text, Is.EqualTo(expectedAmount));
        }
        public void clickConfirmOrder()
        {
            confirmOrderButton.Click();
        }
        public void verifySuccessMessage()
        {
            Assert.That(orderSuccessMessage.Text, Is.EqualTo("Your order on My Store is complete."));
        }

        public void verifyPaymentAmount(string expectedPayment)
        {
            Assert.That(confirmedPaymentAmount.Text, Is.EqualTo(expectedPayment));
        }
    }
}