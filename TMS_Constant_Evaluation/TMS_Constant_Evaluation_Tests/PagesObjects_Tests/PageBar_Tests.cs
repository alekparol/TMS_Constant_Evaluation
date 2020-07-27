using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.PagesObjects_Tests
{
    [TestClass]
    public class PageBar_Tests
    {

        /* Parsing Corretly Tests */

        [TestMethod]
        public void PageBar_ParsingCorrectly_Test_1()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testPageBar.PageBarContainerIsNull);
                Assert.AreEqual(1, testPageBar.PageBarContainerIsDisplayed);

                Assert.AreEqual(0, testPageBar.NumberOfAllItemsIsNull);
                Assert.AreEqual(1, testPageBar.NumberOfAllItemsIsDisplayed);

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.IsTrue(testPageBar.GetNumberOfAllItems > 0);

                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);

                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);
                Assert.AreNotEqual(0, testPageBar.GetLastPageNumber);

                Assert.AreEqual(0, testPageBar.NextPageIsNull);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
            }
        }

        [TestMethod]
        public void PageBar_ParsingCorrectly_Test_2()
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
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesFilterClick(driver);
                testStatusPage.ChosenActivityClick("Buffer_for_FreewayReview_H", driver);
                
                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testPageBar.PageBarContainerIsNull);
                Assert.AreEqual(1, testPageBar.PageBarContainerIsDisplayed);

                Assert.AreEqual(0, testPageBar.NumberOfAllItemsIsNull);
                Assert.AreEqual(1, testPageBar.NumberOfAllItemsIsDisplayed);

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.IsTrue(testPageBar.GetNumberOfAllItems > 0);

                Assert.AreEqual(1, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(-1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(-1, testPageBar.GetCurrentPageNumber);

                Assert.AreEqual(-1, testPageBar.CurrentPageIsLast);
                Assert.AreEqual(-1, testPageBar.GetLastPageNumber);

                Assert.AreEqual(-1, testPageBar.NextPageIsNull);
                Assert.AreEqual(-1, testPageBar.PreviousPageIsNull);
            }
        }

        [TestMethod]
        public void PageBar_ParsingCorrectly_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.PageBarContainerIsNull);
                Assert.AreEqual(-1, testPageBar.PageBarContainerIsDisplayed);

                Assert.AreEqual(-1, testPageBar.NumberOfAllItemsIsNull);
                Assert.AreEqual(-1, testPageBar.NumberOfAllItemsIsDisplayed);

                Assert.IsFalse(testPageBar.IsParsingCorrect);
                Assert.IsFalse(testPageBar.GetNumberOfAllItems > 0);

                Assert.AreEqual(-1, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(-1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(-1, testPageBar.GetCurrentPageNumber);

                Assert.AreEqual(-1, testPageBar.CurrentPageIsLast);
                Assert.AreEqual(-1, testPageBar.GetLastPageNumber);

                Assert.AreEqual(-1, testPageBar.NextPageIsNull);
                Assert.AreEqual(-1, testPageBar.PreviousPageIsNull);
            }
        }

        /* ItemsPerPageClick Tests */

        [TestMethod]
        public void PageBar_ItemsPerPageClick_Test_1()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                testPageBar.ItemsPerPageClick(driver);
                Assert.AreEqual(1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageClick_Test_2()
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
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesFilterClick(driver);
                testStatusPage.ChosenActivityClick("Buffer_for_FreewayReview_H", driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                testPageBar.ItemsPerPageClick(driver);
                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageClick_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testPageBar.IsParsingCorrect);
                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                testPageBar.ItemsPerPageClick(driver);
                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

            }
        }

        /* ItemsPerPageSetChosenValue Tests */

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_1()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "100");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("100", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_2()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "25");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("25", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_3()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "50");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("50", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_4()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "100");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("100", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_5()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "500");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("500", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_6()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "1000");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("1000", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_7()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesFilterClick(driver);
                testStatusPage.ChosenActivityClick("Buffer_for_FreewayReview_H", driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("-1", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "25");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("-1", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetChosenValue_Test_8()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testPageBar.IsParsingCorrect);
                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("-1", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetChosenValue(driver, "25");

                testPageBar = new PageBar(driver);

                Assert.AreEqual(-1, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("-1", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        /* ItemsPerPageSetMaximalValue and MinimalValue Tests */

        [TestMethod]
        public void PageBar_ItemsPerPageSetMaxMinValue_Test_1()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetMaximalValue(driver);

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("1000", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        [TestMethod]
        public void PageBar_ItemsPerPageSetMaxMinValue_Test_2()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);

                Assert.AreEqual("250", testPageBar.ItemsPerPageCurrentSelection);
                testPageBar.ItemsPerPageSetMinimalValue(driver);

                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.ItemsPerPageOptionsContainerIsDisplayed);
                Assert.AreEqual("25", testPageBar.ItemsPerPageCurrentSelection);

            }
        }

        /* GoToLastPage Tests */

        [TestMethod]
        public void PageBar_GoToLastPage_Test_1()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(0, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);
            }
        }

        [TestMethod]
        public void PageBar_GoToLastPage_Test_2()
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
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesFilterClick(driver);
                testStatusPage.ChosenActivityClick("Buffer_for_FreewayReview_H", driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(-1, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(-1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(-1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(-1, testPageBar.NextPageIsNull);
            }
        }

        [TestMethod]
        public void PageBar_GoToLastPage_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);
                /* Set of assertions */

                Assert.AreEqual(-1, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(-1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(-1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(-1, testPageBar.NextPageIsNull);
            }
        }

        /* GoToNextPage Tests */

        [TestMethod]
        public void PageBar_GoToNextPage_Test_1()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

            }
        }

        [TestMethod]
        public void PageBar_GoToNextPage_Test_2()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

                testPageBar.GoToNextPage(driver);
                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(0, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(2, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

            }
        }

        [TestMethod]
        public void PageBar_GoToNextPage_Test_3()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

                while(testPageBar.CurrentPageIsLast == 0)
                {
                    testPageBar.GoToNextPage(driver);
                    testPageBar = new PageBar(driver);
                }

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(0, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);

            }
        }

        [TestMethod]
        public void PageBar_GoToNextPage_Test_4()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

                testPageBar.GoToLastPage(driver);
                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(0, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);

                testPageBar.GoToNextPage(driver);
                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(0, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);

            }
        }

        /* GoToFirstPage Tests */

        [TestMethod]
        public void PageBar_GoToFirstPage_Test_1()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                testPageBar.GoToFirstPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);
            }
        }

        [TestMethod]
        public void PageBar_GoToFirstPage_Test_2()
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
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.ActivitiesFilterClick(driver);
                testStatusPage.ChosenActivityClick("Buffer_for_FreewayReview_H", driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                testPageBar.GoToFirstPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(-1, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(-1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(-1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(-1, testPageBar.NextPageIsNull);
            }
        }

        [TestMethod]
        public void PageBar_GoToFirstPage_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToFirstPage(driver);
                /* Set of assertions */

                Assert.AreEqual(-1, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(-1, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(-1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(-1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(-1, testPageBar.NextPageIsNull);
            }
        }

        /* GoToPreviousPage Tests */

        [TestMethod]
        public void PageBar_GoToPreviousPage_Test_1()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

                testPageBar.GoToPreviousPage(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

            }
        }

        [TestMethod]
        public void PageBar_GoToPreviousPage_Test_2()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);

                testPageBar.GoToPreviousPage(driver);
                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(0, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(testPageBar.GetLastPageNumber - 1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

            }
        }

        [TestMethod]
        public void PageBar_GoToPreviousPage_Test_3()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver); 
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);

                while (testPageBar.CurrentPageIsFirst == 0)
                {
                    testPageBar.GoToPreviousPage(driver);
                    testPageBar = new PageBar(driver);
                }

                //Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                //Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                //Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                //Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                //Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                //Assert.AreEqual(0, testPageBar.NextPageIsNull);

            }
        }

        [TestMethod]
        public void PageBar_GoToPreviousPage_Test_4()
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
                StatusPage testStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.GoToLastPage(driver);

                testPageBar = new PageBar(driver);
                /* Set of assertions */

                Assert.AreEqual(testPageBar.GetLastPageNumber, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(1, testPageBar.NextPageIsNull);

                testPageBar.GoToFirstPage(driver);
                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

                testPageBar.GoToPreviousPage(driver);
                testPageBar = new PageBar(driver);

                Assert.AreEqual(0, testPageBar.CurrentPageIsNull);
                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.GetCurrentPageNumber);
                Assert.AreEqual(1, testPageBar.PreviousPageIsNull);
                Assert.AreEqual(0, testPageBar.NextPageIsNull);

            }
        }

    }
}
