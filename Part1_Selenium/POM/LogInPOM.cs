using System;
using OpenQA.Selenium;

namespace Part1_Selenium.POM
{
    public class LogInPOM
    {
        public IWebDriver driver { get; }
        private IWebElement username => driver.FindElement(By.Id("user-name"));
        private IWebElement password => driver.FindElement(By.Id("password"));
        private IWebElement loginbutton => driver.FindElement(By.Id("login-button"));
        private IWebElement error => driver.FindElement(By.XPath("//div[@class='error-message-container error']"));

        public LogInPOM(IWebDriver _driver)
        {
            driver = _driver;
        }

        public bool UsernameDisplayed() => username.Displayed;

        public bool PasswordDisplayed() => password.Displayed;

        public bool LoginbuttonDisplayed() => loginbutton.Displayed;

        public void LogInClick(string user_name, string pass)
        {
            username.SendKeys(user_name);
            password.SendKeys(pass);
            loginbutton.Click();
        }

        public bool IsErrorMessageDisplayed() => error.Displayed;
    }
}

