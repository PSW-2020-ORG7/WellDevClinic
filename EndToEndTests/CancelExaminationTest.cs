using EndToEndTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EndToEndTests
{
    public class CancelExaminationTest : IDisposable
    {
        private readonly IWebDriver Driver;
        private LoginPage LoginPage;
        private HomePage HomePage;
        private ViewExaminationsPage ViewExaminationsPage;

        public CancelExaminationTest()
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
            LoginPage.InsertUsername("patient");
            LoginPage.InsertPassword("patient");
            LoginPage.ClickSubmit();
            Thread.Sleep(5000);

            HomePage = new HomePage(Driver);
            HomePage.ClickViewExaminations();
            ViewExaminationsPage = new ViewExaminationsPage(Driver);
            Thread.Sleep(8000);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }


        [Fact]
        public void Cancel_Examination()
        {
            var date = ViewExaminationsPage.GetLastRowDate();
            var time = ViewExaminationsPage.GetLastRowTime();
            ViewExaminationsPage.ClickCancel();
            Console.WriteLine(date);
            Console.WriteLine(time);
            Thread.Sleep(5000);
            ViewExaminationsPage.WaitForAlertDialog();
            Assert.Equal(ViewExaminationsPage.GetDialogMessage(), ViewExaminationsPage.ALERT_MESSAGE);
            ViewExaminationsPage.ResolveAlertDialog();
            Assert.Equal(Driver.Url, ViewExaminationsPage.URI);
            Thread.Sleep(5000);
            var lastRowDate = ViewExaminationsPage.GetLastRowDate();
            var lastRowTime = ViewExaminationsPage.GetLastRowTime();
            Assert.True(date == lastRowDate || time == lastRowTime ? true : false, "Failed");

        }
    }
}
