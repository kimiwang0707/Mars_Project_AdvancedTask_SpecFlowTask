using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Pages
{
  public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion


        public void LoginSteps()
        {
            // extent reports
            CommonMethods.test = CommonMethods.extent.StartTest("Login steps test");

            //Populate excel data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "SignIn");

            // Wait Element
            CommonMethods.WaitForElementClickable(Driver.driver, "XPath", "//a[contains(text(),'Sign')]", 10);

            // Click signin tab to signin page
            SignIntab.Click();

            // Input username
            Email.SendKeys(ExcelLib.ReadData(2, "Username"));

            // Input password
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));

            // Click Login button
            LoginBtn.Click();        

        }


        public void VerifyLoginSteps()
        {
            try
            {
                // Verify the login status                      
                CommonMethods.WaitForElementClickable(Driver.driver, "XPath", "//*[@id='account-profile-section']" +
                    "//div[1]/div[2]/div/span", 10);
            } catch (Exception)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Login failed");
                Assert.Fail("Failed to login");
            }

            var greeting = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']//div[1]/div[2]/div/span")).Text;

            if (greeting.Contains("Hi"))
            {
                CommonMethods.test.Log(LogStatus.Pass, "Login Successful");
            }
            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Login failed");
                Assert.Fail("Failed to login");
            }

        }

    }
}
