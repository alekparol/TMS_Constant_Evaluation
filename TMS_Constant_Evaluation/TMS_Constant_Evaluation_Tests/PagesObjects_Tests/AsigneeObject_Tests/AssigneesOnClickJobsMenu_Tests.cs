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
using TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects;
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;

namespace TMS_Constant_Evaluation_Tests.PagesObjects_Tests
{
    [TestClass]
    public class AssingeesOnClickJobsMenu_Tests
    {

        [TestMethod]
        public void AssingeesOnClickJobsMenu_ParsingCorrectly_Test_1()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = ""; // Project Name
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
                AssingeesOnClickJobsMenu testJobMenu = new AssingeesOnClickJobsMenu(driver);

                /* Set of assertions */

                Assert.IsFalse(testJobMenu.MenuContainerIsNull);
                Assert.AreEqual(1, testJobMenu.MenuContainerIsDisplayed);
                Assert.AreEqual(0, testJobMenu.TagJobButtonIsNull);
                Assert.AreEqual(1, testJobMenu.TagJobButtonIsEnabled);

            }
        }
    }
}
