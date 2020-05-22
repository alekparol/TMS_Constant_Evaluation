using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void StatusPage_Initialization_Test_2()
        {           
            using (var driver = new ChromeDriver())
            {
                // Initialization
                List<StatusObject> listStatusObjects = new List<StatusObject>();
                StatusObject auxiliaryStatusObject = new StatusObject();

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
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();
                
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));                
                StatusPage objectStatusPage = new StatusPage(driver);

                IReadOnlyCollection<IWebElement> listOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));
                Assert.AreEqual("RedSys - X171702_4440095", listOfTitlesStatusWebElements.ElementAt(0).Text);
                Assert.AreEqual("de-de → ar-ae", listOfTitlesStatusWebElements.ElementAt(0).FindElement(By.XPath("..")).FindElement(By.ClassName("grp_lg")).Text);

                if(listOfTitlesStatusWebElements.Count != 0)
                {
                    foreach(IWebElement element in listOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        listStatusObjects.Add(auxiliaryStatusObject);
                    }                    
                }

      
                Assert.AreNotEqual(12, listStatusObjects[0].stepsCount);
                Assert.AreEqual(21, listStatusObjects.Count);

                objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                driver.Quit();
            }
        }

        [TestMethod]
        public void StatusPage_Initialization_Test_3()
        {
            using (var driver = new ChromeDriver())
            {
                // Initialization
                List<StatusObject> listStatusObjects = new List<StatusObject>();
                List<StatusObject> secondListStatusObjects = new List<StatusObject>();

                StatusObject auxiliaryStatusObject = new StatusObject();

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
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));
                StatusPage objectStatusPage = new StatusPage(driver);

                IReadOnlyCollection<IWebElement> listOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));
               

                if (listOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in listOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        listStatusObjects.Add(auxiliaryStatusObject);
                    }
                }

                objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                IReadOnlyCollection<IWebElement> secondListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                if (secondListOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in secondListOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        secondListStatusObjects.Add(auxiliaryStatusObject);
                    }
                }

                Assert.AreNotEqual(listStatusObjects.Count, secondListStatusObjects.Count);
                Assert.AreEqual("(1)", secondListOfTitlesStatusWebElements.ElementAt(0).FindElement(By.XPath("../../..")).FindElement(By.ClassName("r_LCount")).Text);

                driver.Quit();
            }
        }
    }
}
