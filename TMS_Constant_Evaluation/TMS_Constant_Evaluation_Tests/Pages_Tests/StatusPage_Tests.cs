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

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Status_Tests
{
    [TestClass]
    public class StatusPage_Tests
    {
        /* Parsing Correct Tests */

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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("", testStatusPage.LanguagesFilterSelection);
            }
        }

        [TestMethod]
        public void StatusPage_ParsingCorrectly_Test_2()
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

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("", testStatusPage.LanguagesFilterSelection);
            }
        }
        
        [TestMethod]
        public void StatusPage_ParsingCorrectly_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                StatusPage testStatusPage = new StatusPage(driver);

                /* Set of assertions */

                Assert.IsFalse(testStatusPage.IsParsingCorrect);
            }
        }

        /* Activities Click Tests */

        [TestMethod]
        public void StatusPage_ActivitiesClick_Test_1()
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

                testStatusPage.ActivitiesClick(driver);
                testStatusPage = new StatusPage(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("", testStatusPage.LanguagesFilterSelection);
            }
        }

        [TestMethod]
        public void StatusPage_ActivitiesClick_Test_2()
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
                testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesClick(driver);
                testStatusPage = new StatusPage(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("", testStatusPage.LanguagesFilterSelection);
            }
        }

        /* Assignees Click Tests */

        [TestMethod]
        public void StatusPage_AssigneesClick_Test_1()
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
                testStatusPage = new StatusPage(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(0, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(1, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("", testStatusPage.LanguagesFilterSelection);
            }
        }

        [TestMethod]
        public void StatusPage_AssigneesClick_Test_2()
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
                testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesClick(driver);
                testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                testStatusPage = new StatusPage(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(0, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(1, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("", testStatusPage.LanguagesFilterSelection);
            }
        }

        /* Activities Filter Click */

        [TestMethod]
        public void StatusPage_ActivitiesFilterClick_Test_1()
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

                testStatusPage.ActivitiesFilterClick(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("Activity", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("Target Language", testStatusPage.LanguagesFilterSelection);

                Assert.AreEqual(1, testStatusPage.ActivitiesFilterIsExpanded);
                Assert.AreEqual(0, testStatusPage.LanguagesFilterIsExpanded);
            }
        }

        /* Chosen Activity Click */

        [TestMethod]
        public void StatusPage_ChosenActivityClick_Test_1()
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

                testStatusPage.ChosenActivityClick(driver, "Buffer_For_FreewayReview_H");
                testStatusPage.ActivitiesFilterClick(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("Buffer_For_FreewayReview_H", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("Target Language", testStatusPage.LanguagesFilterSelection);

                Assert.AreEqual(1, testStatusPage.ActivitiesFilterIsExpanded);
                Assert.AreEqual(0, testStatusPage.LanguagesFilterIsExpanded);
            }
        }

        [TestMethod]
        public void StatusPage_ChosenActivityClick_Test_2()
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

                testStatusPage.ChosenActivityClick(driver, "DTP_Post_Final_H");
                testStatusPage.ActivitiesFilterClick(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("DTP_Post_Final_H", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("Target Language", testStatusPage.LanguagesFilterSelection);

                Assert.AreEqual(1, testStatusPage.ActivitiesFilterIsExpanded);
                Assert.AreEqual(0, testStatusPage.LanguagesFilterIsExpanded);
            }
        }

        /* Language Filter Click */

        [TestMethod]
        public void StatusPage_LanguageFilterClick_Test_1()
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

                testStatusPage.LanguageFilterClick(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("Activity", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("Target Language", testStatusPage.LanguagesFilterSelection);

                Assert.AreEqual(0, testStatusPage.ActivitiesFilterIsExpanded);
                Assert.AreEqual(1, testStatusPage.LanguagesFilterIsExpanded);
            }
        }

        /* Chosen Language Click */

        [TestMethod]
        public void StatusPage_ChosenLanguageClick_Test_1()
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

                testStatusPage.ChosenGetTargetLanguageClick(driver, "da-dk");
                testStatusPage.LanguageFilterClick(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("Activity", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("da-dk", testStatusPage.LanguagesFilterSelection);

                Assert.AreEqual(0, testStatusPage.ActivitiesFilterIsExpanded);
                Assert.AreEqual(1, testStatusPage.LanguagesFilterIsExpanded);
            }
        }

        [TestMethod]
        public void StatusPage_ChosenLanguageClick_Test_2()
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

                testStatusPage.ChosenGetTargetLanguageClick(driver, "de-de");
                testStatusPage.LanguageFilterClick(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual("Activity", testStatusPage.ActivitiesFilterSelection);
                Assert.AreEqual("de-de", testStatusPage.LanguagesFilterSelection);

                Assert.AreEqual(0, testStatusPage.ActivitiesFilterIsExpanded);
                Assert.AreEqual(1, testStatusPage.LanguagesFilterIsExpanded);
            }
        }

        /* Click All Tests */

        [TestMethod]
        public void StatusPage_ClickAll_Test_1()
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

                testStatusPage.ClickAll(driver);

                /* Set of assertions */

                Assert.IsTrue(testStatusPage.IsParsingCorrect);
                Assert.AreEqual("status", testStatusPage.GetPageName);

                Assert.AreEqual(1, testStatusPage.IsActivitiesSelected);
                Assert.AreEqual(0, testStatusPage.IsAssigneesSelected);

                Assert.AreEqual(1, testStatusPage.AllButtonIsClicked);
            }
        }

    }
}
