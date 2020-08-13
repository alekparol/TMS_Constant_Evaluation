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
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;
using TMS_Constant_Evaluation.PagesObjects.JobObject;

namespace TMS_Constant_Evaluation_Tests.Pages_Tests
{
    [TestClass]
    public class WholeProgram_Tests
    {

        [TestMethod]
        public void WholeProgram_NewParsingCorrectly_Test_1()
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

                porscheAssigneesPage.ChosenActivityClick(driver, "InternalReview");
                porscheAssigneesPage = new AssigneesPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.ItemsPerPageSetMaximalValue(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);
                asob.TagMultipleJobs(driver, 0, asob.GetAssigneeJobsListSize - 1);

                ViewsMenu assigneesViewsMenu = new ViewsMenu(driver);
                assigneesViewsMenu.JobsClick(driver);

                Thread.Sleep(5000);
                //Jobs job = new Jobs(driver.FindElement(By.ClassName("r_L")));
                //job.JobButtonClick(driver);
                JobsSectionJobs jsj = new JobsSectionJobs(driver);            

                jsj.ShowHistoryOfJob(driver, 0);
                Thread.Sleep(5000);

                /*Thread.Sleep(5000);


                Thread.Sleep(5000);


                IWebElement auxiliaryJob = driver.FindElements(By.ClassName("r_L")).ElementAt(0);
                IReadOnlyCollection<IWebElement> childNodes = auxiliaryJob.FindElements(By.TagName("td"));

                String mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover', true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject){ arguments[0].fireEvent('onmouseover');}";
                String onClickScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('click',true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject){ arguments[0].fireEvent('onclick');}";

                ((IJavaScriptExecutor)driver).ExecuteScript(mouseOverScript, auxiliaryJob);
                Thread.Sleep(4000);
                ((IJavaScriptExecutor)driver).ExecuteScript(onClickScript, auxiliaryJob);
                Thread.Sleep(4000);*/




            }
        }

        [TestMethod]
        public void WholeProgram_NewParsingCorrectly_Test_2()
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

                ViewsMenu assigneesViewsMenu = new ViewsMenu(driver);
                assigneesViewsMenu.JobsClick(driver);

                Thread.Sleep(5000);


                //IWebElement auxiliaryJob2 = driver.FindElements(By.ClassName("r_L")).ElementAt(2);





                //driver.FindElement(By.Id("jobsactivity")).Click();
                //Thread.Sleep(7000);
                //driver.FindElement(By.Id("SelectDeselectAll")).Click();
                //Thread.Sleep(7000);

                //auxiliaryJob.FindElement(By.TagName("div")).Click();
                //Thread.Sleep(7000);

                IWebElement auxiliaryJob = driver.FindElements(By.ClassName("r_L")).ElementAt(0);
                IReadOnlyCollection<IWebElement> childNodes = auxiliaryJob.FindElements(By.TagName("td"));

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].dispatchEvent(new Event('rowSelected'))", auxiliaryJob);

                Actions Action = new Actions(driver);

                for (int i = 0; i < 100; i++)
                {
                    Action.MoveToElement(auxiliaryJob).MoveByOffset(-100 - 1, 14).Click().Build().Perform();
                    Thread.Sleep(7000);

                }
                childNodes.ElementAt(0).Click();
                Thread.Sleep(7000);
            }
        }

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

                //AssigneeAndHisJob firstAssingee = new AssigneeAndHisJob(r_LHObjects.ElementAt(0), r_LObjects.ElementAt(0));
                //Assert.AreNotEqual("", firstAssingee.assigneeName);
                //Assert.AreNotEqual("", firstAssingee.sourceLanguage);

                //AssigneesAndTheirJobs aTJ = new AssigneesAndTheirJobs(r_LHObjects, r_LObjects);
                //Assert.AreEqual(4, aTJ.assigneesAngTheirJobsList.Count);
                //Assert.AreEqual(0, aTJ.count);

                //IOrderedEnumerable<AssigneeAndHisJob> aTJOrdered = aTJ.assigneesAngTheirJobsList.OrderBy(x => x.targetLanguage);

                /*IEnumerable<AssigneeAndHisJob> auxiliaryEnumerable;
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

                AssingeesOnClickJobsMenu menu = new AssingeesOnClickJobsMenu(driver);
                menu.ClickTagJobsButton(driver);

                AssigneesPage afterTagging = new AssigneesPage(driver);
                afterTagging.ActivitiesClick(driver);*/

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

                //translationPage.ChosenGetTargetLanguageClick(driver, differentLanguages.ElementAt(1));

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

                //Assert.AreEqual("", differentLanguages.ElementAt(0));
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
