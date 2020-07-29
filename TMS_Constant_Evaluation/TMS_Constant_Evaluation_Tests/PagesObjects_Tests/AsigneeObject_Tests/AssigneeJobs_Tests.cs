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
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;

namespace TMS_Constant_Evaluation_Tests.PagesObjects_Tests.AsigneeObject_Tests
{
    [TestClass]
    public class AssigneeJobs_Tests
    {

        [TestMethod]
        public void AssigneeJobs_ParsingCorrectly_Test_1()
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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneeJobs> assigneesJobs = new List<AssigneeJobs>();

                AssigneeJobs auxiliaryAssigneesJob;

                auxiliaryAssigneesJob = new AssigneeJobs(r_LObjects.ElementAt(0));
                assigneesJobs.Add(auxiliaryAssigneesJob);

                /* Set of assertions */

                Assert.IsFalse(auxiliaryAssigneesJob.JobsButtonIsNull);
                Assert.IsFalse(auxiliaryAssigneesJob.JobsNameIsNull);
                Assert.IsTrue(auxiliaryAssigneesJob.IsParsingCorrect);
                Assert.AreNotEqual("", auxiliaryAssigneesJob.GetJobsName);
                Assert.AreNotEqual("", auxiliaryAssigneesJob.GetSourceLanguage);
                Assert.AreNotEqual("", auxiliaryAssigneesJob.GetTargetLanguage);

            }
        }

        [TestMethod]
        public void AssigneeJobs_ParsingCorrectly_Test_2()
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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneeJobs> assigneesJobs = new List<AssigneeJobs>();

                AssigneeJobs auxiliaryAssigneesJob;

                /* Set of assertions */

                foreach (IWebElement r_L in r_LObjects)
                {

                    auxiliaryAssigneesJob = new AssigneeJobs(r_L);
                    assigneesJobs.Add(auxiliaryAssigneesJob);

                    Assert.IsFalse(auxiliaryAssigneesJob.JobsButtonIsNull, "{0}", assigneesJobs.Count);
                    Assert.IsFalse(auxiliaryAssigneesJob.JobsNameIsNull);
                    Assert.IsTrue(auxiliaryAssigneesJob.IsParsingCorrect);
                    Assert.AreNotEqual("", auxiliaryAssigneesJob.GetJobsName);
                    Assert.AreNotEqual("", auxiliaryAssigneesJob.GetSourceLanguage);
                    Assert.AreNotEqual("", auxiliaryAssigneesJob.GetTargetLanguage);
                }

                Assert.AreEqual(250, assigneesJobs.Count);
            }
        }

        [TestMethod]
        public void AssigneeJobs_ParsingCorrectly_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Corteva";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                porscheAssigneesPage.ChosenActivityClick(driver, "Buffer_For_FreewayReview_H");
                porscheAssigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneeJobs> assigneesJobs = new List<AssigneeJobs>();

                AssigneeJobs auxiliaryAssigneesJob;

                /* Set of assertions */

                foreach (IWebElement r_L in r_LObjects)
                {

                    auxiliaryAssigneesJob = new AssigneeJobs(r_L);
                    assigneesJobs.Add(auxiliaryAssigneesJob);

                    Assert.IsFalse(auxiliaryAssigneesJob.JobsButtonIsNull, "{0}", assigneesJobs.Count);
                    Assert.IsFalse(auxiliaryAssigneesJob.JobsNameIsNull);
                    Assert.IsTrue(auxiliaryAssigneesJob.IsParsingCorrect);
                    Assert.AreNotEqual("", auxiliaryAssigneesJob.GetJobsName);
                    Assert.AreNotEqual("", auxiliaryAssigneesJob.GetSourceLanguage);
                    Assert.AreNotEqual("", auxiliaryAssigneesJob.GetTargetLanguage);
                }

                Assert.AreEqual(15, assigneesJobs.Count);
            }
        }

        /* Assignee Job Click */

        [TestMethod]
        public void AssingeeJobs_AssigneeJobButtonClick_Test_1()
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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneeJobs> assigneesJobs = new List<AssigneeJobs>();

                AssigneeJobs auxiliaryAssigneesJob = new AssigneeJobs(r_LObjects.ElementAt(0));
                assigneesJobs.Add(auxiliaryAssigneesJob);

                auxiliaryAssigneesJob.AssigneeJobButtonClick(driver);
                IWebElement dropDownElement = driver.FindElement(By.XPath("//*[@class=\"m1 lay_flt\"]"));

                /* Set of assertions */

                Assert.IsTrue(dropDownElement.Displayed);

            }
        }


    }
}
