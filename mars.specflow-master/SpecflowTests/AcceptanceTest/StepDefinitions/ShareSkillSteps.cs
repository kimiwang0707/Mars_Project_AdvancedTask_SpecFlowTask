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
    public sealed class ShareSkillSteps
    {
        ShareSkillPage shareSkillPage = new ShareSkillPage();

        [Given(@"I click on Share Skill Button")]
        public void GivenIClickOnShareSkillButton()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Enter share skill");

            shareSkillPage.NavigateToShareSkill(Driver.driver);
        }


        [When(@"I input skill details")]
        public void WhenIInputSkillDetails()
        {
            shareSkillPage.EnterShareSkill(Driver.driver);
        }


        [Then(@"I can see the skill is added into list")]
        public void ThenICanSeeTheSkillIsAddedIntoList()
        {
            shareSkillPage.VerifyEnterShareSkill(Driver.driver);
        }




    }
}
