using OpenQA.Selenium;
using SpecflowPages;
using SpecflowPages.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest.StepDefinitions
{
    [Binding]
    public sealed class ProfileSkillsSteps
    {
        ProfileSkillsPage skillPage = new ProfileSkillsPage();


        [Given(@"I clicked on the Profile tab under Profile page")]
        public void GivenIClickedOnTheProfileTabUnderProfilePage()
        {
            //Wait
            CommonMethods.WaitForElementClickable(Driver.driver, "XPath", "//*[@id='account-profile-section']/" +
                "div/section[1]/div/a[2]", 5);
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }


        [When(@"I add new skill with '(.*)' and '(.*)'")]
        public void WhenIAddNewSkillWithAnd(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add a skill");

            skillPage.AddSkill(Driver.driver, skillName, skillLevel);
        }


        [Then(@"I should see the skill '(.*)'and '(.*)' displayed on my listings")]
        public void ThenIShouldSeeTheSkillAndDisplayedOnMyListings(string skillName, string skillLevel)
        {
            skillPage.VerifyAddSkill(Driver.driver, skillName, skillLevel);
        }


        [When(@"I add new skill with blank '(.*)' and '(.*)'")]
        public void WhenIAddNewSkillWithBlankAnd(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add a skill without mandatory details");
            ProfileSkillsPage.msg = "add a skill without mandatory details";

            skillPage.AddSkillWithoutMandatoryDetails(Driver.driver, skillName, skillLevel);
        }

        [Then(@"I should see Error Message")]
        public void ThenIShouldSeeErrorMessage()
        {
            skillPage.RemindErrorMessage(Driver.driver);
        }

        [When(@"I add existing skill from list with '(.*)' and '(.*)'")]
        public void WhenIAddExistingSkillFromListWithAnd(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add an existing skill");
            ProfileSkillsPage.msg = "add existing skill";

            skillPage.AddSkill(Driver.driver, skillName, skillLevel);
        }


        [When(@"I add existing skill from list with '(.*)' and different '(.*)'")]
        public void WhenIAddExistingSkillFromListWithAndDifferent(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add an existing skill with different skill level");
            ProfileSkillsPage.msg = "add existing skill with different skill level";

            skillPage.AddSkill(Driver.driver, skillName, skillLevel);
        }


        [When(@"I update skill with '(.*)' and '(.*)'")]
        public void WhenIUpdateSkillWithAnd(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update a skill");

            skillPage.UpdateSkill(Driver.driver, skillName, skillLevel);
        }

        [Then(@"I should see updated '(.*)' and '(.*)'")]
        public void ThenIShouldSeeUpdatedAnd(string skillName, string skillLevel)
        {
            skillPage.VerifyUpdateSkill(Driver.driver, skillName, skillLevel);
        }


        [When(@"I update skill with blank '(.*)' and '(.*)'")]
        public void WhenIUpdateSkillWithBlankAnd(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update a skill without mandatory details");
            ProfileSkillsPage.msg = "update skill without mandatory details";

            skillPage.UpdateSkill(Driver.driver, skillName, skillLevel);
        }

        [When(@"I update skill with existing '(.*)' and '(.*)'")]
        public void WhenIUpdateSkillWithExistingAnd(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update an existing skilll");
            ProfileSkillsPage.msg = "update an existing skill";

            skillPage.UpdateSkill(Driver.driver, skillName, skillLevel);
        }

        [When(@"I update skill with existing '(.*)' and differenr '(.*)'")]
        public void WhenIUpdateSkillWithExistingAndDifferenr(string skillName, string skillLevel)
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update an existing skilll with different skill level");
            ProfileSkillsPage.msg = "update an existing skill with a different skill level";

            skillPage.UpdateSkill(Driver.driver, skillName, skillLevel);
        }


        [When(@"I delete a skill")]
        public void WhenIDeleteASkill()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Delete a skill");

            skillPage.DeleteSkill(Driver.driver);
        }


        [Then(@"I will not see the language")]
        public void ThenIWillNotSeeTheLanguage()
        {
            skillPage.VerifyDeleteSkill(Driver.driver);
        }







    }
}
