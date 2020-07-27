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
    public class TabMenu_Tests
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

                TabMenu tabMenu = new TabMenu(driver);

                /* Set of assertions */

                Assert.AreEqual(false, tabMenu.TabMenuPanelIsNull);
                Assert.AreEqual(0, tabMenu.TabMenuOptionsIsNull);
                Assert.AreEqual(4, tabMenu.TabMenuOptionListCount);
                Assert.AreEqual(1, tabMenu.OpenedProjectsListCount);
                Assert.IsTrue(tabMenu.IsParsingCorrect);

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

                TabMenu tabMenu = new TabMenu(driver);

                /* Set of assertions */

                Assert.AreEqual(true, tabMenu.TabMenuPanelIsNull);
                Assert.AreEqual(-1, tabMenu.TabMenuOptionsIsNull);
                Assert.AreEqual(0, tabMenu.TabMenuOptionListCount);
                Assert.AreEqual(0, tabMenu.OpenedProjectsListCount);
                Assert.IsFalse(tabMenu.IsParsingCorrect);

            }

        }

        /* Current Project Tests */
        [TestMethod]
        public void ViewsMenu_CurrentProject_Test_1()
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

                TabMenu tabMenu = new TabMenu(driver);

                /* Set of assertions */

                Assert.IsFalse(tabMenu.CurrentProjectIsNull);
                Assert.AreEqual("porsche bal 2.0", tabMenu.CurrentProjectName);

            }

        }

        [TestMethod]
        public void ViewsMenu_CurrentProject_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                TabMenu tabMenu = new TabMenu(driver);

                /* Set of assertions */

                Assert.IsTrue(tabMenu.CurrentProjectIsNull);
                Assert.AreEqual("", tabMenu.CurrentProjectName);

            }

        }

    }
}
