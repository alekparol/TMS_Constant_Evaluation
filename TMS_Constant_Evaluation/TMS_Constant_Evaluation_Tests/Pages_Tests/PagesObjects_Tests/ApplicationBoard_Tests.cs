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
    public class ApplicationBoard_Tests
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
                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.IsFalse(applicationBoard.AppBoardPanelIsNull);
                Assert.AreEqual(1, applicationBoard.UserActivitiesListIsFull);
                Assert.IsTrue(applicationBoard.IsParsingCorrect);

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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.IsTrue(applicationBoard.AppBoardPanelIsNull);
                Assert.AreEqual(-1, applicationBoard.UserActivitiesListIsFull);
                Assert.IsFalse(applicationBoard.IsParsingCorrect);

            }

        }

        /* Logged User Tests */

        [TestMethod]
        public void ViewsMenu_LoggedUser_Test_1()
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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.AreEqual(0, applicationBoard.LoggedUserIsNull);
                Assert.AreEqual("Parol Aleksander", applicationBoard.GetUserName);

            }

        }

        [TestMethod]
        public void ViewsMenu_LoggedUser_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, applicationBoard.LoggedUserIsNull);
                Assert.AreEqual("", applicationBoard.GetUserName);

            }

        }

        /* User Activities List Tests */

        [TestMethod]
        public void ViewsMenu_UserActivitiesList_Test_1()
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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.AreEqual(0, applicationBoard.UserActivitiesMenuIsNull);
                Assert.AreEqual(0, applicationBoard.UserActivitiesIsClicked);
                Assert.AreEqual(1, applicationBoard.UserActivitiesListIsFull);

            }

        }

        [TestMethod]
        public void ViewsMenu_UserActivitiesList_Test_2()
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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);
                applicationBoard.LoggedUserClick(driver);

                /* Set of assertions */

                Assert.AreEqual(0, applicationBoard.UserActivitiesMenuIsNull);
                Assert.AreEqual(1, applicationBoard.UserActivitiesIsClicked);
                Assert.AreEqual(1, applicationBoard.UserActivitiesListIsFull);

            }

        }

        [TestMethod]
        public void ViewsMenu_UserActivitiesList_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, applicationBoard.UserActivitiesMenuIsNull);
                Assert.AreEqual(-1, applicationBoard.UserActivitiesIsClicked);
                Assert.AreEqual(-1, applicationBoard.UserActivitiesListIsFull);

            }

        }

        /* User Profile Tests */

        [TestMethod]
        public void ViewsMenu_UserProfile_Test_1()
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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.AreEqual(1 , applicationBoard.ProfileActivityIsNull);
                Assert.AreEqual(-1, applicationBoard.ProfileActivityIsDisplayed);
                Assert.AreEqual(0, applicationBoard.ProfileWindowIsNull);
                Assert.AreEqual(0, applicationBoard.ProfileWindowIsDisplayed);
                

            }

        }

        [TestMethod]
        public void ViewsMenu_UserProfile_Test_2()
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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);
                applicationBoard.LoggedUserClick(driver);

                /* Set of assertions */

                Assert.AreEqual(0, applicationBoard.ProfileActivityIsNull);
                Assert.AreEqual(1, applicationBoard.ProfileActivityIsDisplayed);
                Assert.AreEqual(0, applicationBoard.ProfileWindowIsNull);
                Assert.AreEqual(0, applicationBoard.ProfileWindowIsDisplayed);


            }

        }

        [TestMethod]
        public void ViewsMenu_UserProfile_Test_3()
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

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);
                applicationBoard.LoggedUserClick(driver);

                applicationBoard.ProfileClick(driver);

                /* Set of assertions */

                Assert.AreEqual(1, applicationBoard.ProfileActivityIsNull);
                Assert.AreEqual(-1, applicationBoard.ProfileActivityIsDisplayed);
                Assert.AreEqual(0, applicationBoard.ProfileWindowIsNull);
                Assert.AreEqual(1, applicationBoard.ProfileWindowIsDisplayed);


            }

        }

        [TestMethod]
        public void ViewsMenu_UserProfile_Test_4()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ApplicationBoard applicationBoard = new ApplicationBoard(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, applicationBoard.ProfileActivityIsNull);
                Assert.AreEqual(-1, applicationBoard.ProfileActivityIsDisplayed);
                Assert.AreEqual(-1, applicationBoard.ProfileWindowIsNull);
                Assert.AreEqual(-1, applicationBoard.ProfileWindowIsDisplayed);


            }

        }

    }
}
