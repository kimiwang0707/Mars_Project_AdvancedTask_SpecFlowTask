using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Pages
{
    public class NotificationPage
    {
        public NotificationPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize web elements

        // Click on Notification Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement NotificationBtn { get; set; }

        // Click on See All
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'See All')]")]
        private IWebElement SeeAllLink { get; set; }

        // Click on Load More button
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Load More')]")]
        private IWebElement LoadMoreBtn { get; set; }

        // Click on Show Less button
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Show Less')]")]
        private IWebElement ShowLessBtn { get; set; }

        // Click on Checkbox of first one notification to select
        [FindsBy(How = How.XPath, Using = "(//div[@class='fourteen wide column' and @style='font-weight: bold;'])[1]/../div[3]/input")]
        private IWebElement FirstUnreadNotisCheckbox { get; set; }

        // Click on Checkbox of last one notification to select
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']//div[last()-1]/div/div/div[3]/input")]
        private IWebElement LastNotificationCheckbox { get; set; }

        // Click on Delete Button
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Delete selection']")]
        private IWebElement DeleteBtn { get; set; }

        // Click on Mark As Read Button
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Mark selection as read']")]
        private IWebElement MarkAsReadBtn { get; set; }

        // Click on Select All
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Select all']")]
        private IWebElement SelectAllBtn { get; set; }

        // Click on Unselect All
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Unselect all']")]
        private IWebElement UnselectAllBtn { get; set; }

        #endregion

        int requestsQtyLoadMore;
        int requestsQtyShowLess;


        public void NavigateToNotificationPage(IWebDriver driver)
        {
            // Wait and Click on Notification
            WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div", 10);
            NotificationBtn.Click();

            // Wait and Click on See All button
            WaitForElementClickable(driver, "XPath", "//a[contains(text(), 'See All')]", 10);
            SeeAllLink.Click();
        }


        public void ShowLessAndMoreNotification(IWebDriver driver)
        { 
            // Judge if the load more button appear, or remind user to add more notifications
            try
            {
                // Wait and scroll down to bottom of page   
                WaitForElementClickable(driver, "XPath", "//a[@class='ui button']", 10);
                ScrollToBottom();

                // Click on Load More and record the qty of notification
                Thread.Sleep(500);
                LoadMoreBtn.Click();
            }
            catch (NoSuchElementException e)
            {
                test.Log(LogStatus.Fail, "Make sure the notifications are more than 5 to use load more function");
                Assert.Fail("Please make sure more than 5 notifications to use load more function!", e.Message);
            }

            //WaitForElementClickable(driver, "XPath", "//*[@id='notification-section']//" +
            //    "div[last()-1]/div/div/div[3]/input", 10);
            Thread.Sleep(1500);
            var requestsLoadMore = driver.FindElements(By.XPath("//h4[contains(text(), 'Service Request')]"));
            requestsQtyLoadMore = requestsLoadMore.Count();

            // Wait and Click on Show Less and record the qty of notifications
            ShowLessBtn.Click();

            WaitForElementClickable(driver, "XPath", "//*[@id='notification-section']//" +
                "div[last()-1]/div/div/div[3]/input", 10);
            var requestsShowLess = driver.FindElements(By.XPath("//h4[contains(text(), 'Service Request')]"));
            requestsQtyShowLess = requestsShowLess.Count();

            // Record data
            Debug.WriteLine("Load MORE qty:" + requestsQtyLoadMore + "SHOW LESS QTY:" + requestsQtyShowLess);

        }

        public void VerifyShowLessAndMoreNotification(IWebDriver driver)
        {
            // Compare the qty of notifications exhibit
            if (requestsQtyShowLess <= requestsQtyLoadMore)
            {
                test.Log(LogStatus.Pass, "Verify show less and load more notifications successfully!");
            }
            else
            {
                test.Log(LogStatus.Fail, "Test failed to verify show less and load more notifications.");
                Assert.Fail("Test failed to verify show less and load more notifications.");
            }

        }







    }
}
