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
    public class Assignees_Tests
    {

        [TestMethod]
        public void Assignees_ParsingCorrectly_Test_1()
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

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                List<Assignees> assignees = new List<Assignees>();
                
                Assignees auxiliaryAssignee;

                foreach (IWebElement r_LH in r_LHObjects)
                {

                    auxiliaryAssignee = new Assignees(r_LH);
                    assignees.Add(auxiliaryAssignee);

                }

                /* Set of assertions */

                Assert.AreEqual(7, assignees.Count);

                foreach (Assignees assignee in assignees)
                {

                    Assert.AreEqual(true, assignee.IsParsingCorrect);
                    Assert.AreNotEqual("", assignee.AssigneeName);
                    Assert.AreNotEqual("", assignee.AssigneeJobsNumber);
                    Assert.AreNotEqual(0, assignee.AssingeeJobsInt);
                }
            }
        }
    }
}
