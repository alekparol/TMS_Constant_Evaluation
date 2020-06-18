using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TMS_Constant_Evaluation;
using TMS_Constant_Evaluation.Pages;

namespace TMS_Constant_Evaluation_Tests
{
    [TestClass]
    public class StatusPage_Tests
    {
        [TestMethod]
        public void StatusPage_Initialization_Test_1()
        {
            using (var driver = new ChromeDriver())
            {
                // Initialization
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                Assert.AreEqual("TMS - Porsche BAL 2.0", driver.Title);

                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));

                StatusPage objectStatusPage = new StatusPage(driver);
                Assert.AreEqual("Status", objectStatusPage.PageTitle.Text);

                driver.Quit();
            }
        }

        [TestMethod]
        public void StatusPage_Initialization_Test_2()
        {           
            using (var driver = new ChromeDriver())
            {
                // Initialization
                List<StatusObject> listStatusObjects = new List<StatusObject>();
                StatusObject auxiliaryStatusObject = new StatusObject();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();
                
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));                
                StatusPage objectStatusPage = new StatusPage(driver);

                IReadOnlyCollection<IWebElement> listOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));
                Assert.AreEqual("RedSys - X171702_4440095", listOfTitlesStatusWebElements.ElementAt(0).Text);
                Assert.AreEqual("de-de → ar-ae", listOfTitlesStatusWebElements.ElementAt(0).FindElement(By.XPath("..")).FindElement(By.ClassName("grp_lg")).Text);

                if(listOfTitlesStatusWebElements.Count != 0)
                {
                    foreach(IWebElement element in listOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        listStatusObjects.Add(auxiliaryStatusObject);
                    }                    
                }

      
                Assert.AreNotEqual(12, listStatusObjects[0].stepsCount);
                Assert.AreEqual(21, listStatusObjects.Count);

                objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                driver.Quit();
            }
        }

        [TestMethod]
        public void StatusPage_Initialization_Test_3()
        {
            using (var driver = new ChromeDriver())
            {
                // Initialization
                List<StatusObject> listStatusObjects = new List<StatusObject>();
                List<StatusObject> secondListStatusObjects = new List<StatusObject>();

                StatusObject auxiliaryStatusObject = new StatusObject();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));
                StatusPage objectStatusPage = new StatusPage(driver);

                IReadOnlyCollection<IWebElement> listOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));
               

                if (listOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in listOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        listStatusObjects.Add(auxiliaryStatusObject);
                    }
                }

                objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                IReadOnlyCollection<IWebElement> secondListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                if (secondListOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in secondListOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        secondListStatusObjects.Add(auxiliaryStatusObject);
                    }
                }

                Assert.AreNotEqual(listStatusObjects.Count, secondListStatusObjects.Count);
                Assert.AreEqual("(1)", secondListOfTitlesStatusWebElements.ElementAt(0).FindElement(By.XPath("../../..")).FindElement(By.ClassName("r_LCount")).Text);

                driver.Quit();
            }
        }

        [TestMethod]
        public void StatusPage_Initialization_Test_4()
        {
            using (var driver = new ChromeDriver())
            {
                // Initialization
                List<StatusObject> listStatusObjects = new List<StatusObject>();
                List<StatusObject> secondListStatusObjects = new List<StatusObject>();

                StatusObject auxiliaryStatusObject = new StatusObject();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));
                StatusPage objectStatusPage = new StatusPage(driver);

                IReadOnlyCollection<IWebElement> listOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));


                if (listOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in listOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        listStatusObjects.Add(auxiliaryStatusObject);
                    }
                }

                /*objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                IReadOnlyCollection<IWebElement> secondListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                if (secondListOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in secondListOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        secondListStatusObjects.Add(auxiliaryStatusObject);
                    }
                }*/

                var pageList = driver.FindElementsByClassName("pgr_lst");
                IReadOnlyCollection<IWebElement> pageObjectList;


                /* This is pretty complex thing as the structure of the page list is as follows:
                 -previousPage button which is in class pgr_prv does not exists when the current page is the first page. 
                 -current page is in the class pgr_on.
                 -nextPage button which is in the class pgr_nxt does not exists when the current page is the last page. 
                 -the lastPage cannot be seen when the number is high - as on many websites, so my idea is to determine if the current page is last 
                 page with nextPage existence. */

                IWebElement currentPage, previousPage, nextPage, lastPage;


                if(pageList.Count == 1)
                {
                    pageObjectList = pageList[0].FindElements(By.TagName("li"));

                    currentPage = pageObjectList.Where(x => x.GetAttribute("class") == "pgr_on").ElementAt(0);
                    //previousPage = pageObjectList.Where(x => x.GetAttribute("class") == "").ElementAt(0);
                    nextPage = pageObjectList.Where(x => x.GetAttribute("class") == "pgr_nxt").ElementAt(0);

                    nextPage.Click();

                }

                Thread.Sleep(5000);

                driver.Quit();
            }
        }

        [TestMethod]
        public void StatusPage_Initialization_Test_5()
        {
            using (var driver = new ChromeDriver())
            {
                // Initialization
                List<StatusObject> listStatusObjects = new List<StatusObject>();
                List<StatusObject> secondListStatusObjects = new List<StatusObject>();
                List<StatusObject> thirdListStatusObjects = new List<StatusObject>();

                StatusObject auxiliaryStatusObject = new StatusObject();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));
                StatusPage objectStatusPage = new StatusPage(driver);

                objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                IReadOnlyCollection<IWebElement> secondListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                if (secondListOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in secondListOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        secondListStatusObjects.Add(auxiliaryStatusObject);
                    }
                }


                IWebElement currentActivityTitle = driver.FindElement(By.XPath("//*[@id='cup_fpStepActivityName_msdd']")).FindElement(By.Id("cup_fpStepActivityName_titletext"));
                Assert.AreEqual("InternalReview", currentActivityTitle.Text);

                IWebElement closeActivityFilter = driver.FindElement(By.XPath("//*[@id='cup_fpStepActivityName_msdd']")).FindElement(By.ClassName("filter_close"));
                Assert.IsNotNull(closeActivityFilter);

                closeActivityFilter.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='cup_fpStepActivityName_msdd']")));

                IWebElement activityFilter = driver.FindElement(By.XPath("//*[@id='cup_fpStepActivityName_msdd']"));
                activityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IReadOnlyCollection<IWebElement> activityList;

                IReadOnlyCollection<IWebElement> auxiliaryValidationList = activityFilter.FindElements(By.XPath("//div[@id='cup_fpStepActivityName_child']"));
                IWebElement activityChild;

                if (auxiliaryValidationList.Count == 1)
                {
                    activityChild = auxiliaryValidationList.ElementAt(0);
                    activityList = activityChild.FindElements(By.XPath(".//*"));

                    IWebElement translationActivity = activityList.Where(x => x.Text == "Translation").ElementAt(0);
                    translationActivity.Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                    IReadOnlyCollection<IWebElement> thirdListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                    if (thirdListOfTitlesStatusWebElements.Count != 0)
                    {
                        foreach (IWebElement element in thirdListOfTitlesStatusWebElements)
                        {
                            auxiliaryStatusObject = new StatusObject(element);
                            thirdListStatusObjects.Add(auxiliaryStatusObject);
                        }
                    }

                    IEnumerable<StatusObject> joinStatusObjects = thirdListStatusObjects.Where(x => x.jobName == secondListStatusObjects.Find(y => y.jobName == x.jobName).jobName );
                    Assert.AreEqual(1, joinStatusObjects.Count());

                }

                

                /*var pageList = driver.FindElementsByClassName("pgr_lst");
                IReadOnlyCollection<IWebElement> pageObjectList;


                IWebElement currentPage, previousPage, nextPage, lastPage;


                if (pageList.Count == 1)
                {
                    pageObjectList = pageList[0].FindElements(By.TagName("li"));

                    currentPage = pageObjectList.Where(x => x.GetAttribute("class") == "pgr_on").ElementAt(0);
                    //previousPage = pageObjectList.Where(x => x.GetAttribute("class") == "").ElementAt(0);
                    nextPage = pageObjectList.Where(x => x.GetAttribute("class") == "pgr_nxt").ElementAt(0);


                }*/

                Thread.Sleep(5000);

                driver.Quit();
            }
        }

        [TestMethod]
        public void StatusPage_Initialization_Test_6()
        {
            using (var driver = new ChromeDriver())
            {
                // Initialization
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage porscheBalPage = new ParticularProjectPage(driver);

                Assert.AreEqual(projectTitle.ToLower().Trim(), porscheBalPage.SelectedProjectName);
                porscheBalPage.StatusClick(driver);

                StatusPage stp2 = new StatusPage(driver);
                Assert.AreEqual("status", stp2.PageName);

                stp2.AssigneesClick(driver);

                AssigneesPage ap = new AssigneesPage(driver);
                Thread.Sleep(10000);

                //string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

                // Waiting for the Porsche BAL 2.0 project element which exists only for added users
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(projectXPath)));
                //IWebElement projectTMS = driver.FindElement(By.XPath(projectXPath));

                //projectTMS.Click();

                // Waiting for the "Status" section's element which exists only in the particular project
                /*wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='status']")));
                IWebElement statusPage = driver.FindElement(By.XPath("//li[@id='status']"));
                statusPage.Click();

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='cup_cupavFalse']")));
                StatusPage objectStatusPage = new StatusPage(driver);

                objectStatusPage.ActivityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IWebElement internalReviewActivity = objectStatusPage.activityList.Where(x => x.Text == "InternalReview").ElementAt(0);
                internalReviewActivity.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                IReadOnlyCollection<IWebElement> secondListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                if (secondListOfTitlesStatusWebElements.Count != 0)
                {
                    foreach (IWebElement element in secondListOfTitlesStatusWebElements)
                    {
                        auxiliaryStatusObject = new StatusObject(element);
                        secondListStatusObjects.Add(auxiliaryStatusObject);
                    }
                }


                IWebElement currentActivityTitle = driver.FindElement(By.XPath("//*[@id='cup_fpStepActivityName_msdd']")).FindElement(By.Id("cup_fpStepActivityName_titletext"));
                Assert.AreEqual("InternalReview", currentActivityTitle.Text);

                IWebElement closeActivityFilter = driver.FindElement(By.XPath("//*[@id='cup_fpStepActivityName_msdd']")).FindElement(By.ClassName("filter_close"));
                Assert.IsNotNull(closeActivityFilter);

                closeActivityFilter.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='cup_fpStepActivityName_msdd']")));

                IWebElement activityFilter = driver.FindElement(By.XPath("//*[@id='cup_fpStepActivityName_msdd']"));
                activityFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_msa_0")));

                IReadOnlyCollection<IWebElement> activityList;

                IReadOnlyCollection<IWebElement> auxiliaryValidationList = activityFilter.FindElements(By.XPath("//div[@id='cup_fpStepActivityName_child']"));
                IWebElement activityChild;

                if (auxiliaryValidationList.Count == 1)
                {
                    activityChild = auxiliaryValidationList.ElementAt(0);
                    activityList = activityChild.FindElements(By.XPath(".//*"));

                    IWebElement translationActivity = activityList.Where(x => x.Text == "Translation").ElementAt(0);
                    translationActivity.Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                    IReadOnlyCollection<IWebElement> thirdListOfTitlesStatusWebElements = driver.FindElements(By.ClassName("grp_ttl"));

                    if (thirdListOfTitlesStatusWebElements.Count != 0)
                    {
                        foreach (IWebElement element in thirdListOfTitlesStatusWebElements)
                        {
                            auxiliaryStatusObject = new StatusObject(element);
                            thirdListStatusObjects.Add(auxiliaryStatusObject);
                        }
                    }

                    IEnumerable<StatusObject> joinStatusObjects = thirdListStatusObjects.Where(x => x.jobName == secondListStatusObjects.Find(y => y.jobName == x.jobName).jobName);
                    Assert.AreEqual(1, joinStatusObjects.Count());

                }



                /*var pageList = driver.FindElementsByClassName("pgr_lst");
                IReadOnlyCollection<IWebElement> pageObjectList;


                IWebElement currentPage, previousPage, nextPage, lastPage;


                if (pageList.Count == 1)
                {
                    pageObjectList = pageList[0].FindElements(By.TagName("li"));

                    currentPage = pageObjectList.Where(x => x.GetAttribute("class") == "pgr_on").ElementAt(0);
                    //previousPage = pageObjectList.Where(x => x.GetAttribute("class") == "").ElementAt(0);
                    nextPage = pageObjectList.Where(x => x.GetAttribute("class") == "pgr_nxt").ElementAt(0);


                }*/

                Thread.Sleep(5000);

                driver.Quit();
            }
        }
    }
}
