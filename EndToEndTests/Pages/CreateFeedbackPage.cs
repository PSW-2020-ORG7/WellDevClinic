using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndToEndTests.Pages
{
    public class CreateFeedbackPage 
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:49153/html/createFeedback.html";
        private IWebElement CommentBox => Driver.FindElement(By.Id("comment"));
        private IWebElement AnonimityBox => Driver.FindElement(By.Id("anonymous"));
        private IWebElement PrivateBox => Driver.FindElement(By.Id("private"));
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));

        public static readonly string ALERT_MESSAGE = "Uspesno ste poslali komentar";

        public CreateFeedbackPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool CommentBoxDisplayed()
            => CommentBox.Displayed; 

        public bool AnonimityBoxDisplayed()
            => AnonimityBox.Displayed;

        public bool PrivateBoxDisplayed()
            => PrivateBox.Displayed;

        public void InsertFeedback(string feedback)
            => CommentBox.SendKeys(feedback);

        public void CheckAnonimity()
            => AnonimityBox.Click();

        public void CheckPrivate()
            => PrivateBox.Click();

        public void ClickSubmit()
            => SubmitButton.Click();

        public void Navigate() 
            => Driver.Navigate().GoToUrl(URI);
        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 59));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
            => Driver.SwitchTo().Alert().Text;

        public void ResolveAlertDialog()
            => Driver.SwitchTo().Alert().Accept();
    }
}
