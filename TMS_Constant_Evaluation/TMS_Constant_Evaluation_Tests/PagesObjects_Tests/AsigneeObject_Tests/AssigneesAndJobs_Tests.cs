using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;
using TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects;
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Status_Tests.PageObjects_Tests
{
    [TestClass]
    public class AssigneesAndJobs_Tests
    {

        /* Parsing Correct Tests */
        [TestMethod]
        public void AssigneesAndJobs_ParsingCorrectly_Test_1()
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

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                Assert.IsFalse(asob.AssigneesListIsEmpty);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                Assert.IsFalse(asob.AssigneesJobsListIsEmpty);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);

                Assert.AreNotEqual(0, asob.GetListOfAssigneeNames.Count);
                Assert.AreNotEqual(0, asob.GetListOfAssigneesJobNames.Count);
                Assert.AreNotEqual(0, asob.GetListOfJobsSourceLanguages.Count);
                Assert.AreNotEqual(0, asob.GetListOfJobsTargetLanguages.Count);

                Assert.IsTrue(asob.IsParsingCorrect);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_ParsingCorrectly_Test_2()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                Assert.IsFalse(asob.AssigneesListIsEmpty);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                Assert.IsFalse(asob.AssigneesJobsListIsEmpty);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);

                Assert.AreNotEqual(0, asob.GetListOfAssigneeNames.Count);
                Assert.AreNotEqual(0, asob.GetListOfAssigneesJobNames.Count);
                Assert.AreNotEqual(0, asob.GetListOfJobsSourceLanguages.Count);
                Assert.AreNotEqual(0, asob.GetListOfJobsTargetLanguages.Count);

                Assert.IsTrue(asob.IsParsingCorrect);
            }
        }

        /* Selecting Jobs Tests */
        [TestMethod]
        public void AssigneesAndJobs_SelectingJobs_Test_1()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                
                /* Set of assertions */

                asob.SelectSingleJob(driver, 1);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_SelectingJobs_Test_2()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                asob.SelectSingleJob(driver, asob.GetAssigneeJobsListSize - 1);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_SelectingJobs_Test_3()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                asob.SelectSingleJob(driver, 0);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        /* Tagging Jobs Tests */
        [TestMethod]
        public void AssigneesAndJobs_TaggingJobs_Test_1()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                string jobName = asob.GetListOfAssigneesJobNames.ElementAt(1);

                /* Set of assertions */

                asob.TagSingleJob(driver, 1);
                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach(string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.AreEqual(jobName, searchJobName);
                }
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_TaggingJobs_Test_2()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                string jobName = asob.GetListOfAssigneesJobNames.ElementAt(1);

                /* Set of assertions */

                asob.TagSingleJob(driver, asob.GetAssigneeJobsListSize - 1);

                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach (string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.AreEqual(jobName, searchJobName);
                }
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_TaggingJobs_Test_3()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                string jobName = asob.GetListOfAssigneesJobNames.ElementAt(1);

                /* Set of assertions */

                asob.SelectSingleJob(driver, 0);

                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach (string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.AreEqual(jobName, searchJobName);
                }
            }
        }

        /* Selecting Multiple Jobs Tests */
        [TestMethod]
        public void AssigneesAndJobs_SelectingMultipleJobs_Test_1()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                asob.SelectMultipleJobs(driver, 0, 10);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_SelectingMultipleJobs_Test_2()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                asob.SelectMultipleJobs(driver, 0, 1);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_SelectingMultipleJobs_Test_3()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                asob.SelectMultipleJobs(driver, 0, asob.GetAssigneeJobsListSize - 1);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_SelectingMultipleJobs_Test_4()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                asob.SelectMultipleJobs(driver, asob.GetAssigneeJobsListSize - 2, asob.GetAssigneeJobsListSize - 1);

                OnClickJobsMenu testMenu = new OnClickJobsMenu(driver);
                Assert.AreEqual(1, testMenu.MenuContainerIsDisplayed);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);
            }
        }

        /* Tagging Multiple Jobs Tests */
        [TestMethod]
        public void AssigneesAndJobs_TaggingMultipleJobs_Test_1()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                List<string> jobNames = asob.GetListOfAssigneesJobNames.GetRange(0, 10);

                /* Set of assertions */

                asob.TagMultipleJobs(driver, 0, 9);
                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach (string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.IsTrue(jobNames.Contains(searchJobName), "{0}", searchJobName);
                }
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_TaggingMultipleJobs_Test_2()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                List<string> jobNames = asob.GetListOfAssigneesJobNames.GetRange(0, 2);

                /* Set of assertions */

                asob.TagMultipleJobs(driver, 1, 4);
                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach (string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.IsTrue(jobNames.Contains(searchJobName), "{0}", searchJobName);
                }
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_TaggingMultipleJobs_Test_3()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                List<string> jobNames = asob.GetListOfAssigneesJobNames.GetRange(0, asob.GetAssigneeJobsListSize);

                /* Set of assertions */

                asob.TagMultipleJobs(driver, 0, asob.GetAssigneeJobsListSize - 1);
                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach (string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.IsTrue(jobNames.Contains(searchJobName), "{0}", searchJobName);
                }
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_TaggingMultipleJobs_Test_4()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                List<string> jobNames = asob.GetListOfAssigneesJobNames.GetRange(asob.GetAssigneeJobsListSize - 1, 1);

                /* Set of assertions */

                asob.TagMultipleJobs(driver, asob.GetAssigneeJobsListSize - 1, asob.GetAssigneeJobsListSize - 1);
                porscheAssigneesPage = new AssigneesPage(driver);
                asob = new AssigneesAndJobs(driver);

                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                foreach (string searchJobName in asob.GetListOfAssigneesJobNames)
                {
                    Assert.IsTrue(jobNames.Contains(searchJobName), "{0}", searchJobName);
                }
            }
        }
    }
}
