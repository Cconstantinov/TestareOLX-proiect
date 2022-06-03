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
    public class DeactivateAnnouncementTest
    {
        private IWebDriver driver;
        private AddEditAnnouncementPage addAnnouncementPage;
        private AddEditAnnouncementPage editAnnouncementPage;
        private MyAnnouncementPage myAnnouncementPage;
        String notice;

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
            //driver.Navigate().Refresh();
            var addAnnouncement = By.CssSelector("button[class=css-1a27wex-BaseStyles]");
            driver.waitForElement(addAnnouncement);
            addAnnouncementPage = homePage.menuLoggedIn.NavigateToAddAnnouncementPage();
            var inputData = new AddAnnouncementBO
            {
                title = "Proiect Facultate FEAA - UAIC",
                description = "Am adaugat acest anunt pentru un proiect in cadrul facultatii 'Alexandru Ioan Cuza' din Iasi.",
                materie = "Chimie"
            };
            myAnnouncementPage = addAnnouncementPage.CreateAnnouncement(inputData);
            editAnnouncementPage = myAnnouncementPage.NavigateToEditAnnouncement();
            var unpaid = By.CssSelector("button[data-testid=select-UNPAID]");
            driver.waitForElement(unpaid);
            var btnUnpaid = driver.FindElement(unpaid);
            btnUnpaid.Click();
            By deactivate = By.CssSelector("button[aria-label=Dezactivează]");
            driver.waitForElement(deactivate);
            var label = driver.FindElement(By.CssSelector("span[class=css-itibgd]")).Text;
            int nr = int.Parse(label.Substring(label.Length - 1));
            nr--;
            notice = "Nr. total de anunțuri: " + nr.ToString();
            var not = notice;
        }

        [TestMethod]
        public void ShouldDeactivateAddressSuccessfuly()
        {
            editAnnouncementPage.DeactivateAnnouncements();
            
            driver.Navigate().Refresh();
            var selector = By.CssSelector("span[class=css-itibgd]");
            driver.waitForElement(selector);
            Assert.IsTrue(driver.FindElement(selector).Text.Equals(notice));
        
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
