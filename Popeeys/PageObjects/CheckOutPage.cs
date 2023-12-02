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
    internal class CheckOutPage
    {
        IWebDriver? driver;
        public CheckOutPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Street Address: Line 1']")]
        [CacheLookup]
        private IWebElement? Address1InputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Street Address: Line 2']")]
        [CacheLookup]
        private IWebElement? Address2InputBox { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//option[@data-title='Kerala']")]
        [CacheLookup]
        private IWebElement? StateDropdown { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='City']")]
        [CacheLookup]
        private IWebElement? CityInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Zip/Postal Code']")]
        [CacheLookup]
        private IWebElement? ZipInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Phone Number']")]
        [CacheLookup]
        private IWebElement? PhoneNumberInputBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='continue_shipping']")]
        [CacheLookup]
        private IWebElement? ContinueBtn { get; set; }
        

        public CheckOutPage ClickLoginButton(string address1, string address2, string city, string zip,
            string phonenumber)
        {

            Address1InputBox?.SendKeys(address1);
            Address2InputBox?.SendKeys(address2);
            CityInputBox?.SendKeys(city);
            CoreCode.ScrollIntoView(driver, ZipInputBox);
            ZipInputBox?.SendKeys(zip);
            PhoneNumberInputBox?.SendKeys(phonenumber);
            ContinueBtn?.SendKeys(Keys.Enter);
            return new CheckOutPage(driver);

        }
        public void ClickStateDropDown()
        {
            StateDropdown?.Click();
        }

    }
}

