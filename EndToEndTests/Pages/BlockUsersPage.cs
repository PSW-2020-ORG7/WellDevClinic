using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndToEndTests.Pages
{
    public class BlockUsersPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:49153/html/blockUsers.html";

        private IWebElement LastRowBlock => Driver.FindElement(By.XPath("//table[@id='table_for_blocking']/tbody/tr[last()]/td[3]/button[@type='button']"));
        private IWebElement LastRowNumber => Driver.FindElement(By.XPath("//table[@id='table_for_blocking']/tbody/tr[last()]/td[1]"));
        private IWebElement LastRowNumberBlocked => Driver.FindElement(By.XPath("//table[@id='table_blocked']/tbody/tr[last()]/td[1]"));
        public static readonly string ALERT_MESSAGE = "Uspesno blokiran pacijent";

        public BlockUsersPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickBlock()
            => LastRowBlock.Click();

        public string GetLastRowNumber()
            => LastRowNumber.Text;

        public string GetLastRowNumberBlocked()
            => LastRowNumberBlocked.Text;
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
