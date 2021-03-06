﻿using OpenQA.Selenium;
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


                string projectTitle = ""; // Project Name
                string firstStepName = "InternalReview";

                Console.WriteLine("Hi, please chose TMS project name: \n" +
                                  "1) Porsche BAL 2.0 \n" +
                                  "2) Porsche Cosima");

                int projectChose = Int32.Parse(Console.ReadLine());

                switch(projectChose)
                {
                    case 1:
                        projectTitle = "Porsche BAL 2.0";
                        break;
                    case 2: 
                        projectTitle = "Porsche Cosima";
                        break;
                    default:
                        System.Environment.Exit(1);
                        break;
                }

                Console.WriteLine("Now, please chose TMS setting name: \n" +
                                  "1) Internal Review; " +
                                  "2) Editing");

                int settingChose = Int32.Parse(Console.ReadLine());

                switch(settingChose)
                {
                    case 1:
                        firstStepName = "InternalReview";
                        break;
                    case 2:
                        firstStepName = "Editing";
                        break;
                    default:
                        System.Environment.Exit(1);
                        break;
                }

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                ProjectsPage testPage = new ProjectsPage(driver, projectTitle);

                testPage.ClickChosenProject();
                ParticularProjectPage testProjectPage = new ParticularProjectPage(driver);

                testProjectPage.ProfileClick(driver);
                testProjectPage.ChangeItemsPerPageMin(driver);

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

                List<StatusAssigneeInfo> listOfStatusAssgineeInfo = new List<StatusAssigneeInfo>();
                StatusAssigneeInfo auxiliary;

                foreach(var ass in asob.assigneesJobsList)
                {
                    Console.WriteLine(ass.GetJobsName);
                }


                foreach (Assignee ass in asob.assigneesList)
                {
                    for (int i = 0; i < ass.GetAssingeeJobsNumberInt; i++)
                    {
                        auxiliary = new StatusAssigneeInfo(ass, asob.assigneesJobsList.ElementAt(i));
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
                jsj.jobsPageBar.ItemsPerPageSetMaximalValue(driver);

                jsj = new JobsSectionJobs(driver);

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                ResultJob auxiliaryJobs = new ResultJob();
                IWebElement jobsResultsContainer;

                IJavaScriptExecutor jse;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "TestFile.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    string[] values1 = { "Job Name", "Reviewer Name", "Translator Name", "Source Language", "Target Language", "Effort", "Wordcount" };
                    string line1 = String.Join(";", values1);

                    sw.WriteLine(line1);

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

                        string[] values = { info.jobName, info.reviewerName, info.translatorName, info.sourceLanguage, info.targetLanguage, info.effort, info.wordcount };
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
