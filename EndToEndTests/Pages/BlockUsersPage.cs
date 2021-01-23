using OpenQA.Selenium;
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
    }
}
