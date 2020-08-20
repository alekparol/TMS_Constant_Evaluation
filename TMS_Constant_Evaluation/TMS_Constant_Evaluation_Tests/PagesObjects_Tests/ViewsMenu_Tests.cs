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
using TMS_Constant_Evaluation.Pages.PagesObjects;
using TMS_Constant_Evaluation.PagesObjects;
using TMS_Constant_Evaluation.PagesObjects.JobObject;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.PagesObjects_Tests
{
    [TestClass]
    public class ViewsMenu_Tests
    {

        /* Parsing Correctly Tests */
        [TestMethod]
        public void ViewsMenu_ParsingCorrectly_Test_1()
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

                ViewsMenu viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                Assert.IsFalse(viewsMenu.ViewsPanelIsNull);
                //Assert.AreEqual(1, viewsMenu.ViewsListIsFull);
                //Assert.IsTrue(viewsMenu.IsParsingCorrect);

            }

        }

        [TestMethod]
        public void ViewsMenu_ParsingCorrectly_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ViewsMenu viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                Assert.IsTrue(viewsMenu.ViewsPanelIsNull);
                //Assert.IsFalse(viewsMenu.IsParsingCorrect);

            }

        }

        /* Tests of ViewClicked Properties */

        [TestMethod]
        public void ViewsMenu_ViewClicked_Test_1()
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

                ViewsMenu viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                Assert.AreEqual(0, viewsMenu.JobsView.ButtonIsClicked);
                Assert.AreEqual(0, viewsMenu.PlanningView.ButtonIsClicked);
                Assert.AreEqual(0, viewsMenu.StatusView.ButtonIsClicked);

            }
        }

        [TestMethod]
        public void ViewsMenu_ViewClicked_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ViewsMenu viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, viewsMenu.JobsView.ButtonIsClicked);
                Assert.AreEqual(-1, viewsMenu.PlanningView.ButtonIsClicked);
                Assert.AreEqual(-1, viewsMenu.StatusView.ButtonIsClicked);

            }

        }

        /* Tests of ViewClick Methods */

        [TestMethod]
        public void ViewsMenu_ViewClick_Test_1()
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

                ViewsMenu viewsMenu = new ViewsMenu(driver);
                viewsMenu.JobsView.ButtonClick();

                viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                //Assert.IsTrue(viewsMenu.IsParsingCorrect);
               // Assert.AreEqual(1, viewsMenu.ViewsListIsFull);
                Assert.AreEqual(1, viewsMenu.JobsView.ButtonIsClicked);

            }
        }

        [TestMethod]
        public void ViewsMenu_ViewClick_Test_2()
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

                ViewsMenu viewsMenu = new ViewsMenu(driver);
                viewsMenu.PlanningView.ButtonClick();

                viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                //Assert.IsTrue(viewsMenu.IsParsingCorrect);
                //Assert.AreEqual(1, viewsMenu.ViewsListIsFull);
                Assert.AreEqual(1, viewsMenu.PlanningView.ButtonIsClicked);

            }
        }

        [TestMethod]
        public void ViewsMenu_ViewClick_Test_3()
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

                ViewsMenu viewsMenu = new ViewsMenu(driver);
                viewsMenu.StatusView.ButtonClick();

                viewsMenu = new ViewsMenu(driver);

                /* Set of assertions */

                //Assert.IsTrue(viewsMenu.IsParsingCorrect);
                //Assert.AreEqual(1, viewsMenu.ViewsListIsFull);
                Assert.AreEqual(1, viewsMenu.StatusView.ButtonIsClicked);

            }
        }

    }
}
