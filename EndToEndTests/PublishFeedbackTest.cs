using System;
using System.Collections.Generic;
using System.Text;
using EndToEndTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;

namespace EndToEndTests
{
    public class PublishFeedbackTest : IDisposable
    {
        private readonly IWebDriver Driver;
        private ViewFeedbackAdminPage ViewFeedbackPage;
        private LoginPage LoginPage;

        public PublishFeedbackTest()
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

            ViewFeedbackPage = new ViewFeedbackAdminPage(Driver);
            ViewFeedbackPage.Navigate();
        }
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void Publish_Feedback()
        {
            ViewFeedbackPage.ClickPublish();
            Thread.Sleep(3000);
            String comment = ViewFeedbackPage.GetLastRowText();
            Assert.True(ViewFeedbackPage.IsPublishedChecked());
            Assert.False(ViewFeedbackPage.IsPrivateChecked());
            Assert.Equal(comment, ViewFeedbackPage.GetLastRowText());
        }
    }
}
