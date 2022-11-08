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
    class SigninPage
    {
        String test_url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

        private IWebDriver driver;
        private WebDriverWait wait;

        public SigninPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private IWebElement emailInput;
        

        [FindsBy(How = How.Id, Using = "passwd")]
        [CacheLookup]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        [CacheLookup]
        private IWebElement signInButton;



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
        public SigninPage enterCredentials(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            return new SigninPage(driver);

        }

        public SigninPage clickSignin()
        {
            signInButton.Click();
            return new SigninPage(driver);

        }
    }
}