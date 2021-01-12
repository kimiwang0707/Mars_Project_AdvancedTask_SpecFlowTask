using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecflowPages;
using SpecflowPages.Pages;

namespace SpecflowTests.AcceptanceTest.StepDefinitions
{
    [Binding]
    public sealed class SignUpSteps
    {
        SignUp signUpPage = new SignUp();


        [When(@"I sign up a new account")]
        public void WhenISignUpANewAccount()
        {
            signUpPage.SignUpSteps();
        }


        [Then(@"I am able to verify the account has been registered")]
        public void ThenIAmAbleToVerifyTheAccountHasBeenRegistered()
        {
            signUpPage.VerifySignUpSteps();
        }


    }
}
