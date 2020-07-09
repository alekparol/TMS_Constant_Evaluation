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
                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);
                porscheBalPage.ProfileClick(driver);

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
                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);
                porscheBalPage.ProfileClick(driver);

                MyProfile myProfile = new MyProfile(driver);

                /* Set of assertions */

            }

        }

    }
}
