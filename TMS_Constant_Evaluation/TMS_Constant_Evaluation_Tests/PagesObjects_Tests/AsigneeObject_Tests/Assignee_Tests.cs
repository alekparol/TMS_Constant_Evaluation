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

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.PageObjects_Tests
{
    [TestClass]
    public class Assignee_Tests
    {

        [TestMethod]
        public void Assignees_ParsingCorrectly_Test_1()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                Assignee auxiliaryAssignee;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Corteva";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage assigneesPage = new AssigneesPage(driver);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                List<Assignee> assignees = new List<Assignee>();
                
                foreach (IWebElement r_LH in r_LHObjects)
                {
                    auxiliaryAssignee = new Assignee(r_LH);
                    assignees.Add(auxiliaryAssignee);
                }

                /* Set of assertions */

                Assert.AreNotEqual(0, assignees.Count);

                foreach (Assignee assignee in assignees)
                {
                    Assert.IsFalse(assignee.AssigneeNameObjectIsNull);
                    Assert.AreEqual(1, assignee.AssigneeNameObjectIsEnabled);
                    Assert.AreEqual(0, assignee.AssigneeJobsNumberIsNull);
                    Assert.AreEqual(true, assignee.IsParsingCorrect);

                    Assert.AreNotEqual("", assignee.GetAssigneeName);
                    Assert.AreNotEqual("", assignee.GetAssigneeJobsNumberString);
                    Assert.AreNotEqual(0, assignee.GetAssingeeJobsNumberInt);
                }
            }
        }

        [TestMethod]
        public void Assignees_ParsingCorrectly_Test_2()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                Assignee auxiliaryAssignee;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Corteva";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage assigneesPage = new AssigneesPage(driver); 

                PageBar assigneesPageBar = new PageBar(driver);
                assigneesPageBar.ItemsPerPageSetMaximalValue(driver);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                List<Assignee> assignees = new List<Assignee>();

                foreach (IWebElement r_LH in r_LHObjects)
                {
                    auxiliaryAssignee = new Assignee(r_LH);
                    assignees.Add(auxiliaryAssignee);
                }

                /* Set of assertions */

                Assert.AreNotEqual(0, assignees.Count);

                foreach (Assignee assignee in assignees)
                {
                    Assert.IsFalse(assignee.AssigneeNameObjectIsNull);
                    Assert.AreEqual(1, assignee.AssigneeNameObjectIsEnabled);
                    Assert.AreEqual(0, assignee.AssigneeJobsNumberIsNull);
                    Assert.AreEqual(true, assignee.IsParsingCorrect);

                    Assert.AreNotEqual("", assignee.GetAssigneeName);
                    Assert.AreNotEqual("", assignee.GetAssigneeJobsNumberString);
                    Assert.AreNotEqual(0, assignee.GetAssingeeJobsNumberInt);
                }
            }
        }

        [TestMethod]
        public void Assignees_ParsingCorrectly_Test_3()
        {
            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                Assignee auxiliaryAssignee;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Corteva";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage assigneesPage = new AssigneesPage(driver);

                PageBar assigneesPageBar = new PageBar(driver);
                assigneesPageBar.ItemsPerPageSetMaximalValue(driver);

                assigneesPage = new AssigneesPage(driver);
                assigneesPage.ChosenActivityClick(driver, "Buffer_For_FreewayReview_H");

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                List<Assignee> assignees = new List<Assignee>();

                foreach (IWebElement r_LH in r_LHObjects)
                {
                    auxiliaryAssignee = new Assignee(r_LH);
                    assignees.Add(auxiliaryAssignee);
                }

                /* Set of assertions */

                Assert.AreNotEqual(0, assignees.Count);

                foreach (Assignee assignee in assignees)
                {
                    Assert.IsFalse(assignee.AssigneeNameObjectIsNull);
                    Assert.AreEqual(1, assignee.AssigneeNameObjectIsEnabled);
                    Assert.AreEqual(0, assignee.AssigneeJobsNumberIsNull);
                    Assert.AreEqual(true, assignee.IsParsingCorrect);

                    Assert.AreNotEqual("", assignee.GetAssigneeName);
                    Assert.AreNotEqual("", assignee.GetAssigneeJobsNumberString);
                    Assert.AreNotEqual(0, assignee.GetAssingeeJobsNumberInt);
                }
            }
        }
    }
}
