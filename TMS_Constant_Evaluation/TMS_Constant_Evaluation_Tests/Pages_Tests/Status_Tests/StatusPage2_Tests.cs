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

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Status_Tests
{
    [TestClass]
    public class StatusPage2_Tests
    {

        [TestMethod]
        public void StatusPage_ParsingCorrectly_Test_1()
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

                /* Set of assertions */

                Assert.IsTrue(porscheStatusPage.IsParsedCorrectly);

            }

        }

        [TestMethod]
        public void StatusPage_PageName_Test_1()
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

                string pageName = "status";

                /* Set of assertions */

                Assert.AreEqual(pageName.ToLower().Trim(), porscheStatusPage.PageName);

            }

        }

        [TestMethod]
        public void StatusPage_SectionSelected_Test_1()
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

                /* Set of assertions */

                Assert.AreEqual(1, porscheStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, porscheStatusPage.IsAssigneesSelected);

            }

        }

        [TestMethod]
        public void StatusPage_AssigneeClick_Test_1()
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
                IReadOnlyCollection<IWebElement> assigneesSelected = driver.FindElements(By.Id("statusassignees"));

                /* Set of assertions */

                Assert.IsTrue(assigneesSelected.Count > 0);
                Assert.IsTrue(assigneesSelected.ElementAt(0).GetAttribute("class").Contains("hdr_sub_sel"));

            }

        }

    }
}