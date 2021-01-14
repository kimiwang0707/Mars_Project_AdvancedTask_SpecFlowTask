using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Pages
{
    public class Chat
    {
        public Chat()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Click on Search icon
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement SearchIcon { get; set; }

        // Search User input field
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search user']")]
        private IWebElement SearchUserInput { get; set; }

        // Dropdown 1st Option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div/div[2]/div[1]/div/img")]
        private IWebElement DropdownFirstOpt { get; set; }

        // Result 1st Option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[2]/div/div[2]/div/div/div[1]/a")]
        private IWebElement ResultFirstOpt { get; set; }

        // Chat button on profile page
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/Message/?user=5fc9c489b2bb710001b08fb7']")]
        private IWebElement ChatBtnOnProfile { get; set; }

        // Chat dialog input area
        [FindsBy(How = How.Id, Using = "chatTextBox")]
        private IWebElement ChatInputArea { get; set; }

        // Send button
        [FindsBy(How = How.Id, Using = "btnSend")]
        private IWebElement SendBtn { get; set; }

        // Chat Icon on Main Page
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/Message']")]
        private IWebElement ChatIcon { get; set; }


        public void ChatWithOtherUser(IWebDriver driver)
        {
            // Populate the excel data into system
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "SignIn");

            // Wait and click on Search icon
            WaitForElementClickable(driver, "XPath",
                "//i[@class='search link icon']", 10);
            SearchIcon.Click();

            // Wait and Enter name in Search user part
            WaitForElement(driver, "XPath",
                "//input[@placeholder='Search user']", 10);
            SearchUserInput.SendKeys(ExcelLib.ReadData(3, "Name"));

            // Wait and Choosse the first one option
            Thread.Sleep(1500);
            DropdownFirstOpt.Click();

            // Wait and Choose the first one result
            WaitForElement(driver, "XPath",
                "//*[@id='service-search-section']//div[2]/div/div/div[1]/a/img", 10);
            ResultFirstOpt.Click();

            // Wait and click on Chat button
            WaitForElementClickable(driver, "XPath",
                "//a[@href='/Home/Message/?user=5fc9c489b2bb710001b08fb7']", 10);
            ChatBtnOnProfile.Click();

            // Wait and input message in input area
            WaitForElement(driver, "Id", "chatTextBox", 10);
            ChatInputArea.SendKeys("Hi! Test!");
            Thread.Sleep(500);

            // Click on send button
            SendBtn.Click();         
        }

        public void VerifyChatWithOtherUser(IWebDriver driver)
        {
            Thread.Sleep(1000);
            bool present;
            try
            {
                driver.FindElement(By.XPath("//span[contains(text(),'Hi! Test!')]"));
                present = true;
                if (present)
                {
                    // Extent report
                    test.Log(LogStatus.Pass, "Chat with other users successfully!");
                }

            }
            catch (NoSuchElementException)
            {
                present = false;
                test.Log(LogStatus.Fail, "Test failed to verify Chat with other users!");
                Assert.Fail("Test failed to verify Chat with other users!");
            }
        }



        public void ViewChatHistory(IWebDriver driver)
        {
            // Wait and click on Chat icon.
            WaitForElementClickable(driver, "XPath", "//a[@href='/Home/Message']", 10);
            ChatIcon.Click();
        }

        public void VerifyViewChatHistory(IWebDriver driver)
        {
            // Populate the excel data into system
            ExcelLib.PopulateInCollection(ConstantUtils.TestDataPath, "SignIn");

            // Wait
            WaitForElement(driver, "XPath", "//div[@class='lastest-chat-row']", 10);

            // Record the first name of the chat obj
            string firstNameChatObj = ExcelLib.ReadData(3, "First Name");

            // Judge if the chat obj is in chat history list
            try
            {
                driver.FindElement(By.XPath("//div[@class='header' and contains(text(),'" + firstNameChatObj + "')]"));
                test.Log(LogStatus.Pass, "View chat history sucessfully!");

            }
            catch (NoSuchElementException)
            {
                test.Log(LogStatus.Fail, "Test failed to verify Chat History!");
                Assert.Fail("Test failed to verify Chat History!");
            }
        }

    }
}
