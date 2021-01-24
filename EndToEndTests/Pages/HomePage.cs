using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndToEndTests.Pages
{
    class HomePage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:49153/html/homePage.html";

        private IWebElement ViewExaminationButton => Driver.FindElement(By.Id("viewExamination"));

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void ClickViewExaminations()
         => ViewExaminationButton.Click();

        public void Navigate()
           => Driver.Navigate().GoToUrl(URI);
    }
}
