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
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.PagesObjects_Tests
{
    [TestClass]
    public class PageBar_Tests
    {

        [TestMethod]
        public void PageBar_ParsingCorrectly_Test_0()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsFalse(testPageBar.PageBarContainerIsNull);
                Assert.AreEqual(1, testPageBar.PageBarContainerIsDisplayed);

                Assert.AreEqual(0, testPageBar.NumberOfAllItemsIsNull);
                Assert.AreEqual(1, testPageBar.NumberOfAllItemsIsDisplayed);

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.GetNumberOfAllItems);

                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.NextPageIsNull);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);


            }
        }

        [TestMethod]
        public void PageBar_ParsingCorrectly_Test_01()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.ItemsPerPageClick(driver);

                /* Set of assertions */

                Assert.IsFalse(testPageBar.PageBarContainerIsNull);
                Assert.AreEqual(1, testPageBar.PageBarContainerIsDisplayed);

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.NextPageIsNull);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);


            }
        }

        [TestMethod]
        public void PageBar_ParsingCorrectly_Test_1()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                PageBar testPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(1, testPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, testPageBar.CurrentPageIsLast);

                Assert.AreEqual(1, testPageBar.NextPageIsNull);
                Assert.AreEqual(0, testPageBar.PreviousPageIsNull);


            }
        }

        [TestMethod]
        public void PageBar_GoToNextPage_Test_1()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                PageBar testPageBar = new PageBar(driver);

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(1, testPageBar.NextPageIsNull);
                testPageBar.GoToNextPage(driver);

                PageBar secondPorscheAssigneesPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(secondPorscheAssigneesPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(0, secondPorscheAssigneesPageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, secondPorscheAssigneesPageBar.CurrentPageIsLast);
                

            }
        }

        [TestMethod]
        public void PageBar_GoToPreviousPage_Test_1()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                PageBar testPageBar = new PageBar(driver);

                Assert.IsTrue(testPageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);


                Assert.AreEqual(1, testPageBar.NextPageIsNull);
                testPageBar.GoToNextPage(driver);

                PageBar secondPorscheAssigneesPageBar = new PageBar(driver);
                secondPorscheAssigneesPageBar.GoToPreviousPage(driver);

                PageBar thirdPorscheAssignePageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(thirdPorscheAssignePageBar.IsParsingCorrect);
                Assert.AreEqual(0, testPageBar.PageNavigationContainerIsNull);

                Assert.AreEqual(1, thirdPorscheAssignePageBar.CurrentPageIsFirst);
                Assert.AreEqual(0, thirdPorscheAssignePageBar.CurrentPageIsLast);

                Assert.AreEqual(1, thirdPorscheAssignePageBar.NextPageIsNull);
                Assert.AreEqual(0, thirdPorscheAssignePageBar.PreviousPageIsNull);


            }
        }

    }
}
