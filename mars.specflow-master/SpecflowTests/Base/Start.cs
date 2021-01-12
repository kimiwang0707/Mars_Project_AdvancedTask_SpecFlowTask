
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using SpecflowPages.Pages;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;


namespace SpecflowTests.Base

{
    [Binding]
    public class Start : Driver
    {

        [BeforeScenario]
        public void SetUp()
        {
            //Launch the browser
            Initialize();

           // //Call the Login Class
           //LoginPage.LoginStep(); 
        }
       
        [AfterScenario]                
        public void TearDown()
        {
            Thread.Sleep(500);
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.extent.EndTest(CommonMethods.test);

            // calling Flush writes everything to the log file (Reports)
            CommonMethods.extent.Flush();

            //Close the browser
            Driver.Close();
        }


        [Given(@"I login to Mars")]
        public void GivenILoginToMars()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginSteps();
            loginPage.VerifyLoginSteps();
        }

      
    }
}
