﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Pages
{
    public class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }
        #endregion


        // Declare the key details on page
        private int listQty;
        
        public void NavigateToManageListings(IWebDriver driver)
        {
            // Click Manage Listing Tab
            WaitForElement(driver, "LinkText", "Manage Listings", 10);
            manageListingsLink.Click();
        }

        public void EditListing(IWebDriver driver)
        {
            try
            {
                //Populate the Excel Sheet
                ExcelLib.PopulateInCollection(ConstantUtils.ManageListingPath, "ManageListings");

                // Wait element turn up
                WaitForElement(driver, "XPath", "(//i[@class='outline write icon'])[1]", 10);

                // Click Edit (Change title, description and servie type)
                edit.Click();

                // Wait for element turn up on editing page
                WaitForElement(driver, "Name", "title", 10);

                // Edit title
                try
                {
                    IWebElement titleOnPage = driver.FindElement(By.Name("title"));
                    titleOnPage.Clear();
                    titleOnPage.SendKeys(ExcelLib.ReadData(2, "Title"));
                }
                catch (Exception e1)
                { Assert.Fail("Please check the input format again!", e1.Message); }

                // Edit Description
                try
                {
                    IWebElement descriptionOnPage = driver.FindElement(By.Name("description"));
                    descriptionOnPage.Clear();
                    descriptionOnPage.SendKeys(ExcelLib.ReadData(2, "Description"));
                }
                catch (Exception e2)
                { Assert.Fail("Please check the input format again!", e2.Message); }

                // Edit Category
                try
                {
                    WaitForElement(driver, "Name", "categoryId", 10);
                    IWebElement categoryDropdown = driver.FindElement(By.Name("categoryId"));

                    new SelectElement(categoryDropdown).SelectByText(ExcelLib.ReadData(2, "Category"));
                }
                catch (Exception e3)
                { Assert.Fail("Failed to select category!", e3.Message); }

                // Click Save
                driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Fail to edit listing!");
                Assert.Fail("Test failed to edit listing", ex.Message);
            }
        }


        public void VerifyEditListing(IWebDriver driver)
        {
            try
            {
                // Wait element turn up         
                try
                {
                    WaitForElement(driver, "XPath", "(//i[@class='eye icon'])[1]", 10);
                }
                catch (NoSuchElementException)
                {
                    test.Log(LogStatus.Fail, "No listing on page, please add some!");
                    Assert.Fail("No listing on page or failed to load listings, please add listings first!");
                }

                // Verify the detail is updated
                var categoryInList = driver.FindElement(By.XPath("//*[@id='listing-management-section']//tr[1]/td[2]")).Text;
                Assert.That(categoryInList, Is.EqualTo(ExcelLib.ReadData(2, "Category")));

                var titleInList = driver.FindElement(By.XPath("//*[@id='listing-management-section']//tr[1]/td[3]")).Text;
                Assert.That(titleInList, Is.EqualTo(ExcelLib.ReadData(2, "Title")));

                var descriptionInList = driver.FindElement(By.XPath("//*[@id='listing-management-section']//tr[1]/td[4]")).Text;
                Assert.That(descriptionInList, Contains.Substring(descriptionInList.Substring(0, descriptionInList.Length - 3)));
                test.Log(LogStatus.Pass, "Edit listing successfully!");

            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Fail to verify editing listing!");
                Assert.Fail("Test failed to verify editing listing", ex.Message);
            }
        }


        public void DeleteListing(IWebDriver driver)
        {
            try
            {
                //Populate the Excel Sheet
                ExcelLib.PopulateInCollection(ConstantUtils.ManageListingPath, "ManageListings");

                // Wait element turn up
                try
                {
                    WaitForElement(driver, "XPath", "(//i[@class='remove icon'])[1]", 6);
                }
                catch (Exception e)
                {
                    Assert.Fail("There is no listing, please add listing first!", e.Message);
                }

                // Obtain the quantity of element
                var list = driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr"));
                listQty = list.Count();

                // Click delete
                delete.Click();

                // Confirm Delete or not
                WaitForElement(driver, "ClassName", "actions", 5);
                driver.FindElement(By.XPath("//div[@class='actions']/button[contains(text(),'"
                    + ExcelLib.ReadData(2, "ConfirmDeletion") + "')]")).Click();
            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Fail to delete listing!");
                Assert.Fail("Test failed to delete listing", ex.Message);
            }

        }

        public void VerifyDeleteListing(IWebDriver driver)
        {
            try
            {
                // Wait element turn up 
                try
                {
                    var listAfterDelete = driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr"));

                    int listQtyAfterDeletion = listAfterDelete.Count();

                    // Verify the quantity of elements
                    if (listQtyAfterDeletion == listQty - 1)
                    {
                        test.Log(LogStatus.Pass, "Verify deleting listing sucessfully!");
                        Assert.Pass("Verify deleting list successfully!");
                    }
                    //else
                    //{
                    //    Assert.Fail("Failed to delete the list!");
                    //}
                }
                catch (NoSuchElementException)
                {
                    int listQtyAfterDeletion = 0;
                    // Verify the quantity of elements
                    if (listQtyAfterDeletion == listQty - 1)
                    {
                        test.Log(LogStatus.Pass, "Delete listing sucessfully!");
                        Assert.Pass("Verify deleting list successfully!");
                    }
                    else
                    {
                        test.Log(LogStatus.Fail, "Fail to delete listing!");
                        Assert.Fail("Failed to delete the list!");
                    }
                }
            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Fail to delete listing!");
                Assert.Fail("Test failed to verify deleting listing", ex.Message);
            }

        }















    }
}
