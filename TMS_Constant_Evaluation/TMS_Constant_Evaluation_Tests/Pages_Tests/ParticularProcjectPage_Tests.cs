using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;

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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.AreEqual(projectTitle.ToLower().Trim(), testProjectPage.GetSelectedProjectName);
                Assert.IsTrue(testProjectPage.IsParsingCorrect);

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

                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.IsFalse(testProjectPage.IsParsingCorrect);

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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */
                Assert.IsFalse(testProjectPage.UserActivitiesAreClicked);

                testProjectPage.LoggedUserClick(driver);
                Assert.IsTrue(testProjectPage.UserActivitiesAreClicked);
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
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */
                Assert.IsFalse(testProjectPage.UserActivitiesAreClicked);

                testProjectPage.LoggedUserClick(driver);
                Assert.IsFalse(testProjectPage.UserActivitiesAreClicked);
            }
        }

        /* Profile Click Tests */

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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                MyProfile testProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.IsFalse(testProfile.MyProfileBodyIsNull);
                Assert.AreEqual(0, testProfile.ItemsBodyIsNull);
                Assert.AreEqual(-1, testProfile.ItemsDropDownIsFull);
                Assert.AreEqual(-1, testProfile.ChosenItemsPerPage);
            }
        }

        [TestMethod]
        public void ParticularProjectPage_ProfileClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                MyProfile testProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.IsTrue(testProfile.MyProfileBodyIsNull);
                Assert.AreEqual(-1, testProfile.ItemsBodyIsNull);
                Assert.AreEqual(-1, testProfile.ItemsDropDownIsFull);
                Assert.AreEqual(-1, testProfile.ChosenItemsPerPage);
            }
        }

        /* Change Items Per Page Tests  */

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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                /* Set of assertions */

                Assert.AreEqual("Your Profile has been saved successfully!", testProjectPage.GetInfoMessage);
            }
        }

        /* More tests can be added here using other functionalities of MyProfile class */

        /* JobsClick Tests */

        [TestMethod]
        public void ParticularProjectPage_JobsClick_Test_1()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Jobs";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.AreEqual(0, testProjectPage.JobsViewIsClicked);
                Assert.AreNotEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreNotEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());              
            }

        }

        [TestMethod]
        public void ParticularProjectPage_JobsClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Jobs";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                testProjectPage.JobsClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(1, testProjectPage.JobsViewIsClicked);
                Assert.AreEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

        [TestMethod]
        public void ParticularProjectPage_JobsClick_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Jobs";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                 testProjectPage.PlanningClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(0, testProjectPage.JobsViewIsClicked);
                Assert.AreNotEqual(sectionName, testProjectPage.GetNameOfClickedView);

                 testProjectPage.JobsClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(1, testProjectPage.JobsViewIsClicked);
                Assert.AreEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

        /* PlanningClick Tests */

        [TestMethod]
        public void ParticularProjectPage_PlanningClick_Test_1()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Planning";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.AreEqual(0, testProjectPage.JobsViewIsClicked);
                Assert.AreNotEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreNotEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

        [TestMethod]
        public void ParticularProjectPage_PlanningClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Planning";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                 testProjectPage.PlanningClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(1, testProjectPage.PlanningViewIsClicked);
                Assert.AreEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

        [TestMethod]
        public void ParticularProjectPage_PlanningClick_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Planning";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                testProjectPage.StatusClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(0, testProjectPage.JobsViewIsClicked);
                Assert.AreNotEqual(sectionName, testProjectPage.GetNameOfClickedView);

                 testProjectPage.PlanningClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(1, testProjectPage.PlanningViewIsClicked);
                Assert.AreEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

        /* StatusClick Tests */

        [TestMethod]
        public void ParticularProjectPage_StatusClick_Test_1()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Status";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                Assert.AreEqual(0, testProjectPage.StatusViewIsClicked);
                Assert.AreNotEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreNotEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }

        }

        [TestMethod]
        public void ParticularProjectPage_StatusClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Status";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                testProjectPage.StatusClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(1, testProjectPage.StatusViewIsClicked);
                Assert.AreEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

        [TestMethod]
        public void ParticularProjectPage_StatusClick_Test_3()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                string sectionName = "Status";
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                /* Set of assertions */

                 testProjectPage.PlanningClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(0, testProjectPage.StatusViewIsClicked);
                Assert.AreNotEqual(sectionName, testProjectPage.GetNameOfClickedView);

                testProjectPage.StatusClick(driver);
                testProjectPage = new ParticularProjectPage(driver);

                Assert.AreEqual(1, testProjectPage.StatusViewIsClicked);
                Assert.AreEqual(sectionName, testProjectPage.GetNameOfClickedView);

                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));

                Assert.IsTrue(auxiliaryCollection.Count > 0);
                Assert.AreEqual(sectionName.ToLower().Trim(), auxiliaryCollection.ElementAt(0).Text.ToLower().Trim());
            }
        }

    }
}
