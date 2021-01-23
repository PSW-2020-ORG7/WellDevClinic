using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EndToEndTests.Pages
{
    public class ViewFeedbackAdminPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:49153/html/viewFeedbackAdmin.html";  //TODO PORT!!!
        private IWebElement Table => Driver.FindElement(By.Id("table"));
        private ReadOnlyCollection<IWebElement> Rows => Driver.FindElements(By.XPath("//table[@id='table']/tbody/tr"));
        private IWebElement LastRowNumber => Driver.FindElement(By.XPath("//table[@id='table']/tbody/tr[last()]/td[1]"));
        private IWebElement LastRowText => Driver.FindElement(By.XPath("//table[@id='table']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowPatient => Driver.FindElement(By.XPath("//table[@id='table']/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowPrivate => Driver.FindElement(By.XPath("//table[@id='table']/tbody/tr[last()]/td[4]/input[@type='checkbox']"));
        private IWebElement LastRowPublished => Driver.FindElement(By.XPath("//table[@id='table']/tbody/tr[last()]/td[5]/input[@type='checkbox']"));
        private IWebElement LastRowPublish => Driver.FindElement(By.XPath("//table[@id='table']/tbody/tr[last()]/td[6]/button[@type='button']"));
        private IWebElement BlockUserButton => Driver.FindElement(By.Id("blockUser"));

        public ViewFeedbackAdminPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public int FeedbackCount()
        {
            return Rows.Count;
        }

        public string GetLastRowNumber()
            => LastRowNumber.Text;

        public string GetLastRowText()
            => LastRowText.Text;

        public string GetLastRowPatient()
            => LastRowPatient.Text;

        public bool IsPrivateChecked()
            => LastRowPrivate.Selected;

        public bool IsPublishedChecked()
            => LastRowPublished.Selected;
        public bool IsPublishEnabled()
            => LastRowPublish.Enabled;

        public void Navigate()
            => Driver.Navigate().GoToUrl(URI);

        public void ClickPublish()
            => LastRowPublish.Click();

        public void ClickBlock()
            => BlockUserButton.Click();
    }
}
