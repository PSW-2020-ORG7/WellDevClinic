using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading;
using EndToEndTests.Pages;

namespace EndToEndTests
{
    public class BlockPatientTest : IDisposable
    {
        private readonly IWebDriver Driver;
        private LoginPage LoginPage;
        private BlockUsersPage BlockUsersPage;
        private ViewFeedbackAdminPage ViewFeedbackAdminPage;

        public BlockPatientTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            Driver = new ChromeDriver(options);

            LoginPage = new LoginPage(Driver);
            LoginPage.Navigate();
            LoginPage.InsertUsername("admin");
            LoginPage.InsertPassword("admin");
            LoginPage.ClickSubmit();
            Thread.Sleep(10000);

            ViewFeedbackAdminPage = new ViewFeedbackAdminPage(Driver);
            ViewFeedbackAdminPage.ClickBlock();
            BlockUsersPage = new BlockUsersPage(Driver);
            Thread.Sleep(2000);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void Block_User()
        {
            var id = BlockUsersPage.GetLastRowNumber();
            BlockUsersPage.ClickBlock();
            Thread.Sleep(3000);
            var idBlocked = BlockUsersPage.GetLastRowNumberBlocked();
            var idForBlocking = BlockUsersPage.GetLastRowNumber();
            Assert.Equal(id, idBlocked);
            Assert.NotEqual(id, idForBlocking);
        }


    }
}
