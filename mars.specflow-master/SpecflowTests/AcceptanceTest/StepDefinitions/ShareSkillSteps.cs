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

        [Given(@"I click on Share Skill Button")]
        public void GivenIClickOnShareSkillButton()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I input skill details")]
        public void WhenIInputSkillDetails()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I can see the skill is added into list")]
        public void ThenICanSeeTheSkillIsAddedIntoList()
        {
            ScenarioContext.Current.Pending();
        }




    }
}
