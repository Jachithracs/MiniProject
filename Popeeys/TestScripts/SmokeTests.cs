using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    internal class SmokeTests :CoreCode
    {
        [Test]
        [Order(1), Category("Smoke Test")]
        public void LogoCheckTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            PopeesHomePage logoCheck = new PopeesHomePage(driver);
            Log.Information("New Borns Clicked");
            var logo=logoCheck?.ClickNewbornselect();
            TakeScreenShot();
           // Thread.Sleep(3000);
            logo?.ClickLogoSelect();
            Log.Information("Logo Checked Successfully");
            TakeScreenShot();
            try
            {

                Assert.IsTrue(driver?.Url.Contains("popees"));

                Log.Information("Test passed for Logo Checking and Refreshing");

                test = extent.CreateTest("Logo Checking and Refreshing Test");
                test.Pass("Logo Checking and Refreshing success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Logo Checking and Refreshing. \n Exception: {ex.Message}");

                test = extent.CreateTest("Logo Checking and Refreshing Test");
                test.Fail("Logo Checking and Refreshing failed");
            }
            Log.CloseAndFlush();

        }
        [Test]
        [Order(2), Category("Smoke Test")]
        public void ClickMyAccount()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            PopeesHomePage myaccount = new PopeesHomePage(driver);
            myaccount?.ClickCreateAccountLink();
            Log.Information("Create Account link clicked");
            TakeScreenShot();

            try
            {

                Assert.IsTrue(driver?.Title.Contains("Customer Login"));

                Log.Information("Test passed for Customer Login");

                test = extent.CreateTest("Customer Login Test");
                test.Pass("Customer Login success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Customer Login. \n Exception: {ex.Message}");

                test = extent.CreateTest("Customer Login Test");
                test.Fail("Customer Login failed");
            }
            Log.CloseAndFlush();
        }
        [Test]
        [Order(3), Category("Smoke Test")]
        public void ClickCartBag()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
           
            PopeesHomePage myaccount = new PopeesHomePage(driver);
            myaccount?.ClickSelectCartBtn();
            Log.Information("Cart Bag option clicked");
            Log.Information("Your Cart Modal is shown");
            TakeScreenShot();
            
            try
            {

                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMicroseconds(100);
                wait.Timeout = TimeSpan.FromSeconds(10);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Until(d=>d.FindElement(By.XPath("//span[text()='You have no items in your shopping cart.']")));
                Assert.That(driver.FindElement(By.XPath("//span[text()='You have no items in your shopping cart.']")).Text == "You have no items in your shopping cart.");

                Log.Information("Test passed for View Cart Bag");

                test = extent.CreateTest("View Cart Bag Test");
                test.Pass("View Cart Bag success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for View Cart Bag. \n Exception: {ex.Message}");

                test = extent.CreateTest("View Cart Bag Test");
                test.Fail("View Cart Bag failed");
            }
            Log.CloseAndFlush();
        }
    }
}
