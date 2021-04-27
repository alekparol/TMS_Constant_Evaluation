using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.PagesObjects_Tests
{
    [TestClass]
    public class StatusNavigationBar_Tests
    {

        /* Parsing Correct Tests */

        [TestMethod]
        public void StatusNavigationBat_ParsingCorrectly_Test_1()
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

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPageMin(driver);

                testProjectPage.StatusClick(driver);
                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("status", testNavigationBar.GetPageName);

                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        [TestMethod]
        public void StatusNavigationBat_ParsingCorrectly_Test_2()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("projects", testNavigationBar.GetPageName);

                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        [TestMethod]
        public void StatusNavigationBat_ParsingCorrectly_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(-1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("", testNavigationBar.GetPageName);

                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        /* Activities Button Click */

        [TestMethod]
        public void StatusNavigationBat_ActivitiesButton_Test_1()
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

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPageMin(driver);

                testProjectPage.StatusClick(driver);
                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.ActivitiesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("status", testNavigationBar.GetPageName);

                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        [TestMethod]
        public void StatusNavigationBat_ActivitiesButton_Test_2()
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

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPageMin(driver);

                testProjectPage.StatusClick(driver);
                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.AssigneesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.ActivitiesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("status", testNavigationBar.GetPageName);

                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        [TestMethod]
        public void StatusNavigationBat_ActivitiesButton_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.ActivitiesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(-1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("", testNavigationBar.GetPageName);

                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        /* Assignees Button Click */

        [TestMethod]
        public void StatusNavigationBat_AssigneesButton_Test_1()
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

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPageMin(driver);

                testProjectPage.StatusClick(driver);
                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.AssigneesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("status", testNavigationBar.GetPageName);

                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        [TestMethod]
        public void StatusNavigationBat_AssigneesButton_Test_2()
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

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPageMin(driver);

                testProjectPage.StatusClick(driver);
                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.AssigneesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.AssigneesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("status", testNavigationBar.GetPageName);

                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(0, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(0, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(1, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }

        [TestMethod]
        public void StatusNavigationBat_AssigneesButton_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                StatusNavigationBar testNavigationBar = new StatusNavigationBar(driver);

                testNavigationBar.AssigneesClick(driver);
                testNavigationBar = new StatusNavigationBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testNavigationBar.NavigationPanelIsNull);
                Assert.AreEqual(-1, testNavigationBar.NavigationPanelIsDisplayed);
                Assert.AreEqual("", testNavigationBar.GetPageName);

                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.ActivitiesSubpageIsClicked);

                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsNull);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsDisplayed);
                Assert.AreEqual(-1, testNavigationBar.AssigneesSubpageIsClicked);
            }
        }
    }
}
