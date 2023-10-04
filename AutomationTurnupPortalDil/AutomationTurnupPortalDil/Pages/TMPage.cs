using AutomationTurnupPortalDil.Pages.Utilites;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTurnupPortalDil.Pages
{
    public class TMPage
    {
        //Test case - Create a new Time record
        public void CreateTimeRecord(IWebDriver driver)
        {
            // WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"container\"]/p/a")));
            Wait.WaitToBeClickabel(driver, "Xpath", "//*[@id=\"container\"]/p/a", 5);
            //Click on the create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select time from dropdown
            IWebElement typemainCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typemainCodeDropdown.Click();
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            typeCodeDropdown.Click();

            //Enter code 
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            Wait.WaitToBeClickabel(driver, "Id", "Code", 7);
            codeTextBox.SendKeys("12345");

            //Enter Description
            Wait.WaitToBeVisible(driver, "Id", "Description", 7);
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("This is a test 1");

            //Enter price
            IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextBox.SendKeys("101");

            //Click on the save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(5000);
            //Check if a new Time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newCode.Text == "12345", "Time record has not created");
        }

        //Test case - Edit the created new Time record
        public void EditTimeRecord(IWebDriver driver)
        {
            //Nabvigaeting to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            //Click edit button of last record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Change the code
            IWebElement editCodeTextBox = driver.FindElement(By.Id("Code"));
            editCodeTextBox.Clear();
            editCodeTextBox.SendKeys("67890");

            //Click on the save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            Thread.Sleep(5000);
            //Check if the Time record has been updated successfully
            IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editGoToLastPageButton.Click();

            IWebElement updatedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(updatedCode.Text == "67890", "Time record has not updated");
        }

        //Test case - Delete the updated Time record
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Nabvigaeting to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            //Click delete button of last record
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            //Click Ok button on alert popup
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            //Verifying whether last deleted record is removed from the list
            IWebElement lastCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastCode.Text != "67890", "Last record has not deleted");
        }
    }
}
