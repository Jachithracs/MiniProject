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
    internal class AddWishlistPage
    {
        IWebDriver? driver;
        public AddWishlistPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//label[@for='filter-cat-0']")]
        private IWebElement? NightyCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='narrow-by-list']//li[2]")]
        private IWebElement? PriceCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='swatch-option text '])[position()='3']")]
        private IWebElement? SizeCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='cdz-checkbox-wrap']/input[@value=4]")]
        private IWebElement? RatingCheck { get; set; }

        [FindsBy(How = How.LinkText, Using = "Mw-W-To-02-Maternity Wear")]
        private IWebElement? SelectedDress { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-action='add-to-wishlist']")]
        private IWebElement? AddWishlist { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[contains(@class,'cdz-top-link')])[position()=4]")]
        private IWebElement? ViewAccount { get; set; }

        [FindsBy(How = How.XPath, Using = " (//li[@class='link wishlist'])[3]")]
        private IWebElement? ViewWishlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@class='main-logo hidden-xs']")]
        private IWebElement? Logoselect { get; set; }


        public void ClickNightyCheck()
        {
            NightyCheck?.Click();
            
        }
        public void ClickPriceCheck()
        {
            PriceCheck?.SendKeys(Keys.Enter);
            
        }
        public void ClickSizeCheck()
        {
            SizeCheck?.SendKeys(Keys.Enter);
            
        }
        public void ClickRatingCheck()
        {
            RatingCheck?.Click();
        }
        public void ClickSelectedDress()
        { 
            SelectedDress?.SendKeys(Keys.Enter);
        }
        public AddWishlistPage ClickAddWishlist()
        {
            CoreCode.ScrollIntoView(driver, AddWishlist);
            AddWishlist?.SendKeys(Keys.Enter);
            return new AddWishlistPage(driver);
        }
        public void ClickViewAccount()
        {
            ViewAccount?.SendKeys(Keys.Enter);
        }
        public void ClickViewWishlist()
        {
            ViewWishlist?.Click();
        }

        public PopeesHomePage ClickLogoSelect()
        {
            Logoselect?.Click();
            return new PopeesHomePage(driver);
        }

    }
}
