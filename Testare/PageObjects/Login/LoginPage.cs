
using OpenQA.Selenium;
using Testare.PageObjects.Announcement;
using Testare.Utils;

namespace Testare.PageObjects.Login
{
    public class LoginPage
    {
        private IWebDriver driver;
        //creem contrustor ctor+2tab ptr a initializa driver-ul
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        //creem elemnetele din pagina de login
        //email textbox
        private By Email = By.Id("userEmail");
        private IWebElement txtEmail => driver.FindElement(Email);
        //parola
        private By Pass = By.Id("userPass");
        private IWebElement txtPassword => driver.FindElement(Pass);
        //buton 
        private By Login = By.Id("se_userLogin");
        private IWebElement btnLogin => driver.FindElement(Login);

        //creem o metoda ptr a accesa elementele declarate
        public MyAnnouncementPage LoginApplication(string email, string pasword)
        {
            driver.waitForElement(Email);
            txtEmail.SendKeys(email);
            driver.waitForElement(Pass);
            txtPassword.SendKeys(pasword);
            btnLogin.Click();
            return new MyAnnouncementPage(driver);
        }
    }
}
