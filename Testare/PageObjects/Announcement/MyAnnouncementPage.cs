using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testare.PageObjects.AddAnnouncements;
using Testare.Shared.MenuItemControl;
using Testare.Utils;

namespace Testare.PageObjects.Announcement
{
    public class MyAnnouncementPage
    {
        private IWebDriver driver;

        public MyAnnouncementPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public MenuItemControlLoggedIn menuLoggedIn => new MenuItemControlLoggedIn(driver);

        public AddEditAnnouncementPage NavigateToEditAnnouncement()
        {
            var validation = By.CssSelector("div[class=css-wfs9q9]");
            driver.waitForElement(validation);
            var icon = By.CssSelector("a[data-cy=myolx-link]");
            var btnIcon = driver.FindElement(icon);
            btnIcon.Click();
            return new AddEditAnnouncementPage(driver);
        }
    }
}
