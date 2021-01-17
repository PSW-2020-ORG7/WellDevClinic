using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EndToEndTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:49153/html/login.html";

        private IWebElement Table => Driver.FindElement(By.Id("table"));

        private IWebElement UsernameBox => Driver.FindElement(By.Id("username"));
        private IWebElement PasswordBox => Driver.FindElement(By.Id("password"));
        private IWebElement SubmitButton => Driver.FindElement(By.Name("submit"));

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void InsertUsername(string username)
            => UsernameBox.SendKeys(username);

        public void InsertPassword(string password)
            => PasswordBox.SendKeys(password);

        public void ClickSubmit()
            => SubmitButton.Click();

        public void Navigate() 
            => Driver.Navigate().GoToUrl(URI);
    }
}
