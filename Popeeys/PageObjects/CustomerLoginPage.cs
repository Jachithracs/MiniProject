using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Popeeys.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popeeys.PageObjects
{
    internal class CustomerLoginPage
    {
        IWebDriver? driver;
        public CustomerLoginPage(IWebDriver? driver) 
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='firstname']")]
        [CacheLookup]
        private IWebElement? FirstNameInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='lastname']")]
        [CacheLookup]
        private IWebElement? LastNameInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='mobile_number']")]
        [CacheLookup]
        private IWebElement? MobileInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email_address']")]
        [CacheLookup]
        private IWebElement? EmailInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        [CacheLookup]
        private IWebElement? PasswordInputBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='password-confirmation']")]
        [CacheLookup]
        private IWebElement? ConfirmPasswordInputBox { get; set; }
      

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]  
        [CacheLookup]
        private IWebElement? LoginButton { get; set; }

        public void ClickLoginButton(string firstName, string lastName, string mobileNumber,string email,
            string password, string confirmPassword)
        {

            FirstNameInputBox?.SendKeys(firstName);
            LastNameInputBox?.SendKeys(lastName);
            MobileInputBox?.SendKeys(mobileNumber);
            CoreCode.ScrollIntoView(driver, EmailInputBox);
            EmailInputBox?.SendKeys(email);           
            PasswordInputBox?.SendKeys(password);         
            ConfirmPasswordInputBox?.SendKeys(confirmPassword);
            LoginButton?.SendKeys(Keys.Enter);
            

        }

    }
}
