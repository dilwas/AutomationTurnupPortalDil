using AutomationTurnupPortalDil.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Open chrome browser
        IWebDriver driver = new ChromeDriver();
        //Loginpage page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Homepage page object initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.VerifySucssesLogin(driver);
        homePageObj.GoToTMPage(driver);

        //TMpage page object initialization and definition
        TMPage tmPageObj = new TMPage();
        tmPageObj.CreateTimeRecord(driver);
        tmPageObj.EditTimeRecord(driver);
        tmPageObj.DeleteTimeRecord(driver);
    }  
}