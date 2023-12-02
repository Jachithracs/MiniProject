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
    [TestFixture]
    internal class CustomerLoginTests : CoreCode
    {
        [Test]
        [Order(2), Category("Smoke Test")]
        public void CustomerLogin()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            PopeesHomePage popeesPage = new PopeesHomePage(driver);
            Log.Information("Creating new customer Account Started");
            var signin = popeesPage.ClickCreateAccountLink();
            Log.Information("Creating Customer Account Link Clicked");


            var customerlogin=signin.ClickCreateCustomerAccount();
            Log.Information("Creating new customer Account Clicked");
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateCustomerAccount";

            List<ExcelDataCustomerLogin> excelDataList = ExcelUtils.ReadCustomerLoginExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? mobileNumber = excelData?.MobileNumber;
                string? email = excelData?.Email;
                string? password = excelData?.Password;
                string? confirmPassword = excelData?.ConfirmPassword;
                

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Mobile Number: {mobileNumber}, Email: {email}, Password: {password}, Confirm Password: {confirmPassword}");
                Log.Information("The details for creating account details selected");
                customerlogin.ClickLoginButton(firstName,lastName,mobileNumber,email,password,confirmPassword);
                Log.Information("Creating Customer Account Completed");
                TakeScreenShot();
                try
                {
                    Assert.IsTrue(driver?.Url.Contains("account"));
                    
                    Log.Information("Test passed for Create Account");               
                    test = extent.CreateTest("Create Account Link Test");
                    test.Pass("Create Account Link success");

                }
                catch (AssertionException ex)
                {
                   Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");

                    test = extent.CreateTest("Create Account Link Test");
                    test.Fail("Create Account Link failed");
                }

                Log.CloseAndFlush();

            }
        }

    }
}
