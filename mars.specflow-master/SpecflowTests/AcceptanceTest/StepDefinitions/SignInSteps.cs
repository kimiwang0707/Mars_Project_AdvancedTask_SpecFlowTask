using SpecflowPages.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest.StepDefinitions
{
    [Binding]
    public sealed class SignInSteps
    {
        LoginPage loginPage = new LoginPage();

        [When(@"I sign in with my registered credentials")]
        public void WhenISignInWithMyRegisteredCredentials()
        {
            loginPage.LoginSteps();
        }


        [Then(@"I am able to verify the account is logged in")]
        public void ThenIAmAbleToVerifyTheAccountIsLoggedIn()
        {
            loginPage.VerifyLoginSteps();
        }






    }
}
