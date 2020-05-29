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

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Status_Tests.PageObjects_Tests
{
    [TestClass]
    public class AssigneesObject_Tests
    {


        [TestMethod]
        public void AssigneesObject_ParsingCorrectly_Test_1()
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
                StatusPage2 porscheStatusPage = new StatusPage2(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                Assignees el = new Assignees(driver.FindElements(By.ClassName("r_LH")).ElementAt(0));
                Assert.IsNotNull(el);

                string rowid = driver.FindElements(By.ClassName("R_L")).ElementAt(0).GetAttribute("rowid");

                Assert.AreEqual("", driver.FindElements(By.ClassName("R_L")).ElementAt(0).FindElement(By.Id(rowid)).FindElement(By.ClassName("tlp_on")).Text);

                //Thread.Sleep(5000);
                AssigneesObject asob = new AssigneesObject(driver);

                /* Set of assertions */


            }
        }


    }
}
