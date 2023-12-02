using OpenQA.Selenium;
using Popeeys.PageObjects;
using Popeeys.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popeeys.TestScripts
{
    [TestFixture, Order(2)]
    internal class SearchProductTests : CoreCode
    {
        [Test]
        [Category("End-to-End Testing")]
        public void SearchFrockAndAddToCart()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            PopeesHomePage popeesHome = new PopeesHomePage(driver);
            var signin = popeesHome.ClickCreateAccountLink();
            //Thread.Sleep(4000);
            Log.Information("Searching for product is started");
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "SignIn";

            List<ExcelDataSignIn> excelDataList = ExcelUtils.ReadSignInExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? email = excelData?.Email;
                string? password = excelData?.Password;

                Console.WriteLine($"Email: {email}, Password: {password}");
                signin.SignInClick(email, password);


            }
            //Thread.Sleep(3000);
            
            string? sheetName1 = "SearchFrock";

            List<ExcelDataSearchFrock> excelDataList1 = ExcelUtils.ReadExcelDataSearchFrock(excelFilePath, sheetName1);

            foreach (var excelData in excelDataList1)
            {
                string? searchText = excelData?.SearchText;

                Console.WriteLine($"Search Text: {searchText}");
                var searchResultPage = popeesHome?.TypeSearchInput(searchText);
                TakeScreenShot();
                //Thread.Sleep(3000);
                searchResultPage.ClickSortBy();
                Log.Information("Sorted : New Arrivals");
               // Thread.Sleep(3000);
                searchResultPage.ClickCheckbox();
                Log.Information("Checkbox : Frocks & Shrugs Checked");
               //Thread.Sleep(3000);
                searchResultPage.ClickCheckboxNew();
                Log.Information("Checkbox : New Checked");
                //Thread.Sleep(3000);
                searchResultPage.ClickRating();
                Log.Information("Rating : 5* Clicked");
                //Thread.Sleep(3000);
                TakeScreenShot();
                searchResultPage.ClickSelectFrock();
                Log.Information("Clicked : Details for frock Loaded");
                //Thread.Sleep(3000);

            }
            SearchResultsPage searchResults = new SearchResultsPage(driver);

            string? addCartExcelFilePath = currDir + "/TestData/InputData.xlsx";
            string? addCartSheetName = "AddCartAndBuy";

            List<ExcelDataAddCart> addCartExcelDataList = ExcelUtils.ReadExcelDataAddCart(addCartExcelFilePath, addCartSheetName);

            foreach (var excelData in addCartExcelDataList)
            {
                //string? zip = excelData?.Zip;
                string? count = excelData?.Count;

               // Console.WriteLine($"Zip Code : {zip}");
                //var searchResultPage = searchResults?.ClickZip(zip);
                //Thread.Sleep(3000);
               // Log.Information("The zip input box is typed");

                searchResults?.ClickSizeCheckBox();
                Thread.Sleep(3000);
                Log.Information("The size button is clicked");

                var search = searchResults?.ClickQuantity(count);
                //Thread.Sleep(3000);
                Log.Information("The quantity is clicked");
                TakeScreenShot();
                search?.ClickAddToCart();
                //Thread.Sleep(3000);
                Log.Information("The Add to cart button is clicked");
                Log.Information("Modal is present");
                search?.ClickCheckoutDetails();
               // Thread.Sleep(3000);
                Log.Information("Proceed to checkout button is clicked");
                TakeScreenShot();
                search?.ClickPlaceOrderBtn();
                //Thread.Sleep(3000);
                Log.Information("Place order button is clicked");
            }

                CheckOutPage checkOut = new CheckOutPage(driver);
                string? addCartSheetName1 = "CheckoutDetails";

                List<ExcelDataCheckout> ExcelDataList = ExcelUtils.ReadExcelDataCheckout(addCartExcelFilePath, addCartSheetName1);

                foreach (var excelData in ExcelDataList)
                {
                    string? address1 = excelData?.Address1;
                    string? address2 = excelData?.Address2;
                    string? city = excelData?.City;
                    string? zip = excelData?.Zip;
                    string? phonenumber = excelData?.PhoneNumber;

                //Thread.Sleep(3000);
                Console.WriteLine($"Address1: {address1} Address2: {address2} City: {city} Zip : {zip} Phone Number : {phonenumber}");
                checkOut?.ClickStateDropDown();
               // Thread.Sleep(3000);
                checkOut?.ClickLoginButton(address1,address2,city,zip,phonenumber);
                Log.Information("The details for buying the product is typed");
                //Thread.Sleep(4000);
                Log.Information("Product searched successfully");
                TakeScreenShot();
                try
                { 
                                  Assert.IsTrue(driver?.Title.Contains("Checkout"));
                                   TakeScreenShot();
                                   Log.Information("Test passed for Product Adding To Cart");

                                   test = extent.CreateTest("Product Adding To Cart Test");
                                   test.Pass("Product Adding To Cart success");

                }
                               catch (AssertionException ex)
                {
                                   Log.Error($"Test failed for Product Adding To Cart. \n Exception: {ex.Message}");

                                   test = extent.CreateTest("Product Adding To Cart Test");
                                   test.Fail("Product Adding To Cart failed");
                }
                   

                }
            Log.CloseAndFlush();

        }
    }
}

