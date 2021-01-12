using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Pages
{
    public class ProfileSkillsPage
    {
        public ProfileSkillsPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }


        public static string msg;
        int eleQty;

        // Profile Name used to be the benchmark to verify all contents turn up
        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement profileName { get; set; }

        // Click Skills Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='second']")]
        private IWebElement SkillTab { get; set; }

        //Click on Add new to add new skill
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//div[contains(text(),'Add New')]")]
        private IWebElement SkillAddNewBtn { get; set; }

        //Enter the Skill on text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        private IWebElement SkillName { get; set; }

        //Click on skill level dropdown
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//select[@name='level']")]
        private IWebElement SkillDropdownBox { get; set; }

        //Add Skill
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//input[@value='Add']")]
        private IWebElement SkillAddBtn { get; set; }

        //Edit Icon (Last record)
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[3]/span[1]/i")]
        private IWebElement EditIcon { get; set; }

        //Update Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateBtn { get; set; }

        //Delete Skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement SkillDeleteBtn { get; set; }



        #region Add Skill
        public void AddSkill(IWebDriver driver, string skillName, string skillLevel)
        {   
                // Click Skills tab
                WaitForElement(driver, "XPath", "//a[@data-tab='second']", 5);
                SkillTab.Click();

                // Click Add New
                WaitForElement(driver, "XPath", "//div[@data-tab='second']//div[contains(text(),'Add New')]", 5);
                SkillAddNewBtn.Click();

                // Enter Skill
                WaitForElement(driver, "XPath", "//input[@placeholder='Add Skill']", 5);
                SkillName.SendKeys(skillName);

                // Choose Skill level 0-beginer; 1-intermediate; 2-expert
                SkillDropdownBox.Click();
                new SelectElement(SkillDropdownBox).SelectByText(skillLevel);

                // Click Add
                SkillAddBtn.Click();

        }


        public void VerifyAddSkill(IWebDriver driver, string skillName, string skillLevel)
        {
            try
            {
                //Jump to Skill tab
                SkillTab.Click();

                //Verify Skill Name
                var lastRowSkillName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowSkillName, Is.EqualTo(skillName));

                //Verify Skill Level
                var lastRowSkillLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowSkillLevel, Is.EqualTo(skillLevel));

                test.Log(LogStatus.Pass, "Add skill sucessfully!");

            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Fail to add skill!");
                Assert.Fail("Test failed to add skill", ex.Message);
            }

        }
        #endregion

        #region Add Skill Without Mandatory Details
        public void AddSkillWithoutMandatoryDetails(IWebDriver driver, string skillName, string skillLevel)
        {
            // Click Skills tab
            WaitForElement(driver, "XPath", "//a[@data-tab='second']", 5);
            SkillTab.Click();

            // Click Add New
            WaitForElement(driver, "XPath", "//div[@data-tab='second']//div[contains(text(),'Add New')]", 5);
            SkillAddNewBtn.Click();

            // Enter Skill
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Skill']", 5);
            SkillName.SendKeys(skillName);

            // Choose Skill level 0-beginer; 1-intermediate; 2-expert
            SkillDropdownBox.Click();
            new SelectElement(SkillDropdownBox).SelectByText(skillLevel);

            // Click Add
            SkillAddBtn.Click();

        }


        public void RemindErrorMessage(IWebDriver driver)
        {
            try
            {
                WaitForElement(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']", 3);
                CommonMethods.test.Log(LogStatus.Pass, "Verify " + msg + " successfully!!");

            }
            catch (Exception)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to " + msg + " !");
            }
        }
        #endregion

        #region Update Skill
        public void UpdateSkill(IWebDriver driver, string skillName, string skillLevel)
        {
            // Click Skill tab
            WaitForElement(driver, "XPath", "//a[@data-tab='second']", 5);
            SkillTab.Click();

            // Click Edit
            WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']//div[3]/form/div[3]//div[2]//tbody[2]/tr/td[3]/span[1]/i", 5);
            EditIcon.Click();

            // Update Skill
            WaitForElement(driver, "XPath", "//input[@placeholder='Add Skill']", 5);
            SkillName.Clear();
            SkillName.SendKeys(skillName);

            // Choose Skill level
            SkillDropdownBox.Click();
            new SelectElement(SkillDropdownBox).SelectByText(skillLevel);

            // Click Update
            UpdateBtn.Click();
        }

        public void VerifyUpdateSkill(IWebDriver driver, string skillName, string skillLevel)
        {
            try
            {
                // Wait
                WaitForElement(driver, "XPath", "//div[contains(text(),'has been updated to')]", 3);
            }
            catch (Exception)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to update skill!");
                Assert.Fail("Fail to update lanaguage");
            }

            //Verify Language Name
            var lastRowSkillName = driver.FindElement(By.XPath("//*[@id='account-profile-section']//div[3]/form/div[3]//" +
                "div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.That(lastRowSkillName, Is.EqualTo(skillName));

            //Verify Language Level
            var lastRowLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']//div[3]/form/div[3]//" +
                "div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.That(lastRowLanguageLevel, Is.EqualTo(skillLevel));

            CommonMethods.test.Log(LogStatus.Pass, "Update skill successfully!");

        }

        #endregion

        #region Delete A Skill
        public void DeleteSkill(IWebDriver driver)
        {
            //Populate Test Data
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "Profile");

            // Wait for all text present in Element
            WaitForTextPresentInElement(driver, profileName, ExcelLib.ReadData(2, "Name"), 10);

            var ele = driver.FindElements(By.XPath("//*[@id='account-profile-section']//form/div[3]//div[2]/div/table/tbody"));
            eleQty = ele.Count;

            try
            {
                //Delete the last record
                SkillTab.Click();
                SkillDeleteBtn.Click();
            }
            catch (NoSuchElementException e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "No records in list to delete!");
                Assert.Fail("No records in list to delete, please add skill first!", e.Message);
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to delete a skill!");
                Assert.Fail("Test failed to delete skill", ex.Message);
            }

        }

        public void VerifyDeleteSkill(IWebDriver driver)
        {
            // Refresh the page
            driver.Navigate().Refresh();

            // Wait for all text present in Element
            WaitForTextPresentInElement(driver, profileName, ExcelLib.ReadData(2, "Name"), 10);

            // Jump to Skill tab
            SkillTab.Click();

            // Record the qty after deletion
            var ele = driver.FindElements(By.XPath("//*[@id='account-profile-section']//form/div[3]//div[2]/div/table/tbody"));
            int eleQtyAfterDelete = ele.Count;

            Debug.WriteLine("****The Ele Qty: " + eleQty + " ****The Ele Qty After Deletion: " + eleQtyAfterDelete);

            if (eleQtyAfterDelete == eleQty - 1)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Delete a skill sucessfully!");
            }
            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Fail to delete a skill!");
                Assert.Fail("Failed to delete skill");
            }

        }

        #endregion

    }
}
