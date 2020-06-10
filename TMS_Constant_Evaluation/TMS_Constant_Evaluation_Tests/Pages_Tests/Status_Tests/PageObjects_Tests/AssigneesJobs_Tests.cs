using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Status_Tests.PageObjects_Tests
{
    [TestClass]
    public class AssigneesJobs_Tests
    {

        [TestMethod]
        public void AssigneesJobs_ParsingCorrectly_Test_1()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                porscheBalPage.StatusClick(driver);
                StatusPage2 porscheStatusPage = new StatusPage2(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneesJobs> assigneesJobs = new List<AssigneesJobs>();

                AssigneesJobs auxiliaryAssigneesJob;

                foreach(IWebElement r_L in r_LObjects)
                {

                    auxiliaryAssigneesJob = new AssigneesJobs(r_L);
                    assigneesJobs.Add(auxiliaryAssigneesJob);

                }

                /* Set of assertions */

                Assert.AreEqual(250, assigneesJobs.Count);
                
                foreach(AssigneesJobs job in assigneesJobs)
                {
                    Assert.AreEqual(true, job.IsParsedCorrectly);
                    Assert.AreNotEqual("", job.JobsName);
                    Assert.AreNotEqual("", job.SourceLanguage);
                    Assert.AreNotEqual("", job.TargetLanguage);
                }
            }

        }
    }
}
