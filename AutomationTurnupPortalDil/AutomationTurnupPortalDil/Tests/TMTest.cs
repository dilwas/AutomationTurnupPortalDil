using AutomationTurnupPortalDil.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationTurnupPortalDil.Pages.Utilites;

namespace AutomationTurnupPortalDil.Tests
{
    [TestFixture]
    public class TMTest : CommonDriver
    {
        [SetUp]
        public void setup()
        {
            //Open chrome browser
            driver = new ChromeDriver();
            //Loginpage page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Homepage page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.VerifySucssesLogin(driver);
            homePageObj.GoToTMPage(driver);
        }


        [Test, Order(1),Description("This test create new time records with valid data")]
        public void TestCreateTimeRecord()
        {
            //TMpage page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTimeRecord(driver);
        }

        [Test, Order(2), Description("This test update an excisting time record with valid data")]

        public void TestEditTimeRecord()
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTimeRecord(driver);
        }

        [Test, Order(3), Description("This delets an excisting time record")]

        public void TestDeleteTimeRecord()
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
        
        
        
        
        
        
        
      

      
        
        
    }
}

