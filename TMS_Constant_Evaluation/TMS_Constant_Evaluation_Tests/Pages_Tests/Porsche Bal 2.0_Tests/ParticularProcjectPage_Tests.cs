using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Porsche_Bal_2._0_Tests
{
    [TestClass]
    public class ParticularProcjectPage_Tests
    {


        [TestMethod]
        public void ParticularProjectPage_ParsingCorrectly_Test_1()
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

                /* Set of assertions */

                Assert.IsTrue(porscheBalPage.IsParsedCorrectly);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_ParsingCorrectly_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.IsFalse(porscheBalPage.IsParsedCorrectly);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_SelectedProject_Test_1()
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

                /* Set of assertions */

                Assert.AreEqual(projectTitle.ToLower().Trim(), porscheBalPage.SelectedProjectName);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_SectionsContent_Test_1()
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

                /* Set of assertions */

                Assert.AreEqual("Jobs", porscheBalPage.JobsSection.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text);
                Assert.AreEqual("Planning", porscheBalPage.PlanningSection.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text);
                Assert.AreEqual("Status", porscheBalPage.StatusSection.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text);

            }

        }

    }
}
