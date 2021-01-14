using ExcelDataReader;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReaderFactory = ExcelDataReader.ExcelReaderFactory;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace SpecflowPages
{
    public class CommonMethods
    {
        // ExcelLib
        #region Excel 
        public class ExcelLib
        {
            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }


            public static void ClearData()
            {
                dataCol.Clear();
            }


            private static DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                // Open file and return as Stream
                Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (ExcelDataReader.IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        //excelReader.IsFirstRowAsColumnNames = true;
                        //Return as dataset
                        // DataSet result = excelReader.AsDataSet();

                        DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }

                        });

                        //Get all the tables
                        DataTableCollection table = result.Tables;

                        // store it in data table
                        DataTable resultTable = table[SheetName];

                        //excelReader.Dispose();
                        //excelReader.Close();
                        // return
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                    return data.ToString();
                }

                catch (Exception e)
                {
                    //Added by Kumar
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        dataCol.Add(dtTable);


                    }
                }

            }
        }

        #endregion



        //Screenshots
        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (ConstantUtils.ScreenShotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-MM-yyyy_mss"));

                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion

       
        //ExtentReports
        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        public static void ExtentReports()
        {         
                extent = new ExtentReports(ConstantUtils.ReportPath, false, DisplayOrder.NewestFirst);
                extent.LoadConfig(ConstantUtils.ReportXMLPath);           
        }

        #endregion



        //Element Present
        #region Element Present
        //Method to check the element is showing on screen
        public static bool ElementVisible(IWebDriver driver, string Locator, string Lvalue)
        {
            try
            {
                if (Locator == "Id")
                    return driver.FindElement(By.Id(Lvalue)).Displayed && driver.FindElement(By.Id(Lvalue)).Enabled;
                else if (Locator == "XPath")
                    return driver.FindElement(By.XPath(Lvalue)).Displayed && driver.FindElement(By.XPath(Lvalue)).Enabled;
                else if (Locator == "CSS")
                    return driver.FindElement(By.CssSelector(Lvalue)).Displayed && driver.FindElement(By.CssSelector(Lvalue)).Enabled;
                else
                {
                    Console.WriteLine("Invalid Locator value");
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;

            }
        }
        public static bool isElementPresent(By by)
        {
            try
            {
                Driver.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion


        //Wait Element
        #region Wait Element
        public static void WaitForElement(IWebDriver driver, string key, string value, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (key == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(value)));
            }
            if (key == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(value)));
            }
            if (key == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(value)));
            }
            if (key == "ClassName")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName(value)));
            }
            if (key == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(value)));
            }
            if (key == "LinkText")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText(value)));
            }

        }

        public static void WaitForElementClickable(IWebDriver driver, string key, string value, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (key == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(value)));
            }
            if (key == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(value)));
            }
            if (key == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(value)));
            }
            if (key == "ClassName")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(value)));
            }
            if (key == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(value)));
            }
            if (key == "LinkText")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText(value)));
            }

        }

        public static void WaitForTextPresentInElement(IWebDriver driver, IWebElement element, string text, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));

        }

        public static void WaitForPageLoad()
        {
            var wait = new WebDriverWait(Driver.driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        #endregion



        #region Scroll the webpage
        public static void ScrollToTop()
        {
            Actions a = new Actions(Driver.driver);
            a.SendKeys(Keys.Home).Perform();
        }

        public static void ScrollToBottom()
        {
            Actions a = new Actions(Driver.driver);
            a.SendKeys(Keys.End).Perform();
        }
        #endregion
    }
}
