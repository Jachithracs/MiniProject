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
    [TestFixture,Order(3)]
    internal class AddWishListTests : CoreCode
    {
        [Test]
        [Order(5), Category("End-to-End Test")]
        public void AddingProductWishlist()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            PopeesHomePage popees = new PopeesHomePage(driver);
            var signin = popees.ClickCreateAccountLink();

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
            Log.Information("Adding the product to wishlist started");
            popees.ClickDressSelect();
            //Thread.Sleep(4000);
            Log.Information("The product Maternity is clicked");
            AddWishlistPage addWishlist = new AddWishlistPage(driver);
            addWishlist.ClickNightyCheck();
            //Thread.Sleep(4000);
            Log.Information("Checkbox Nighty is clicked");
            addWishlist.ClickSizeCheck();
           // Thread.Sleep(4000);
            Log.Information("Checkbox New is clicked");
            addWishlist.ClickRatingCheck();
            //Thread.Sleep(4000);
            Log.Information("Checkbox Rating is clicked");
            TakeScreenShot();
            addWishlist.ClickSelectedDress();
            //Thread.Sleep(4000);
            Log.Information("The product available is clicked");
            addWishlist.ClickAddWishlist();
            //Thread.Sleep(4000);
            Log.Information("The Add to Wishlist option is clicked");
            addWishlist.ClickViewAccount();
            //Thread.Sleep(4000);
            Log.Information("Click the My Account button to view the wishlist page");
            addWishlist.ClickViewWishlist();
            //Thread.Sleep(4000);
            Log.Information("The product added in the wishlist is visible");
            TakeScreenShot();
            try
            {
                Assert.IsTrue(driver?.Title.Contains("My Wish List"));
                
                Log.Information("Test passed for My WishList");

                test = extent.CreateTest("Add to Wish List Test");
                test.Pass("Add Wishlist success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Add to Wish List. \n Exception: {ex.Message}");

                test = extent.CreateTest("Add to Wish List Test");
                test.Fail("Add to Wishlist failed");
            }
            Log.CloseAndFlush();
        }
    }
}
