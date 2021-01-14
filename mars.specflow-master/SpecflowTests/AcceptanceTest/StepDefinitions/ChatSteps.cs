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
    public sealed class ChatSteps
    {
        Chat chatPage = new Chat();

        [When(@"I click to chat with others")]
        public void WhenIClickToChatWithOthers()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("Chat with other user");

            chatPage.ChatWithOtherUser(Driver.driver);
        }

        [Then(@"I can can see the chat record")]
        public void ThenICanCanSeeTheChatRecord()
        {
            chatPage.VerifyChatWithOtherUser(Driver.driver);
        }

        [When(@"I click to view chat history")]
        public void WhenIClickToViewChatHistory()
        {
            //Start extent report
            CommonMethods.test = CommonMethods.extent.StartTest("View chat history");

            chatPage.ViewChatHistory(Driver.driver);
        }

        [Then(@"I can can view the chat history")]
        public void ThenICanCanViewTheChatHistory()
        {
            chatPage.VerifyViewChatHistory(Driver.driver);
        }


    }
}
