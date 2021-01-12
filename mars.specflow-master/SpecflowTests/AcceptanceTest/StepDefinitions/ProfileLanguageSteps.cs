using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using SpecflowPages.Pages;

namespace SpecflowTests.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class ProfileLanguageSteps 
    {
        ProfileLangPage languagePage = new ProfileLangPage();

        [Given(@"I clicked on the profile tab under Profile page")]
        public void GivenIClickedOnTheProfileTabUnderProfilePage()
        {
            //Wait
            CommonMethods.WaitForElementClickable(Driver.driver, "XPath", "//*[@id='account-profile-section']/" +
                "div/section[1]/div/a[2]", 5);
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();          
        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

            //Call AddLang Mehthod to add new Language
            languagePage.AddLanguage(Driver.driver);

        }
        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            //Call ValidateAddLang Mehthod to validate added language
            languagePage.VerifyAddLanguage(Driver.driver);
        }


        [When(@"I dont provide a Mandatory language details")]
        public void WhenIDontProvideAMandatoryLanguageDetails()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add language without mandatory details");

            languagePage.AddLanguageWithoutMandatoryDetails(Driver.driver);
        }


        [Then(@"I should see the ErrorMessage displayed on screen")]
        public void ThenIShouldSeeTheErrorMessageDisplayedOnScreen()
        {
            languagePage.RemindErrorMessage(Driver.driver);
        }


        [When(@"I add existing language from list")]
        public void WhenIAddExistingLanguageFromList()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Add an existing language");

            languagePage.AddExistingLanguage(Driver.driver);
        }


        [When(@"I add existing language but with different Language Level")]
        public void WhenIAddExistingLanguageButWithDifferentLanguageLevel()
        {
            languagePage.AddExistingLanguageWithDifferentLanguageLevel(Driver.driver);
        }


        [When(@"I  update Language")]
        public void WhenIUpdateLanguage()
        {  
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update a Language");

            languagePage.UpdateLanguage(Driver.driver);
        }

        [Then(@"that updated language should be displayed on my listings")]
        public void ThenThatUpdatedLanguageShouldBeDisplayedOnMyListings()
        {
            languagePage.VerifyUpdateLanguage(Driver.driver);
        }


        [When(@"I do not provide Mandatory Language details")]
        public void WhenIDoNotProvideMandatoryLanguageDetails()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update language without mandatory details");

            languagePage.UpdateLanguageWithoutMandatoryDetails(Driver.driver);
        }


        [When(@"I  update existing Language from list")]
        public void WhenIUpdateExistingLanguageFromList()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update an existing language");

            languagePage.UpdateExistingLanguage(Driver.driver);
        }


        [When(@"I  update exitsing Language with different language level")]
        public void WhenIUpdateExitsingLanguageWithDifferentLanguageLevel()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Update an existing language with different language level");

            languagePage.UpdateExistingLanguageWithDifferentLangLevel(Driver.driver);
        }

        [When(@"I delete language")]
        public void WhenIDeleteLanguage()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Delete a language");

            languagePage.DeleteLanguage(Driver.driver);
        }

        [Then(@"that language should not be displayed on my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedOnMyListings()
        {
            languagePage.VerifyDeleteLanguage(Driver.driver);
        }


    }
}
