using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;
using TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects;
namespace TMS_Constant_Evaluation_Tests.Pages_Tests
{
    [TestClass]
    public class WholeProgram_Tests
    {

        [TestMethod]
        public void AssigneesElement_ParsingCorrectly_Test_1()
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

                porscheBalPage.StatusClick(driver);
                StatusPage porscheStatusPage = new StatusPage(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                porscheAssigneesPage.ActivityFilterClick();
                porscheAssigneesPage.ChosenActivityClick("InternalReview", driver);

                PageBar pageBar = new PageBar(driver);
                pageBar.SetMaximalItems(driver);

                Thread.Sleep(5000);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));

                AssigneeAndHisJob firstAssingee = new AssigneeAndHisJob(r_LHObjects.ElementAt(0), r_LObjects.ElementAt(0));
                Assert.AreNotEqual("", firstAssingee.assigneeName);
                Assert.AreNotEqual("", firstAssingee.sourceLanguage);

                Assert.AreEqual(0, Int32.Parse(r_LHObjects.ElementAt(0).FindElement(By.ClassName("r_LCount")).Text.Trim().Replace("(", "").Replace(")", "")));

                /* Set of assertions */

                /*AssigneeElement el = new AssigneeElement(assignees[0], assigneesJobs);
                Assert.AreEqual("bg-bg", el.AssigneeLanguage);
                Assert.AreEqual(el.AssigneeJobsNumber, el.AssigneesJobsList.Count);*/

                Assert.AreEqual(0, r_LHObjects.Count);
                Assert.AreEqual(0, r_LObjects.Count);

            }

        }

    }
}
