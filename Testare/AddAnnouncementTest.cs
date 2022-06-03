using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Testare.PageObjects.AddAnnouncements;
using Testare.PageObjects.AddAnnouncements.InputData;
using Testare.PageObjects.Announcement;
using Testare.Shared.MenuItemControl;
using Testare.Utils;

namespace Testare
{
    [TestClass]
    public class AddAnnouncementTest
    {
        private IWebDriver driver;
        private AddEditAnnouncementPage addAnnouncementPage;
        private MyAnnouncementPage myAnnouncementPage;
        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.olx.ro/");
            var cook3 = By.Id("onetrust-accept-btn-handler");
            driver.waitForElement(cook3);
            var btnCookie = driver.FindElement(cook3);
            btnCookie.Click();
            var menuItemControlLoggedOut = new MenuItemControlLoggedOut(driver);
            var loginPage = menuItemControlLoggedOut.navigateToLoginPage();
            var homePage = loginPage.LoginApplication("pcezara372@gmail.com", "Testare123-");
            var cook = By.CssSelector("button[data-cy=welcome-modal-accept]");
            driver.waitForElement(cook);
            var btnCookie2 = driver.FindElement(cook);
            btnCookie2.Click();
            var cook2 = By.CssSelector("button[data-cy=ads-reposting-dismiss]");
            driver.waitForElement(cook2);
            var btnCookie3 = driver.FindElement(cook2);
            btnCookie3.Click();
            driver.Navigate().Refresh();
            var addAnnouncement = By.CssSelector("button[data-cy=post-new-ad-button]");
            driver.waitForElement(addAnnouncement);
            addAnnouncementPage = homePage.menuLoggedIn.NavigateToAddAnnouncementPage();
        }

        [TestMethod]
        public void ShouldAddAddressSuccessfuly()
        {
            var inputData = new AddAnnouncementBO
            {
                title = "Proiect Facultate FEAA - UAIC",
                description = "Am adaugat acest anunt pentru un proiect in cadrul facultatii 'Alexandru Ioan Cuza' din Iasi.",
                materie = "Chimie"
            };
            myAnnouncementPage = addAnnouncementPage.CreateAnnouncement(inputData);
            var validation = By.CssSelector("div[class=css-wfs9q9]");
            driver.waitForElement(validation);
            Assert.IsTrue(driver.FindElement(validation).Text.Equals("Adaugarea unui anunt suplimentar in categoria Meditatii necesita plata"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
