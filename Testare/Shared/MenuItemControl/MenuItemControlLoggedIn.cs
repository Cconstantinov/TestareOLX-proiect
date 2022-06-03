using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testare.PageObjects.AddAnnouncements;
using Testare.PageObjects.Login;
using Testare.Utils;

namespace Testare.Shared.MenuItemControl
{
    public class MenuItemControlLoggedIn 
    {
        public IWebDriver driver;

        public MenuItemControlLoggedIn(IWebDriver browser)
        {
            driver = browser;
        }

        private By logo = By.CssSelector("span[class=css-1kpgv52]");
        public IWebElement btnLogo => driver.FindElement(logo);

        private By message = By.CssSelector("span[class=css-1o5oslh]");
        public IWebElement btnMessage => driver.FindElement(message);

        private By favorite = By.CssSelector("svg[class=css-135i32f]");
        public IWebElement btnFavorite => driver.FindElement(favorite);

        private By account = By.CssSelector("a[class=css-12l1k7f");
        public IWebElement btnAccount => driver.FindElement(account);

        //private By addAnnouncement = By.CssSelector("button[data-cy=post-new-ad-button]");
        //public IWebElement btnAddAnnouncement => driver.FindElement(addAnnouncement);

        public AddEditAnnouncementPage NavigateToAddAnnouncementPage()
        {
            var  addAnnouncement = By.CssSelector("button[class=css-1a27wex-BaseStyles]");
            driver.waitForElement(addAnnouncement);
            var btnAddAnnouncement = driver.FindElement(addAnnouncement);
            btnAddAnnouncement.Click();
            return new AddEditAnnouncementPage(driver);
        }

        
    }
}
