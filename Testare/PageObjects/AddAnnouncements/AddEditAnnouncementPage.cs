using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testare.PageObjects.AddAnnouncements.InputData;
using Testare.PageObjects.Announcement;
using Testare.Utils;

namespace Testare.PageObjects.AddAnnouncements
{
    public class AddEditAnnouncementPage
    {
        private IWebDriver driver;

        public AddEditAnnouncementPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private By title = By.CssSelector("textarea[name=title]");
        private IWebElement txtTitle => driver.FindElement(title);

        private By category = By.CssSelector("div[data-cy=posting-select-category]");
        private IWebElement btnCategory => driver.FindElement(category);

        private By category2 = By.CssSelector("button[data-cy=posting-suggested-categories-item]");
        private IWebElement btnCategory2 => driver.FindElement(category2);

        private By description = By.CssSelector("textarea[data-cy=posting-description]");
        private IWebElement txtDescription => driver.FindElement(description);

        private By submit = By.CssSelector("button[type=submit]");
        private IWebElement btnSubmit => driver.FindElement(submit);

        private By button = By.CssSelector("button[data-testid = dropdown-expand-button]");
        private IWebElement btnMaterie => driver.FindElement(button);

        private By materie = By.CssSelector("ul[data-testid=dropdown-list]");
        private IList<IWebElement> lstMaterie => driver.FindElements(materie);

        public MyAnnouncementPage CreateAnnouncement(AddAnnouncementBO inputData)
        {
            driver.waitForElement(title);
            txtTitle.Clear();
            txtTitle.SendKeys(inputData.title);
            btnCategory.Click();
            driver.waitForElement(category2);
            btnCategory2.Click();
            txtDescription.Clear();
            txtDescription.SendKeys(inputData.description);
            btnMaterie.Click();
            lstMaterie[0].Click();
            btnSubmit.Click();
            return new MyAnnouncementPage(driver);
        }

        public void EditAnnouncements(AddAnnouncementBO inputData)
        {
            /*
            By edit = By.CssSelector("ul[data-testid=inventory-item-actions]");
            driver.waitForElement(edit);
            IList<IWebElement> lstButtons = driver.FindElements(edit);
            lstButtons[1].Click();
            */
            
            By edit = By.CssSelector("a[aria-label=Editează]");
            driver.waitForElement(edit);
            IWebElement btnEdit = driver.FindElement(edit);
            btnEdit.Click();

            By label = By.CssSelector("h2[data-cy=posting-container-header]");
            driver.waitForElement(label);

            txtTitle.Clear();
            txtTitle.SendKeys(inputData.title);
            btnSubmit.Click();
            
        }

        public void DeactivateAnnouncements()
        {
            By deactivate = By.CssSelector("button[aria-label=Dezactivează]");
            driver.waitForElement(deactivate);
            IWebElement btnDeactivate = driver.FindElement(deactivate);
            btnDeactivate.Click();
        }
    }
}
