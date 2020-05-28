﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Starting_TMS_Tests
{
    [TestClass]
    public class ProjectsPage_Tests
    {


        [TestMethod]
        public void ProjectsPage_ParsingCorrectly_Test_1()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsTrue(testPage.IsParsedCorrectly);

            }
        }

        [TestMethod]
        public void ProjectsPage_ParsingCorrectly_Test_2()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsFalse(testPage.IsParsedCorrectly);

            }
        }

        [TestMethod]
        public void ProjectsPage_ProjectsList_Test_1()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsTrue(testPage.ProjectsList.Count > 0);

            }
        }

        [TestMethod]
        public void ProjectsPage_ProjectsList_Test_2()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsNull(testPage.ProjectsList);

            }
        }

        [TestMethod]
        public void ProjectsPage_ChoseProjects_Test_1()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsTrue(testPage.ChosenProject.Displayed);

            }
        }

        [TestMethod]
        public void ProjectsPage_ChoseProjects_Test_2()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsNull(testPage.ChosenProject);

            }
        }

    }

}
