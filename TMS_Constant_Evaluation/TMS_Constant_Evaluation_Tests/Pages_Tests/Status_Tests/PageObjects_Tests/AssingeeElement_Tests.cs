using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace TMS_Constant_Evaluation_Tests.Pages_Tests.Status_Tests.PageObjects_Tests
{
    [TestClass]
    public class AssingeeElement_Tests
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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage porscheStatusPage = new StatusPage(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                porscheAssigneesPage.ActivitiesFilterClick();
                porscheAssigneesPage.ChosenActivityClick("InternalReview", driver);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                List<Assignees> assignees = new List<Assignees>();

                Assignees auxiliaryAssignee;

                foreach (IWebElement r_LH in r_LHObjects)
                {

                    auxiliaryAssignee = new Assignees(r_LH);
                    assignees.Add(auxiliaryAssignee);

                }

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneesJobs> assigneesJobs = new List<AssigneesJobs>();

                AssigneesJobs auxiliaryAssigneeJobs;

                foreach (IWebElement r_L in r_LObjects)
                {

                    auxiliaryAssigneeJobs = new AssigneesJobs(r_L);
                    assigneesJobs.Add(auxiliaryAssigneeJobs);

                }

                /* Set of assertions */

                AssigneeElement el = new AssigneeElement(assignees[0], assigneesJobs);
                Assert.AreEqual("bg-bg", el.AssigneeLanguage);
                Assert.AreEqual(el.AssigneeJobsNumber, el.AssigneesJobsList.Count);

            }

        }

        [TestMethod]
        public void AssigneesElement_ParsingCorrectly_Test_2()
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
                StatusPage porscheStatusPage = new StatusPage(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                porscheAssigneesPage.ActivitiesFilterClick();
                porscheAssigneesPage.ChosenActivityClick("InternalReview", driver);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                List<Assignees> assignees = new List<Assignees>();

                Assignees auxiliaryAssignee;

                foreach (IWebElement r_LH in r_LHObjects)
                {

                    auxiliaryAssignee = new Assignees(r_LH);
                    assignees.Add(auxiliaryAssignee);

                }

                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));
                List<AssigneesJobs> assigneesJobs = new List<AssigneesJobs>();

                AssigneesJobs auxiliaryAssigneeJobs;

                foreach (IWebElement r_L in r_LObjects)
                {

                    auxiliaryAssigneeJobs = new AssigneesJobs(r_L);
                    assigneesJobs.Add(auxiliaryAssigneeJobs);

                }

                AssigneeElement el = new AssigneeElement(assignees[0], assigneesJobs);

                Actions a = new Actions(driver);

                a.Click(el.AssigneesJobsList[0].JobsIWebElement)
                 .KeyDown(Keys.Shift)
                 .Click(el.AssigneesJobsList[el.AssigneesJobsList.Count - 1].JobsIWebElement)
                 .Build()
                 .Perform();

                OnClickJobsMenu menu = new OnClickJobsMenu(driver);
                menu.ClickTagJobsButton(driver);

                AssigneesPage afterTagging = new AssigneesPage(driver);
                afterTagging.ActivitiesSubPageClick(driver);

                StatusPage statusPageAfterTagging = new StatusPage(driver);

                statusPageAfterTagging.ActivitiesFilterClick();
                Thread.Sleep(1000);

                statusPageAfterTagging.ChosenActivityClick("Translation", driver);
                Thread.Sleep(10000);
                /* Set of assertions */

            }

        }
    }
}
