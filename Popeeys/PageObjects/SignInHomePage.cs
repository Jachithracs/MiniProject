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
    internal class SignInHomePage
    {
        IWebDriver? driver;
        public SignInHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//input[@id='email'])[position()='2']")]
        [CacheLookup]
        private IWebElement? EmailInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@id='passw'])")]
        [CacheLookup]
        private IWebElement? PasswordInputBox { get; set; }


        [FindsBy(How = How.XPath, Using = "(//button[@name='send'])[position()='2']")]
        [CacheLookup]
        private IWebElement? LoginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='maincontent']/div[3]/div/div[2]/div[3]/div/span[2]/a")]
        [CacheLookup]
        private IWebElement? CreateNewCustomerAccount { get; set; }

        public PopeesHomePage SignInClick(string email,string password)
        {
            /*
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMicroseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "element not found";
            */
            //wait.Until(d =>EmailInputBox?.Displayed);
            EmailInputBox?.SendKeys(email);
           // wait.Until(d => PasswordInputBox?.Displayed);
            PasswordInputBox?.SendKeys(password);

            //wait.Until(d => LoginBtn?.Displayed);
            LoginBtn?.Click();          
            return new PopeesHomePage(driver);
        }

        public CustomerLoginPage ClickCreateCustomerAccount()
        {
            /*
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMicroseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "element not found";
            */
            //wait.Until(d => CreateNewCustomerAccount?.Displayed);
            CreateNewCustomerAccount?.SendKeys(Keys.Enter);
            return new CustomerLoginPage(driver);
        }
    }

}
