using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popeeys.PageObjects
{
    internal class RemoveProductPage
    {
        IWebDriver? driver;
        public RemoveProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//label[@for='filter-cat-7']")]
        private IWebElement? SelectAccessories { get; set; }

        [FindsBy(How = How.LinkText, Using = "Trending Ginjo Cap for Unisex")]
        private IWebElement? SelectCap { get; set; }
        [FindsBy(How = How.XPath, Using = "(//button[@class='action tocart primary'])[1]")]
        private IWebElement? SelectAddToCart { get; set; }

        [FindsBy(How = How.Id, Using = "option-label-color_swatch-187-item-54")]
        private IWebElement? SelectColour { get; set; }
        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        private IWebElement? SelectAddCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class='action primary checkout']")]
        private IWebElement? CheckoutDetails { get; set; }
        
        

        public void ClickSelectCap()
        {
            SelectCap?.SendKeys(Keys.Enter);
        }
        public void ClickSelectAddToCart()
        {
            SelectAddToCart?.SendKeys(Keys.Enter);
        }
        public void ClickSelectColour()
        {
            SelectColour?.SendKeys(Keys.Enter);
        }
        public void ClickSelectAddCart()
        {
            SelectAddCart?.SendKeys(Keys.Enter);
        }
        public SearchResultsPage ClickCheckoutDetails()
        {
            CheckoutDetails?.Click();
            return new SearchResultsPage(driver);

        }
        public void ClickSelectAccessories()
        {
            SelectAccessories?.Click();
        }

    }
}
