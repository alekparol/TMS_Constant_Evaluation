using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                porscheAssigneesPage.ActivitiesFilterClick(driver);
                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");

                PageBar pageBar = new PageBar(driver);
                pageBar.ItemsPerPageSetMaximalValue(driver);

                Thread.Sleep(5000);

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_L"));

                AssigneeAndHisJob firstAssingee = new AssigneeAndHisJob(r_LHObjects.ElementAt(0), r_LObjects.ElementAt(0));
                Assert.AreNotEqual("", firstAssingee.assigneeName);
                Assert.AreNotEqual("", firstAssingee.sourceLanguage);

                AssigneesAndTheirJobs aTJ = new AssigneesAndTheirJobs(r_LHObjects, r_LObjects);
                //Assert.AreEqual(4, aTJ.assigneesAngTheirJobsList.Count);
                //Assert.AreEqual(0, aTJ.count);

                IOrderedEnumerable<AssigneeAndHisJob> aTJOrdered = aTJ.assigneesAngTheirJobsList.OrderBy(x => x.targetLanguage);

                IEnumerable<AssigneeAndHisJob> auxiliaryEnumerable;
                List<string> differentLanguages = new List<string>();

                string auxiliaryString;
                int auxiliaryInt = 0;

                while (auxiliaryInt < aTJ.count)
                {
                    auxiliaryString = aTJOrdered.ElementAt(auxiliaryInt).targetLanguage;
                    if (auxiliaryString != "" && auxiliaryString != null)
                    {
                        differentLanguages.Add(auxiliaryString);
                    }

                    auxiliaryEnumerable = aTJ.assigneesAngTheirJobsList.Where(x => x.targetLanguage == auxiliaryString);
                    auxiliaryInt += auxiliaryEnumerable.Count();
                }

                //Assert.AreEqual(0, differentLanguages.Count);

                Actions a = new Actions(driver);

                a.Click(aTJ.assigneesAngTheirJobsList.ElementAt(0).webElement)
                 .KeyDown(Keys.Shift)
                 .MoveToElement(r_LObjects.ElementAt(2))
                 .Click(aTJ.assigneesAngTheirJobsList.ElementAt(aTJ.count - 1).webElement)
                 .Build()
                 .Perform();

                OnClickJobsMenu menu = new OnClickJobsMenu(driver);
                menu.ClickTagJobsButton(driver);

                AssigneesPage afterTagging = new AssigneesPage(driver);
                afterTagging.ActivitiesClick(driver);

                StatusPage statusPageAfterTagging = new StatusPage(driver);
                statusPageAfterTagging.ClickAll(driver);

                Thread.Sleep(10000);
                StatusPage statusPageAll = new StatusPage(driver);
                Thread.Sleep(1000);
                statusPageAll.ActivitiesFilterClick(driver);
                Thread.Sleep(1000);

                statusPageAll.ChosenActivityClick(driver, "Translation");
                Thread.Sleep(10000);

                StatusPage translationPage = new StatusPage(driver);

                translationPage.LanguageFilterClick(driver);
                Thread.Sleep(1000);

                translationPage.ChosenGetTargetLanguageClick(driver, differentLanguages.ElementAt(1));

                Thread.Sleep(5000);

                pageBar = new PageBar(driver);
                pageBar.ItemsPerPageSetMaximalValue(driver);

                Thread.Sleep(5000);

                IReadOnlyCollection<IWebElement> r_LHTranslationJobs = driver.FindElements(By.ClassName("r_LH"));
                List<string> translationJobNames = new List<string>();

                IWebElement auxiliaryElement;

                foreach (IWebElement el in r_LHTranslationJobs)
                {
                    auxiliaryElement = el.FindElement(By.ClassName("grp_ttl"));
                    translationJobNames.Add(auxiliaryElement.Text);
                }

                Assert.AreEqual("", differentLanguages.ElementAt(0));
                Assert.AreEqual("", translationJobNames.ElementAt(0));

                /* Set of assertions */

                /*AssigneeElement el = new AssigneeElement(assignees[0], assigneesJobs);
                Assert.AreEqual("bg-bg", el.AssigneeLanguage);
                Assert.AreEqual(el.GetAssigneeJobsNumberString, el.AssigneeJobsList.Count);*/

                Assert.AreEqual(0, r_LHObjects.Count);
                Assert.AreEqual(0, r_LObjects.Count);

            }

        }

    }
}
