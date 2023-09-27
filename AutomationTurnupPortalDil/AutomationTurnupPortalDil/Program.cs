﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Open chrome browser
IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

//Launch turnup portal and navigate to website login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

//Identify username textbox and enter valide username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//Identify password textbox and enter valide password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Identify the login button and click on the button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

//Check if user has logged in successfully
IWebElement helloHari=driver.FindElement(By.XPath($"//*[@id=\"logoutForm\"]/ul/li/a"));

if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User has loged in successefully");
}
else
{
    Console.WriteLine("User has not loged in");
}

//Test case - Create a new Time record

//Navigate to Time & Material module
IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationDropdown.Click();

IWebElement tmOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
tmOption.Click();


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
codeTextBox.SendKeys("12345");

//Enter Description
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
if (newCode.Text == "12345")
{
    Console.WriteLine("New time record has been created successfully");
}
else
{
    Console.WriteLine("Time record has not created");
}

//Test case - Edit the created new Time record

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
if (updatedCode.Text == "67890")
{
    Console.WriteLine("Time record has been updated successfully");
}
else
{
    Console.WriteLine("Time record has not updated");
}


//Test case - Delete the updated Time record

//Click delete button of last record
IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

//Click Ok button on alert popup
driver.SwitchTo().Alert().Accept();

Thread.Sleep(3000);

//Verifying whether last deleted record is removed from the list
IWebElement lastCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (lastCode.Text != "67890")
{
    Console.WriteLine("Last record has been deleted successfully");
}
else
{
    Console.WriteLine("Last records has not deleted");

}