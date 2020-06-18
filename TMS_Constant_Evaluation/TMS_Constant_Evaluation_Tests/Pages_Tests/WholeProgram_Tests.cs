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
                StatusPage2 porscheStatusPage = new StatusPage2(driver);

                porscheStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                porscheAssigneesPage.ActivityFilterClick();
                porscheAssigneesPage.ChosenActivityClick("InternalReview", driver);

                PageBar pageBar = new PageBar(driver);
                pageBar.SetMaximalItems(driver);
                //pageBar.SetMaximalItems(driver);


                /*IWebElement auxiliaryElement = null;
                IWebElement auxiliaryElement2 = null;
                IReadOnlyCollection<IWebElement> auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='dd ddSelected']"));
                if (auxiliaryCollection.Count > 0) auxiliaryElement = auxiliaryCollection.Where(x => x.GetAttribute("id").Contains("msdrpdd")).ElementAt(0);

                auxiliaryCollection = auxiliaryElement.FindElements(By.ClassName("ddChild"));
                if (auxiliaryCollection.Count == 1) auxiliaryElement2 = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = auxiliaryElement2.FindElements(By.TagName("a"));

                auxiliaryElement.Click();
                Thread.Sleep(4000);
                auxiliaryCollection.ElementAt(5).Click();
                Thread.Sleep(5000);*/

                IReadOnlyCollection<IWebElement> r_LHObjects = driver.FindElements(By.ClassName("r_LH"));
                IReadOnlyCollection<IWebElement> r_LObjects = driver.FindElements(By.ClassName("r_H"));
                

                /*while (true)
                {
                    if (wait.Until(ExpectedConditions.ElementExists(By.ClassName("r_LH"))) != null)
                    {

                        auxiliaryCollection = driver.FindElements(By.ClassName("r_LH"));
                        if (auxiliaryCollection.Count > 0)
                        {
                            r_LHObjects.Union(auxiliaryCollection);
                        }

                        auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));
                        if (auxiliaryCollection.Count > 0)
                        {
                            r_LObjects.Union(auxiliaryCollection);
                        }

                        if (pageBar.IfNextPageExists == 0)
                        {
                            break;
                        }
                        else
                        {
                            pageBar.GoToNextPage(driver);
                        }


                        pageBar = new PageBar(driver);

                    }
                }*/

                    /*IReadOnlyCollection<IWebElement> r_LHObjects2 = driver.FindElements(By.ClassName("r_LH"));
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

                    }*/

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
