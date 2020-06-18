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

                PageBar porscheAssigneesPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(porscheAssigneesPageBar.IsParsedCorrectly);
                Assert.IsTrue(porscheAssigneesPageBar.IfPageBarExists);

                Assert.AreEqual(1, porscheAssigneesPageBar.IfFirstPage);
                Assert.AreEqual(0, porscheAssigneesPageBar.IfLastPage);

                Assert.AreEqual(1, porscheAssigneesPageBar.IfNextPageExists);
                Assert.AreEqual(0, porscheAssigneesPageBar.IfPreviousPageExists);


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

                PageBar porscheAssigneesPageBar = new PageBar(driver);

                Assert.IsTrue(porscheAssigneesPageBar.IsParsedCorrectly);
                Assert.IsTrue(porscheAssigneesPageBar.IfPageBarExists);

                Assert.AreEqual(1, porscheAssigneesPageBar.IfNextPageExists);
                porscheAssigneesPageBar.GoToNextPage(driver);

                PageBar secondPorscheAssigneesPageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(secondPorscheAssigneesPageBar.IsParsedCorrectly);
                Assert.IsTrue(secondPorscheAssigneesPageBar.IfPageBarExists);

                Assert.AreEqual(0, secondPorscheAssigneesPageBar.IfFirstPage);
                Assert.AreEqual(0, secondPorscheAssigneesPageBar.IfLastPage);
                

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

                PageBar porscheAssigneesPageBar = new PageBar(driver);

                Assert.IsTrue(porscheAssigneesPageBar.IsParsedCorrectly);
                Assert.IsTrue(porscheAssigneesPageBar.IfPageBarExists);

                Assert.AreEqual(1, porscheAssigneesPageBar.IfNextPageExists);
                porscheAssigneesPageBar.GoToNextPage(driver);

                PageBar secondPorscheAssigneesPageBar = new PageBar(driver);
                secondPorscheAssigneesPageBar.GoToPreviousPage(driver);

                PageBar thirdPorscheAssignePageBar = new PageBar(driver);

                /* Set of assertions */

                Assert.IsTrue(thirdPorscheAssignePageBar.IsParsedCorrectly);
                Assert.IsTrue(thirdPorscheAssignePageBar.IfPageBarExists);

                Assert.AreEqual(1, thirdPorscheAssignePageBar.IfFirstPage);
                Assert.AreEqual(0, thirdPorscheAssignePageBar.IfLastPage);

                Assert.AreEqual(1, thirdPorscheAssignePageBar.IfNextPageExists);
                Assert.AreEqual(0, thirdPorscheAssignePageBar.IfPreviousPageExists);


            }
        }

    }
}
