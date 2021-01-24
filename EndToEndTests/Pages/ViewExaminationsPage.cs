using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EndToEndTests.Pages
{
    class ViewExaminationsPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:49153/html/viewExaminations.html";  //TODO PORT!!!

        private IWebElement Table => Driver.FindElement(By.Id("tableU"));
        private ReadOnlyCollection<IWebElement> Rows => Driver.FindElements(By.XPath("//table[@id='tableU']/tbody/tr"));
        private IWebElement LastRowDate => Driver.FindElement(By.XPath("//table[@id='tableU']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowTime => Driver.FindElement(By.XPath("//table[@id='tableU']/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowCancel => Driver.FindElement(By.XPath("//table[@id='tableU']/tbody/tr[last()]/button[@type='button']"));

        public static readonly string ALERT_MESSAGE = "Appointment canceled successfully";

        public ViewExaminationsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickCancel()
           => LastRowCancel.Click();

        public string GetLastRowDate()
          => LastRowDate.Text;
        public string GetLastRowTime()
          => LastRowTime.Text;
        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 59));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
            => Driver.SwitchTo().Alert().Text;

        public void ResolveAlertDialog()
            => Driver.SwitchTo().Alert().Accept();

        public void Navigate()
           => Driver.Navigate().GoToUrl(URI);
    }
}
