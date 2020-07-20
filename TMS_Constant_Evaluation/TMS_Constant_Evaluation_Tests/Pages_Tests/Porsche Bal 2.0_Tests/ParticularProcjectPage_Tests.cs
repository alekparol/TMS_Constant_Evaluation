using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Porsche_Bal_2._0_Tests
{
    [TestClass]
    public class ParticularProcjectPage_Tests
    {

        /* Parsing Correct Tests */

        [TestMethod]
        public void ParticularProjectPage_ParsingCorrectly_Test_1()
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

                /* Set of assertions */

                Assert.AreEqual(projectTitle.ToLower().Trim(), porscheBalPage.SelectedProjectName);
                Assert.IsTrue(porscheBalPage.IsParsingCorrect);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_ParsingCorrectly_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.IsFalse(porscheBalPage.IsParsingCorrect);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_ParsingCorrectly_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.IsFalse(porscheBalPage.IsParsingCorrect);

            }

        }

        /* Logged User Click */

        [TestMethod]
        public void ParticularProjectPage_LoggedUserClick_Test_1()
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

                /* Set of assertions */
                Assert.IsFalse(porscheBalPage.UserActivitiesClicked);

                porscheBalPage.LoggedUserClick(driver);
                Assert.IsTrue(porscheBalPage.UserActivitiesClicked);
            }
        }

        [TestMethod]
        public void ParticularProjectPage_LoggedUserClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                /* Set of assertions */
                Assert.IsFalse(porscheBalPage.UserActivitiesClicked);

                porscheBalPage.LoggedUserClick(driver);
                Assert.IsFalse(porscheBalPage.UserActivitiesClicked);
            }
        }

        [TestMethod]
        public void ParticularProjectPage_LoggedUserClick_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.IsPar
            }
        }

        [TestMethod]
        public void ParticularProjectPage_ProfileClick_Test_1()
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
                porscheBalPage.ProfileClick(driver);

                /* Set of assertions */

                //Assert.IsFalse(porscheBalPage.MyProfileInstance.MyProfileBodyIsNull);
                //Assert.AreEqual(0, porscheBalPage.MyProfileInstance.ItemsBodyIsNull);
                //Assert.AreEqual(6, porscheBalPage.MyProfileInstance.ItemsDropDownIsFull);
                //Assert.AreEqual(250, porscheBalPage.MyProfileInstance.ChosenItemsPerPage);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_MyProfileInstance_Test_1()
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
                porscheBalPage.ProfileClick(driver);

                //porscheBalPage.MyProfileInstance.DropDownInitialization(driver);

                /* Set of assertions */

                //Assert.AreEqual(0, porscheBalPage.MyProfileInstance.ItemsBodyIsNull);
                //Assert.AreEqual(6, porscheBalPage.MyProfileInstance.ItemsDropDownIsFull);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_ChangingItemsPerPage_Test_1()
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
                porscheBalPage.ProfileClick(driver);

                porscheBalPage.ChangeItemsPerPage(driver);

                /* Set of assertions */

                Assert.AreEqual("Your Profile has been saved successfully!", porscheBalPage.InfoMessage);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_JobsClick_Test_1()
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

                porscheBalPage.JobsClick(driver);

                string sectionName = "jobs";
                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                /* Set of assertions */

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
                

            }

        }

        [TestMethod]
        public void ParticularProjectPage_PlanningClick_Test_1()
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

                porscheBalPage.PlanningClick(driver);

                string sectionName = "planning";
                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                /* Set of assertions */

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());


            }

        }

        [TestMethod]
        public void ParticularProjectPage_StatusClick_Test_1()
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

                string sectionName = "status";
                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                /* Set of assertions */

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());


            }

        }

    }
}
