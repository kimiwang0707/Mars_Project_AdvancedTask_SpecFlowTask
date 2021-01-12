using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Diagnostics;
using System.Threading;
using static SpecflowPages.CommonMethods;


namespace SpecflowPages.Pages
{

    public class ProfileLangPage
    {
        public ProfileLangPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        string msg;
        int eleQty;

        #region Language tab
        // Profile Name used to be the benchmark to verify all contents turn up
        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement profileName { get; set; }

        //Click Language Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='first']")]
        private IWebElement LanguageTab { get; set; }

        //Click on Add new to add new Language
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//div[contains(text(),'Add New')]")]
        private IWebElement LanguageAddNewBtn { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Language']")]
        private IWebElement LanguageName { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//select[@name='level']")]
        private IWebElement LanguageDropdownBox { get; set; }

        //Add Language
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//input[@value='Add']")]
        private IWebElement LanguageAddBtn { get; set; }

        //Edit Icon (Last record)
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']//div[2]//div[2]//tbody[last()]/tr/td[3]/span[1]/i")]
        private IWebElement EditIcon { get; set; }

        //Update Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateBtn { get; set; }

        //Delete Language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[2]//div[2]//tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement LanguageDeleteBtn { get; set; }
        #endregion



        #region Add Language
        public void AddLanguage(IWebDriver driver)
        {                      
                //Populate Test Data
                ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

                // Click Language tab
                WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
                LanguageTab.Click();

                // Click Add New
                WaitForElement(driver, "XPath", "//div[@data-tab='first']//div[contains(text(),'Add New')]", 5);
                LanguageAddNewBtn.Click();

                // Enter Language
                WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
                LanguageName.SendKeys(ExcelLib.ReadData(2, "Language"));

                // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
                LanguageDropdownBox.Click();
                new SelectElement(LanguageDropdownBox).SelectByText
                    (ExcelLib.ReadData(2, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

                // Click Add
                LanguageAddBtn.Click();                  
        }


        public void VerifyAddLanguage(IWebDriver driver)
        {
            try
            {
                // Wait
                WaitForElement(driver, "XPath", "//div[contains(text(),'has been added to')]", 3);
            }
            catch (Exception)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to add a language!");
                Assert.Fail("Fail to add lanaguage");
            }

            //Verify Language Name
            var lastRowLanguageName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.That(lastRowLanguageName, Is.EqualTo(ExcelLib.ReadData(2, "Language")));

            //Verify Language Level
            var lastRowLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.That(lastRowLanguageLevel, Is.EqualTo(ExcelLib.ReadData(2, "Language Level")));

            CommonMethods.test.Log(LogStatus.Pass, "Add language successfully!");
      
        }
        #endregion

        #region Add Language Without Mandatory Details
        public void AddLanguageWithoutMandatoryDetails(IWebDriver driver)
        {           
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Add New
            WaitForElement(driver, "XPath", "//div[@data-tab='first']//div[contains(text(),'Add New')]", 5);
            LanguageAddNewBtn.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.SendKeys("");

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(2, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

            // Click Add
            LanguageAddBtn.Click();

            // Record the msg
            msg = "add language without mandatory details";

        }


        public void RemindErrorMessage(IWebDriver driver)
        {
            try
            {
                WaitForElement(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 3);
                CommonMethods.test.Log(LogStatus.Pass, "Verify " + msg + " successfully!!");

            } catch(Exception)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to " + msg + " !");
            }
        }
        #endregion

        #region Add Existing Language
        public void AddExistingLanguage(IWebDriver driver)
        {      
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Add New
            WaitForElement(driver, "XPath", "//div[@data-tab='first']//div[contains(text(),'Add New')]", 5);
            LanguageAddNewBtn.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.SendKeys(ExcelLib.ReadData(2, "Language"));

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(2, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

            // Click Add
            LanguageAddBtn.Click();

            // Record the msg
            msg = "add an existing language";
        }


        public void AddExistingLanguageWithDifferentLanguageLevel(IWebDriver driver)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add an existing language");

            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Add New
            WaitForElement(driver, "XPath", "//div[@data-tab='first']//div[contains(text(),'Add New')]", 5);
            LanguageAddNewBtn.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.SendKeys(ExcelLib.ReadData(3, "Language"));

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(3, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

            // Click Add
            LanguageAddBtn.Click();

            // Record the msg
            msg = "add an existing language with different language level";
        }
        #endregion

        #region Update Language

        public void UpdateLanguage(IWebDriver driver)
        {         
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Edit
            WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']//div[2]//div[2]//tbody[last()]/tr/td[3]/span[1]/i", 5);
            EditIcon.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.Clear();
            LanguageName.SendKeys(ExcelLib.ReadData(4, "Language"));

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(4, "Language Level"));

            // Click Update
            UpdateBtn.Click();
        }

        public void VerifyUpdateLanguage(IWebDriver driver)
        {
            try
            {
                // Wait
                WaitForElement(driver, "XPath", "//div[contains(text(),'has been updated to')]", 3);
            }
            catch (Exception)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to update language!");
                Assert.Fail("Fail to add lanaguage");
            }

            //Verify Language Name
            var lastRowLanguageName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.That(lastRowLanguageName, Is.EqualTo(ExcelLib.ReadData(4, "Language")));

            //Verify Language Level
            var lastRowLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.That(lastRowLanguageLevel, Is.EqualTo(ExcelLib.ReadData(4, "Language Level")));

            CommonMethods.test.Log(LogStatus.Pass, "Update language successfully!");

        }

        #endregion

        #region Update Language Without Mandatory Details
        public void UpdateLanguageWithoutMandatoryDetails(IWebDriver driver)
        {
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Edit
            WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']//div[2]//div[2]//tbody[last()]/tr/td[3]/span[1]/i", 5);
            EditIcon.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.Clear();
            LanguageName.SendKeys("");

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(4, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

            // Click Update
            UpdateBtn.Click();

            // Record the msg
            msg = "update language without mandatory details";

        }

        #endregion 
                
        #region Update Existing Language
        public void UpdateExistingLanguage(IWebDriver driver)
        {
            // Add a new language

            AddLanguage(driver);
            Thread.Sleep(1000);

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Edit
            WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']//div[2]//div[2]//tbody[last()]/tr/td[3]/span[1]/i", 5);
            EditIcon.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.Clear();
            LanguageName.SendKeys(ExcelLib.ReadData(4, "Language"));

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(4, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

            // Click Update
            UpdateBtn.Click();

            // Record the msg
            msg = "update an existing language";
        }
        #endregion

        #region Update Existing Language With Different Language Level
        public void UpdateExistingLanguageWithDifferentLangLevel(IWebDriver driver)
        {          
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Click Language tab
            WaitForElement(driver, "XPath", "//a[@data-tab='first']", 5);
            LanguageTab.Click();

            // Click Edit
            WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']//div[2]//div[2]//tbody[last()]/tr/td[3]/span[1]/i", 5);
            EditIcon.Click();

            // Enter Language
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            LanguageName.Clear();
            LanguageName.SendKeys(ExcelLib.ReadData(5, "Language"));

            // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText
                (ExcelLib.ReadData(5, "Language Level"));

            // Click Update
            UpdateBtn.Click();

            // Record the msg
            msg = "update an existing language with different language level";
        }

        #endregion

        #region Delete Language
        public void DeleteLanguage(IWebDriver driver)
        {
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Wait for all text present in Element
            WaitForTextPresentInElement(driver, profileName, ExcelLib.ReadData(2, "Name"), 10);

            var ele = driver.FindElements(By.XPath("//*[@id='account-profile-section']//form/div[2]//div[2]/div/table/tbody"));
            eleQty = ele.Count;

            try
            {
                //Delete the last record
                LanguageTab.Click();
                LanguageDeleteBtn.Click();
            }
            catch (NoSuchElementException e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "No records in list to delete!");
                Assert.Fail("No records in list to delete, please add language first!", e.Message);
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to delete a language!");
                Assert.Fail("Test failed to delete language", ex.Message);
            }
            
        }


        public void VerifyDeleteLanguage(IWebDriver driver)
        {
            // Delete one more to keep the test circle stale
            Thread.Sleep(500);
            DeleteLanguage(driver);

            // Refresh the page
            driver.Navigate().Refresh();

            // Wait for all text present in Element
            WaitForTextPresentInElement(driver, profileName, ExcelLib.ReadData(2, "Name"), 10);

            // Jump to Language tab
            LanguageTab.Click();

           // Record the qty after deletion
           var ele = driver.FindElements(By.XPath("//*[@id='account-profile-section']//form/div[2]//div[2]/div/table/tbody"));
           int eleQtyAfterDelete = ele.Count;
          
           Debug.WriteLine("****The Ele Qty: " + eleQty + " ****The Ele Qty After Deletion: " + eleQtyAfterDelete);

            if (eleQtyAfterDelete == eleQty-1)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Delete a language sucessfully!");       
            }
            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to delete a language!");       
                Assert.Fail("Failed to delete language");
            } 
                    
        }
        #endregion



    }


}
