﻿using System;
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                /* Set of assertions */

                Assert.IsFalse(asob.AssigneesListIsEmpty);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

                Assert.IsFalse(asob.AssigneesJobsListIsEmpty);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);

                //Assert.AreNotEqual(0, asob.GetListOfAssigneeNames.Count);
                //Assert.AreNotEqual(0, asob.GetListOfJobsSourceLanguages.Count);
                //Assert.AreNotEqual(0, asob.GetListOfJobsTargetLanguages.Count);
            }
        }

        [TestMethod]
        public void AssigneesAndJobs_ParsingCorrectly_Test_3()
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

                List<Assignee> assigneesList = new List<Assignee>();
                List<AssigneeJobs> assigneesJobsList = new List<AssigneeJobs>();

                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                Assignee auxiliaryAssignee;
                AssigneeJobs auxiliaryAssigneeJobs;

                auxiliaryCollection = driver.FindElements(By.ClassName("r_LH"));
                if (auxiliaryCollection.Count > 0)
                {
                    foreach (IWebElement element in auxiliaryCollection)
                    {
                        auxiliaryAssignee = new Assignee(element);
                        if (auxiliaryAssignee.IsParsingCorrect) assigneesList.Add(auxiliaryAssignee);
                    }
                }

                auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));
                if (auxiliaryCollection.Count > 0)
                {
                    foreach (IWebElement element in auxiliaryCollection)
                    {
                        auxiliaryAssigneeJobs = new AssigneeJobs(element);
                        if (auxiliaryAssigneeJobs.IsParsingCorrect) assigneesJobsList.Add(auxiliaryAssigneeJobs);
                    }
                }

                /* Set of assertions */

                Assert.AreEqual(0, assigneesJobsList.Count);
                Assert.AreEqual(0, assigneesList.Count);
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
                Assert.AreNotEqual(0, asob.GetListOfJobsSourceLanguages.Count);
                Assert.AreNotEqual(0, asob.GetListOfJobsTargetLanguages.Count);

            }
        }

        /* Taggin Jobs Tests */
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
                asob.TagSingleJob(driver, 1);

                /* Set of assertions */
                Assert.AreEqual(true, asob.IsParsingCorrect);
                Assert.AreNotEqual(0, asob.GetAssigneeJobsListSize);
                Assert.AreNotEqual(0, asob.GetAssigneesListSize);

            }
        }

    }
}
