using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testare.PageObjects.Login;

namespace Testare.Shared.MenuItemControl
{
    class MenuItemControlLoggedOut
    {
        public IWebDriver driver;

        public MenuItemControlLoggedOut(IWebDriver browser)
        {
            driver = browser;
        }

        private By logo = By.Id("headerLogo");
        public IWebElement btnLogo => driver.FindElement(logo);

        private By message = By.XPath("//*[@id='nav - conversations']/a");
        public IWebElement btnMessage => driver.FindElement(message);

        private By favorite = By.Id("observed-search-link");
        public IWebElement btnFavorite => driver.FindElement(favorite);

        private By account = By.Id("topLoginLink");
        public IWebElement btnAccount => driver.FindElement(account);

        private By addAnnouncement = By.Id("postNewAdLink");
        public IWebElement btnAddAnnouncement => driver.FindElement(addAnnouncement);

        public LoginPage navigateToLoginPage()
        {
            btnAccount.Click();
            return new LoginPage(driver);
        }
    }
}
