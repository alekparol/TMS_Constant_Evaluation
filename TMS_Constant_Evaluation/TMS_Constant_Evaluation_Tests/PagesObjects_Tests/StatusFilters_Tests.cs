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
    public class StatusFilters_Tests
    {

        /* Parsing Correct Tests */

        [TestMethod]
        public void StatusFilters_ParsingCorrectly_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
            }
        }

        [TestMethod]
        public void StatusFilters_ParsingCorrectly_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Qlik";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_ParsingCorrectly_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche Bal 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_ParsingCorrectly_Test_4()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                StatusFilters statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsTrue(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsTrue(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(-1, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Filters Button Click Tests */

        [TestMethod]
        public void StatusFilters_FiltersButtonClick_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersButtonClick(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsTrue(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(-1, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_FiltersButtonClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                StatusFilters statusFiltersTest = new StatusFilters(driver);
                statusFiltersTest.FiltersButtonClick(driver);

                /* Set of assertions */

                Assert.IsTrue(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsTrue(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(-1, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Display Filters Panel Tests */

        [TestMethod]
        public void StatusFilters_DisplayFiltersPanel_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.DisplayFiltersPanel(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_DisplayFiltersPanel_Test_2()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersButtonClick(driver);
                statusFiltersTest.DisplayFiltersPanel(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Filters Panel Initialization Tests */

        [TestMethod]
        public void StatusFilters_FiltersPanelInitialization_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("Target Language", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Activity", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_FiltersPanelInitialization_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Qlik";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("Target Language", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Activity", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_FiltersPanelInitialization_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche Bal 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("Target Language", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Activity", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Language Filter Click */

        [TestMethod]
        public void StatusFilters_LanguageFilterClick_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);
                statusFiltersTest.LanguageFilterClick(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("Target Language", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Activity", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Chosen Target Language Click */

        [TestMethod]
        public void StatusFilters_ChosenTargetLanguageClick_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);
                statusFiltersTest.ChosenTargetLanguageClick(driver, "ar-xm");

                statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_ChosenTargetLanguageClick_Test_2()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);
                statusFiltersTest.ChosenTargetLanguageClick(driver, "ar-xm");

                statusFiltersTest = new StatusFilters(driver);
                statusFiltersTest.FiltersPanelInitialization(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("ar-xm", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Activity", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Activity Filter Click */

        [TestMethod]
        public void StatusFilters_ActivitiesFilterClick_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);
                statusFiltersTest.ActivitiesFilterClick(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("Target Language", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Activity", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Chosen Activity Click Tests */

        [TestMethod]
        public void StatusFilters_ChosenActivityClick_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);
                statusFiltersTest.ChosenActivityClick(driver, "Buffer_For_FreewayReview_H");

                statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(-1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(-1, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        [TestMethod]
        public void StatusFilters_ChosenActivityClick_Test_2()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);

                statusFiltersTest.FiltersPanelInitialization(driver);
                statusFiltersTest.ChosenActivityClick(driver, "Buffer_For_FreewayReview_H");

                statusFiltersTest = new StatusFilters(driver);
                statusFiltersTest.FiltersPanelInitialization(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsClicked);

                Assert.AreEqual(0, statusFiltersTest.FiltersPanelIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersPanelIsDisplayed);

                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.LanguageFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.LanguageFilterIsExpanded);
                Assert.AreEqual("Target Language", statusFiltersTest.LanguageFilterSelection);

                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsNull);
                Assert.AreEqual(1, statusFiltersTest.ActivitiesFilterIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.ActivitiesFilterIsExpanded);
                Assert.AreEqual("Buffer_For_FreewayReview_H", statusFiltersTest.ActivitiesFilterSelection);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(0, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

        /* Show All Button Tests */

        [TestMethod]
        public void StatusFilters_ShowAllButtonClick_Test_1()
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
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusFilters statusFiltersTest = new StatusFilters(driver);
                statusFiltersTest.ClickAll(driver);

                statusFiltersTest = new StatusFilters(driver);

                /* Set of assertions */

                Assert.IsFalse(statusFiltersTest.FiltersButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.FiltersButtonIsDisplayed);
                Assert.AreEqual(0, statusFiltersTest.FiltersButtonIsClicked);

                Assert.IsFalse(statusFiltersTest.ShowAllButtonIsNull);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsEnabled);
                Assert.AreEqual(1, statusFiltersTest.ShowAllButtonIsClicked);
            }
        }

    }
}
