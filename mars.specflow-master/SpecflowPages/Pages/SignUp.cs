using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Pages
{
    public class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/button")]
        private IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.Name, Using = "terms")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        public void SignUpSteps()
        {
            CommonMethods.test = CommonMethods.extent.StartTest("Sign up steps test");

            //Populate the excel data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "SignUp");

            //Click on Join button
            Join.Click();

            // Wait
            CommonMethods.WaitForElement(Driver.driver, "Name", "firstName", 10);

            //Enter FirstName
            FirstName.SendKeys(ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();
        }

        public void VerifySignUpSteps()
        {
            try
            {
                Driver.driver.FindElement(By.XPath("//*[contains(text(),'This email has already been used to register an account.')]"));
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "This account has been registered already, please login directly!");
                Assert.Fail("This account has been registered already, you can login directly!");
            }
            catch (NoSuchElementException)
            {
                try
                {
                    Driver.driver.FindElement(By.XPath("//*[contains(text(),'Register Successfully')]"));
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Register Successfully");

                }
                catch (NoSuchElementException)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Fail to register!");
                    Assert.Fail("Fail to register!");
                }
            }

        }



    }
}
