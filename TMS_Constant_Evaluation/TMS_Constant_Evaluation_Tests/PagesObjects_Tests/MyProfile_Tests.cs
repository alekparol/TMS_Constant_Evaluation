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
    public class MyProfile_Tests
    {

        /* Parsing Correctly Tests */
        [TestMethod]
        public void MyProfile_ParsingCorrectly_Test_1()
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

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(1, myProfile.MyProfileBodyIsDisplayed);
                Assert.AreEqual(1, myProfile.CloseButtonIsDisplayed);
                Assert.AreEqual(1, myProfile.ReduceButtonIsDisplayed);
                Assert.AreEqual(1, myProfile.FullscreenButtonIsDisplayed);
                Assert.AreEqual(1, myProfile.SaveButtonIsDisplayed);
                Assert.IsTrue(myProfile.IsParsingCorrect);

            }

        }

        [TestMethod]
        public void MyProfile_ParsingCorrectly_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, myProfile.MyProfileBodyIsDisplayed);
                Assert.AreEqual(-1, myProfile.CloseButtonIsDisplayed);
                Assert.AreEqual(-1, myProfile.ReduceButtonIsDisplayed);
                Assert.AreEqual(-1, myProfile.FullscreenButtonIsDisplayed);
                Assert.AreEqual(-1, myProfile.SaveButtonIsDisplayed);
                Assert.IsFalse(myProfile.IsParsingCorrect);

            }

        }

        /* Drop Down Button Click Tests */
        [TestMethod]
        public void MyProfile_DrobDownButtonClick_Test_1()
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

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(0, myProfile.ItemsDropDownListIsExpanded);

                myProfile.ItemsDropDownButtonClick(driver);
                Assert.AreEqual(1, myProfile.ItemsDropDownListIsExpanded);

            }

        }

        [TestMethod]
        public void MyProfile_DrobDownButtonClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, myProfile.ItemsDropDownListIsExpanded);

                myProfile.ItemsDropDownButtonClick(driver);
                Assert.AreEqual(-1, myProfile.ItemsDropDownListIsExpanded);

            }

        }

        /* Drop Down Initialization Tests */
        [TestMethod]
        public void MyProfile_DrobDownInitialization_Test_1()
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

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(0, myProfile.ItemsDropDownListIsExpanded);
                Assert.AreEqual(-1, myProfile.ItemsDropDownIsFull);
                Assert.AreEqual(-1, myProfile.ChosenItemsPerPage);

                myProfile.DropDownInitialization(driver);

                Assert.AreEqual(1, myProfile.ItemsDropDownListIsExpanded);
                Assert.AreEqual(1, myProfile.ItemsDropDownIsFull);
                Assert.AreEqual(250, myProfile.ChosenItemsPerPage);

            }

        }

        [TestMethod]
        public void MyProfile_DrobDownInitialization_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, myProfile.ItemsDropDownListIsExpanded);
                Assert.AreEqual(-1, myProfile.ItemsDropDownIsFull);
                Assert.AreEqual(-1, myProfile.ChosenItemsPerPage);

                myProfile.DropDownInitialization(driver);

                Assert.AreEqual(-1, myProfile.ItemsDropDownListIsExpanded);
                Assert.AreEqual(-1, myProfile.ItemsDropDownIsFull);
                Assert.AreEqual(-1, myProfile.ChosenItemsPerPage);

            }

        }

        /* Save Button Click Tests */
        [TestMethod]
        public void MyProfile_SaveButtonClick_Test_1()
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

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(1, myProfile.MyProfileBodyIsDisplayed);
                Assert.AreEqual(1, myProfile.CloseButtonIsDisplayed);
                Assert.AreEqual(1, myProfile.ReduceButtonIsDisplayed);
                Assert.AreEqual(1, myProfile.FullscreenButtonIsDisplayed);
                Assert.AreEqual(1, myProfile.SaveButtonIsDisplayed);

                myProfile.SaveButtonClick(driver);

                Assert.AreEqual(0, myProfile.MyProfileBodyIsDisplayed);
                Assert.AreEqual(0, myProfile.CloseButtonIsNull);
                Assert.AreEqual(0, myProfile.ReduceButtonIsNull);
                Assert.AreEqual(0, myProfile.FullscreenButtonIsNull);
                Assert.AreEqual(0, myProfile.SaveButtonIsNull);

            }

        }

        [TestMethod]
        public void MyProfile_SaveButtonClick_Test_2()
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://lionbridge.com/");

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                Assert.AreEqual(-1, myProfile.MyProfileBodyIsDisplayed);
                Assert.AreEqual(-1, myProfile.CloseButtonIsDisplayed);
                Assert.AreEqual(-1, myProfile.ReduceButtonIsDisplayed);
                Assert.AreEqual(-1, myProfile.FullscreenButtonIsDisplayed);
                Assert.AreEqual(-1, myProfile.SaveButtonIsDisplayed);

                myProfile.SaveButtonClick(driver);

                Assert.AreEqual(-1, myProfile.MyProfileBodyIsDisplayed);
                Assert.AreEqual(-1, myProfile.CloseButtonIsNull);
                Assert.AreEqual(-1, myProfile.ReduceButtonIsNull);
                Assert.AreEqual(-1, myProfile.FullscreenButtonIsNull);
                Assert.AreEqual(-1, myProfile.SaveButtonIsNull);

            }

        }

        /* Save Button Click Tests */
        [TestMethod]
        public void MyProfile_ChangeNumberOfItems_Test_1()
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
                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

                myProfile.DropDownInitialization(driver);
                Assert.AreEqual(250, myProfile.ChosenItemsPerPage);

                myProfile.ChangeNumberOfItems(driver, 25);

                Assert.AreEqual(0, myProfile.MyProfileBodyIsDisplayed);

                driver.Navigate().Refresh();

                testPage = new ProjectsPage(driver, projectTitle);
                testPage.ClickChosenProject();
                
                testProjectPage = new ParticularProjectPage(driver);                
                testProjectPage.ProfileClick(driver);

                myProfile = new MyProfile(driver);

                myProfile.DropDownInitialization(driver);
                Assert.AreEqual(25, myProfile.ChosenItemsPerPage);

            }

        }

    }
}
