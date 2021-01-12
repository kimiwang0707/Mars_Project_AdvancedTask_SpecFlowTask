using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecflowPages
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }

        public static void Initialize()
        {
                //Defining the browser           
                driver = new ChromeDriver();
       
                //Maximise the window
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(BaseUrl);

                CommonMethods.ExtentReports();
          
        }

        public static string BaseUrl
        {
            get{ return ConstantUtils.Url; }
        }
           
        
        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1500);

        }

        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        //Close the browser
        public static void Close()
        {
            driver.Close();
            driver.Dispose();
        }

    }
}
