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
    public sealed class ManageListingsSteps
    {
        ManageListings manageListingpage = new ManageListings();


        [Given(@"I nativate to managelisting page")]
        public void GivenINativateToManagelistingPage()
        {
            manageListingpage.NavigateToManageListings(Driver.driver);
        }


        [When(@"I edit the listing")]
        public void WhenIEditTheListing()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Edit Listing");

            manageListingpage.EditListing(Driver.driver);
        }


        [Then(@"the listing will be updated")]
        public void ThenTheListingWillBeUpdated()
        {
            manageListingpage.VerifyEditListing(Driver.driver);
        }


        [When(@"I delete a listing")]
        public void WhenIDeleteAListing()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Delete Listing");

            manageListingpage.DeleteListing(Driver.driver);
        }

        [Then(@"the listing will be deleted")]
        public void ThenTheListingWillBeDeleted()
        {
            manageListingpage.VerifyDeleteListing(Driver.driver);
        }




    }
}
