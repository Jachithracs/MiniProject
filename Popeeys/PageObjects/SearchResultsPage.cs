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
    internal class SearchResultsPage
    {
        IWebDriver? driver;
        public SearchResultsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//option[@value='created_at'])[1]")]
        private IWebElement? SortBy { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='filter-cat-2']")]
        private IWebElement? CheckboxFrock { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='filter-cat-4']")]
        private IWebElement? CheckboxNew { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='cdz-checkbox-wrap']/input[@value=5]")]
        private IWebElement? Rating { get; set; }

        [FindsBy(How = How.LinkText, Using = "Popees Stylish Red Color Skirt And Top For Girls | Ethnic Wear")]
        private IWebElement? SelectFrock { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='codvalue']")]
        private IWebElement? ZipInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "option-label-size-186-item-222")]
        private IWebElement? SizeCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='qty']")]
        private IWebElement? Quantity { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//button[@id='product-addtocart-button']")]
        private IWebElement? BuyNowButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='action primary checkout']")]
        private IWebElement? CheckoutDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "(//li[@class='item'])//button[@id='cart_checkout_btn']")]
        [CacheLookup]
        private IWebElement? PlaceOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='shopping-cart-table']//a[1]/span/i")]
        private IWebElement? RemoveProduct { get; set; }

        public void ClickSortBy()
        {
            SortBy?.Click();
        }
        public void ClickCheckbox()
        {
        
            CheckboxFrock?.Click();
        }
        public void ClickCheckboxNew()
        {
           
            CheckboxNew?.Click();
        }
        public void ClickRating()
        {
            CoreCode.ScrollIntoView(driver, Rating);
            Rating?.SendKeys(Keys.Enter);
        }
        public void ClickSelectFrock()
        {
            SelectFrock?.SendKeys(Keys.Enter);
            
        }

        public SearchResultsPage ClickZip(string? zip)
        {
           
            ZipInputBox?.SendKeys(zip);
            ZipInputBox?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }

        public void ClickSizeCheckBox()
        {
            

            SizeCheckBox?.Click();
        }

        public SearchResultsPage ClickQuantity(string? count)
        {
            Quantity?.Clear();
            Quantity?.SendKeys(count);
            return new SearchResultsPage(driver);
        }

        public void ClickAddToCart()

        {
            BuyNowButton?.SendKeys(Keys.Enter);
            
        }
        public SearchResultsPage ClickCheckoutDetails()
        {
           
            CheckoutDetails?.Click();
          
            return new SearchResultsPage(driver);
        }
        public CheckOutPage ClickPlaceOrderBtn()
        {
            PlaceOrderBtn?.SendKeys(Keys.Enter);
            return new CheckOutPage(driver);
        }
        public void ClickRemoveProduct()
        {
            RemoveProduct?.Click();

        }

    }
}

