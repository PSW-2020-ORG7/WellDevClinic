using EndToEndTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;

namespace EndToEndTests
{
    public class CreateFeedbackTest : IDisposable
    {
        private readonly IWebDriver Driver;
        private CreateFeedbackPage FeedbackPage;
        private LoginPage LoginPage;
        private ViewFeedbackAdminPage ViewFeedbackPage;

        private int FeedbackCount = 0;
        public CreateFeedbackTest()
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
            LoginPage.InsertUsername("vuk");
            LoginPage.InsertPassword("vuk");
            LoginPage.ClickSubmit();
            Thread.Sleep(10000);

            //Assert.Equal(Driver.Url, "http://localhost:49153/html/homePage.html");

            FeedbackPage = new CreateFeedbackPage(Driver);
            FeedbackPage.Navigate();
            Assert.True(FeedbackPage.CommentBoxDisplayed());
            Assert.True(FeedbackPage.AnonimityBoxDisplayed());
            Assert.True(FeedbackPage.PrivateBoxDisplayed());
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void CreateComment_PrivateChecked()
        {
            FeedbackPage.InsertFeedback("Great");
            FeedbackPage.CheckAnonimity();
            FeedbackPage.CheckPrivate();
            FeedbackPage.ClickSubmit();
            FeedbackPage.WaitForAlertDialog();
            Assert.Equal(FeedbackPage.GetDialogMessage(), CreateFeedbackPage.ALERT_MESSAGE);
            FeedbackPage.ResolveAlertDialog();
            Assert.Equal(Driver.Url, CreateFeedbackPage.URI);

            FeedbackPage.ClickLogOut();
            LoginPage.InsertUsername("admin");
            LoginPage.InsertPassword("admin");
            LoginPage.ClickSubmit();
            Thread.Sleep(10000);

            ViewFeedbackPage = new ViewFeedbackAdminPage(Driver);
            ViewFeedbackPage.Navigate();
            ViewFeedbackPage.EnsurePageIsDisplayed();

            Assert.Equal(ViewFeedbackPage.GetLastRowNumber(), "" + ViewFeedbackPage.FeedbackCount());
            Assert.Equal("Great", ViewFeedbackPage.GetLastRowText());
            Assert.True(ViewFeedbackPage.IsPrivateChecked());
            Assert.False(ViewFeedbackPage.IsPublishedChecked());
            Assert.False(ViewFeedbackPage.IsPublishEnabled());            
        }

        [Fact]
        public void CreateComment_PrivateNotChecked()
        {
            FeedbackPage.InsertFeedback("Not Great");
            FeedbackPage.CheckAnonimity();
            FeedbackPage.ClickSubmit();
            FeedbackPage.WaitForAlertDialog();
            Assert.Equal(FeedbackPage.GetDialogMessage(), CreateFeedbackPage.ALERT_MESSAGE);
            FeedbackPage.ResolveAlertDialog();
            Assert.Equal(Driver.Url, CreateFeedbackPage.URI);

            FeedbackPage.ClickLogOut();
            LoginPage.InsertUsername("admin");
            LoginPage.InsertPassword("admin");
            LoginPage.ClickSubmit();
            Thread.Sleep(10000);

            ViewFeedbackPage = new ViewFeedbackAdminPage(Driver);
            ViewFeedbackPage.Navigate();
            ViewFeedbackPage.EnsurePageIsDisplayed();

            Assert.Equal(ViewFeedbackPage.GetLastRowNumber(), "" + ViewFeedbackPage.FeedbackCount());
            Assert.Equal("Not Great", ViewFeedbackPage.GetLastRowText());
            Assert.False(ViewFeedbackPage.IsPrivateChecked());
            Assert.False(ViewFeedbackPage.IsPublishedChecked());
            Assert.True(ViewFeedbackPage.IsPublishEnabled());
        }
    }
}
