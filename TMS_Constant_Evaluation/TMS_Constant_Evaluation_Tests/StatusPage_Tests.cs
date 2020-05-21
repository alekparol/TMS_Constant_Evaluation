using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;

namespace TMS_Constant_Evaluation_Tests
{
    [TestClass]
    public class StatusPage_Tests
    {
        [TestMethod]
        public void StatusPage_Initialization_Test_1()
        {           
            using (var driver = new ChromeDriver())
            {
                // Initialization
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                Assert.AreEqual("TMS - Porsche BAL 2.0", driver.Title);

                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();
                
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));
                
                StatusPage objectStatusPage = new StatusPage(driver);
                Assert.AreEqual("Status", objectStatusPage.PageTitle.Text);

                driver.Quit();
            }
        }
    }
}
