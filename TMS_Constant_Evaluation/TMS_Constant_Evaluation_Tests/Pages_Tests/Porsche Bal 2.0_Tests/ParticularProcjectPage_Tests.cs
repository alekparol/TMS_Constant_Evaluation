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

                Assert.IsTrue(porscheBalPage.IsParsedCorrectly);

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
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.IsFalse(porscheBalPage.IsParsedCorrectly);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_SelectedProject_Test_1()
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

            }

        }

        [TestMethod]
        public void ParticularProjectPage_SectionsContent_Test_1()
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

                Assert.AreEqual("Jobs", porscheBalPage.JobsSection.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text);
                Assert.AreEqual("Planning", porscheBalPage.PlanningSection.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text);
                Assert.AreEqual("Status", porscheBalPage.StatusSection.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text);

            }

        }

        [TestMethod]
        public void ParticularProjectPage_LoggedUser_Test_1()
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

                Assert.AreEqual("Parol Aleksander", porscheBalPage.LoggedUser);
                Assert.IsFalse(porscheBalPage.UserActivitiesClicked);

            }

        }

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
                porscheBalPage.LoggedUserClick(driver);

                /* Set of assertions */

                Assert.IsTrue(porscheBalPage.UserActivitiesClicked);

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

                Assert.IsFalse(porscheBalPage.MyProfileInstance.BodyIsNull);
                Assert.IsFalse(porscheBalPage.MyProfileInstance.ItemsBodyIsNull);
                Assert.AreEqual(6, porscheBalPage.MyProfileInstance.ItemsCount);
                Assert.AreEqual(250, porscheBalPage.MyProfileInstance.ItemsChosen);

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

                porscheBalPage.MyProfileInstance.ItemsDropDownClick(driver);

                /* Set of assertions */

                Assert.IsFalse(porscheBalPage.MyProfileInstance.ItemsBodyIsNull);
                Assert.AreEqual(6, porscheBalPage.MyProfileInstance.ItemsCount);

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
