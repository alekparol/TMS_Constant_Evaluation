using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using TMS_Constant_Evaluation.DataFormats;
using TMS_Constant_Evaluation.Pages;
using TMS_Constant_Evaluation.Pages.PagesObjects;
using TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects;
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;
using TMS_Constant_Evaluation.PagesObjects.JobObject;
using TMS_Constant_Evaluation.PagesObjects.JobObject.JobsHistoryWindow;


namespace TMS_Constant_Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var driver = new ChromeDriver())
            {

                /* Initialization */
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                string projectTitle = "Porsche BAL 2.0";
                string firstStepName = "InternalReview";
                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPage(driver);

                testProjectPage.StatusClick(driver);
                StatusPage testStatusPage = new StatusPage(driver);

                testStatusPage.AssigneesClick(driver);
                AssigneesPage porscheAssigneesPage = new AssigneesPage(driver);

                if (porscheAssigneesPage.ChosenActivityClick(driver, firstStepName) != 1)
                {
                    Console.WriteLine("There is no {0} steps!", firstStepName);
                    return;
                }
                porscheAssigneesPage = new AssigneesPage(driver);

                PageBar testPageBar = new PageBar(driver);
                testPageBar.ItemsPerPageSetMaximalValue(driver);

                AssigneesAndJobs asob = new AssigneesAndJobs(driver);

                List<StatusAssgineeInfo> listOfStatusAssgineeInfo = new List<StatusAssgineeInfo>();
                StatusAssgineeInfo auxiliary;

                foreach(var ass in asob.assigneesJobsList)
                {
                    Console.WriteLine(ass.GetJobsName);
                }


                foreach (Assignee ass in asob.assigneesList)
                {
                    for (int i = 0; i < ass.GetAssingeeJobsNumberInt; i++)
                    {
                        auxiliary = new StatusAssgineeInfo(ass, asob.assigneesJobsList.ElementAt(i));
                        listOfStatusAssgineeInfo.Add(auxiliary);
                    }
                    for(int i = 0; i < ass.GetAssingeeJobsNumberInt; i++)
                    {
                        asob.assigneesJobsList.RemoveAt(0);
                    }
                    
                    Console.WriteLine(ass.GetAssigneeName + " " + ass.GetAssingeeJobsNumberInt);
                }
                
                foreach(var ass in listOfStatusAssgineeInfo)
                {
                    Console.WriteLine(ass.jobName + " " + ass.reviewerName + " " + ass.sourceLanguage);
                }

                asob = new AssigneesAndJobs(driver);
                asob.TagMultipleJobs(driver, 0, asob.GetAssigneeJobsListSize - 1);

                ViewsMenu assigneesViewsMenu = new ViewsMenu(driver);
                assigneesViewsMenu.JobsView.ButtonClick();

                JobsSectionJobs jsj = new JobsSectionJobs(driver);

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                ResultJob auxiliaryJobs = new ResultJob();
                IWebElement jobsResultsContainer;

                IJavaScriptExecutor jse;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "TestFile.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {

                    foreach (var info in listOfStatusAssgineeInfo)
                    {

                        jse = (IJavaScriptExecutor)driver;
                        jse.ExecuteScript("arguments[0].scrollIntoView();", jsj.GetJobElement(driver, info.jobName));

                        jsj.ShowHistoryOfJob(driver, info.jobName);

                        JobHistoryFilter filter = new JobHistoryFilter(driver);

                        filter.FiltersPanelInitialization(driver);
                        filter.ChosenActivityClick(driver, "Translation");

                        filter = new JobHistoryFilter(driver);
                        filter.FiltersPanelInitialization(driver);

                        filter.SourceLanguageFilterClick(driver);
                        filter.ChosenSourceLanguageClick(driver, info.sourceLanguage);

                        filter = new JobHistoryFilter(driver);
                        filter.FiltersPanelInitialization(driver);

                        filter.TargetLanguageFilterClick(driver);
                        filter.ChosenTargetLanguageClick(driver, info.targetLanguage);

                        wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("r_L")));
                        auxiliaryCollection = driver.FindElements(By.Id("pup_avw"));

                        jobsResultsContainer = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = jobsResultsContainer.FindElements(By.ClassName("r_L"));
                        auxiliaryJobs = new ResultJob(auxiliaryCollection.ElementAt(0));

                        listOfStatusAssgineeInfo.ElementAt(listOfStatusAssgineeInfo.IndexOf(info)).TranslatorName = auxiliaryJobs.GetTranlatorName;

                        PopUpBody popuPBody = new PopUpBody(driver);
                        popuPBody.CloseButtonClick(driver);

                        string[] values = { info.jobName, info.reviewerName, info.translatorName, info.sourceLanguage, info.targetLanguage };
                        string line = String.Join(";", values);

                        sw.WriteLine(line);
                    }

                    sw.Flush();
                }

               
                    // iterates over the users
                    //foreach (var info in listOfStatusAssgineeInfo)
                 //   {
                        // creates an array of the user's values
                      //  string[] values = { info.jobName, info.reviewerName, info.translatorName, info.sourceLanguage, info.targetLanguage };
                        // creates a new line
                     //   string line = String.Join(";", values);
                        // writes the line
                       // sw.WriteLine(line);
                  //  }
                    // flushes the buffer
                   // sw.Flush();
              //  }
            }
        }
    }
}
