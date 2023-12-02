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
    internal class PopeesHomePage 
    {
        IWebDriver? driver;
        DefaultWait<IWebDriver> wait;
        public PopeesHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMicroseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
        }
       
        [FindsBy(How = How.XPath, Using = "(//a[contains(@class,'cdz-top-link')])[position()=3]")]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@class='input-text'])[position()='1']")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "(//li[contains(@class,'maternityMM')])//a[@class='menu-link']")]
        [CacheLookup]
        private IWebElement? DressSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "(//li[contains(@class,'boysMM')])[2]")]
        [CacheLookup]
        private IWebElement? SelectFrock { get; set; }

        [FindsBy(How = How.XPath, Using = "(//li[contains(@class,'boysMM')])[1]")]
        private IWebElement? SelectBoy { get; set; }
        [FindsBy(How = How.XPath, Using = "(//a[contains(@class,'cdz-top-link')])[position()=5]")]
        private IWebElement? SelectCart { get; set; }
        

        public SignInHomePage ClickCreateAccountLink()
        {
            CreateAccountLink?.Click();
            return new SignInHomePage(driver);
        }

        public SearchResultsPage TypeSearchInput(string searchText)
        {
            SearchInput?.SendKeys(searchText);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);

        }
        public AddWishlistPage ClickDressSelect()
        {
            DressSelect?.SendKeys(Keys.Enter);
            return new AddWishlistPage(driver);
        }

        public RemoveProductPage ClickSelectFrock()
        {
            SelectFrock?.Click();
            return new RemoveProductPage(driver);
        }

       

        public AddWishlistPage ClickNewbornselect()
        {
            SelectBoy?.Click();
            return new AddWishlistPage(driver);

        }

        public void ClickSelectCartBtn()
        {
            wait.Until(d => SelectCart.Displayed);
            SelectCart?.SendKeys(Keys.Enter);
        }
    }
}
