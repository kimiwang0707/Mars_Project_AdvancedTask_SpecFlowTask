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
    public sealed class NotificationShowLessLoadMoreSteps
    {
        NotificationPage notificationPage = new NotificationPage();

        [Given(@"I navigate to Notification page")]
        public void GivenINavigateToNotificationPage()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Notification: Load More and Show Less");

            notificationPage.NavigateToNotificationPage(Driver.driver);
        }

        [When(@"I click Load More button and Show Less button")]
        public void WhenIClickLoadMoreButtonAndShowLessButton()
        {
            notificationPage.ShowLessAndMoreNotification(Driver.driver);
        }

        [Then(@"the results will be shown as request")]
        public void ThenTheResultsWillBeShownAsRequest()
        {
            notificationPage.VerifyShowLessAndMoreNotification(Driver.driver);
        }



    }
}
