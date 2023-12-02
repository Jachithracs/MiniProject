using OpenQA.Selenium;
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
            
            EmailInputBox?.SendKeys(email);
            PasswordInputBox?.SendKeys(password);

            LoginBtn?.Click();          
            return new PopeesHomePage(driver);
        }

        public CustomerLoginPage ClickCreateCustomerAccount()
        {        
            CreateNewCustomerAccount?.SendKeys(Keys.Enter);
            return new CustomerLoginPage(driver);
        }
    }

}
