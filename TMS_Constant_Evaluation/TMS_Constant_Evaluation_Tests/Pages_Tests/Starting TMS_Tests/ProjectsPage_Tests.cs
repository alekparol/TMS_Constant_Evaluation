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

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Starting_TMS_Tests
{
    [TestClass]
    public class ProjectsPage_Tests
    {

        /* Constructors tests */

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
                Assert.IsFalse(testPage.ChosenProjectIsNull);

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
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "CORTEVA";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsTrue(testPage.IsParsedCorrectly);
                Assert.IsFalse(testPage.ChosenProjectIsNull);

            }
        }

        [TestMethod]
        public void ProjectsPage_ParsingCorrectly_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Corteva";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                /* Set of assertions */

                Assert.IsTrue(testPage.IsParsedCorrectly);
                Assert.IsFalse(testPage.ChosenProjectIsNull);

            }
        }

        [TestMethod]
        public void ProjectsPage_ParsingCorrectly_Test_4()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                ProjectsPage testPage = new ProjectsPage(driver);

                /* Set of assertions */

                Assert.IsTrue(testPage.IsParsedCorrectly);

            }
        }

        [TestMethod]
        public void ProjectsPage_ParsingCorrectly_Test_5()
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
                Assert.IsTrue(testPage.ChosenProjectIsNull);

            }
        }

        [TestMethod]
        public void ProjectsPage_ParsingCorrectly_Test_6()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ProjectsPage testPage = new ProjectsPage(driver);

                /* Set of assertions */

                Assert.IsFalse(testPage.IsParsedCorrectly);

            }
        }

        /* Project List Tests */

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

                Assert.IsFalse(testPage.ProjectListIsNull);
                Assert.IsTrue(testPage.ProjectListCount > 0);

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

                Assert.IsTrue(testPage.ProjectListIsNull);
                Assert.AreEqual(-1, testPage.ProjectListCount);

            }
        }

        /* Chosen Project Tests */

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

                Assert.IsFalse(testPage.ChosenProjectIsNull);
                Assert.AreEqual("PORSCHE BAL 2.0", testPage.ChosenProjectName);
                Assert.AreEqual(1, testPage.ChosenProjectIsDisplayed);

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

                Assert.IsTrue(testPage.ChosenProjectIsNull);
                Assert.AreEqual("", testPage.ChosenProjectName);
                Assert.AreEqual(-1, testPage.ChosenProjectIsDisplayed);

            }
        }

    }

}
