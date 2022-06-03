using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Testare.PageObjects.Login;
using Testare.Shared.MenuItemControl;
using Testare.Utils;

namespace Testare
{
    [TestClass]
    public class LoginTests
    {
        //declaram variabile
        private IWebDriver driver;
        private LoginPage loginPage;

        

        [TestInitialize]
        //construim pre-requisite 
        public void testInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.olx.ro/");
            var menuItemControl = new MenuItemControlLoggedOut(driver);
            var cook3 = By.Id("onetrust-accept-btn-handler");
            driver.waitForElement(cook3);
            var btnCookie = driver.FindElement(cook3);
            btnCookie.Click();
            loginPage = menuItemControl.navigateToLoginPage();
            
        }


        [TestMethod] //adnotare care marcheaza metodele de test
        public void UserShouldLoginInSuccessfully()
        {
            loginPage.LoginApplication("pcezara372@gmail.com", "Testare123-");
            var cook = By.CssSelector("button[data-cy=welcome-modal-accept]");
            driver.waitForElement(cook);
            var btnCookie2 = driver.FindElement(cook);
            btnCookie2.Click();
            var cook2 = By.CssSelector("button[data-cy=ads-reposting-dismiss]");
            driver.waitForElement(cook2);
            var btnCookie3 = driver.FindElement(cook2);
            btnCookie3.Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector("h3[data-testid=header-title]")).Text.Equals("Anunțurile tale"));
        }



        [TestCleanup]
        public void testCleanup()
        {
            //quit browser
            driver.Quit();
        }
    }
}
