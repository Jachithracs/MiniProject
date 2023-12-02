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
    [TestFixture]
    internal class RemoveProductTests : CoreCode
    {
        [Test]
        [Order(5), Category("End-to-End Test")]
        public void RemovingProductTests()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
            Log.Information("Removing the product test started");
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
                var popees2=signin.SignInClick(email, password);
                popees2?.ClickSelectFrock();
                Thread.Sleep(2000);
                Log.Information("The product for boys button clicked");
                
            }
            RemoveProductPage removeProduct = new RemoveProductPage(driver);
            removeProduct?.ClickSelectAddToCart();
            Thread.Sleep(3000);
            Log.Information("Product is addded to cart");
            removeProduct?.ClickSelectColour();
            Thread.Sleep(3000);
            Log.Information("Colour for the product is selected");
            removeProduct?.ClickSelectAddCart();
            Thread.Sleep(3000);
            Log.Information("The product is Added to cart clicked");
            TakeScreenShot();
            var remove=removeProduct?.ClickCheckoutDetails();
            TakeScreenShot();
            Thread.Sleep(3000);

            remove?.ClickRemoveProduct();
            Thread.Sleep(3000);
            Log.Information("The product added in the cart is removed");
            TakeScreenShot();
            try
            {
                
                Assert.IsTrue(driver?.Title.Contains("Shopping Cart"));
                
                Log.Information("Test passed for Product Removing from Cart");

                test = extent.CreateTest("Product Removing from Cart Test");
                test.Pass("Product Removing from Cart success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Product Removing from Cart. \n Exception: {ex.Message}");

                test = extent.CreateTest("Product Removing from Cart Test");
                test.Fail("Product Removing from Cart failed");
            }
            Log.CloseAndFlush();
        }
    }
}
