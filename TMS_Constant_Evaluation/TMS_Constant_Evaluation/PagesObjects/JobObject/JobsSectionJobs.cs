using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.Pages.PagesObjects;
using TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects;
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;

namespace TMS_Constant_Evaluation.PagesObjects.JobObject
{
    public class JobsSectionJobs
    {

        /* Fields */

        private IWebElement jobsResultsContainer;
        public List<Jobs> jobsList = new List<Jobs>();

        private PageBar jobsPageBar;
        private JobsOnClickJobsMenu jobMenu;

        /* Properties */

        public bool JobsListIsEmpty
        {
            get
            {
                if (jobsList.Count != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int GetJobsListSize
        {
            get
            {
                if (JobsListIsEmpty == false)
                {
                    return jobsList.Count;
                }
                else
                {
                    return -1;
                }
            }
        }

        public List<string> GetListOfJobNames
        {
            get
            {
                List<string> jobNameList = new List<string>();

                if (JobsListIsEmpty == false)
                {
                    foreach (Jobs job in jobsList)
                    {
                        jobNameList.Add(job.GetJobsName);
                    }

                    return jobNameList;
                }
                else
                {
                    return jobNameList;
                }
            }
        }

        public bool PageBarIsNull
        {
            get
            {
                if (jobsPageBar.PageBarContainerIsNull == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                if (JobsListIsEmpty == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /* Methods */

        public void SelectSingleJob(IWebDriver driver, int jobNumber)
        {
            if (AssigneesJobsListIsEmpty == false)
            {
                if (jobsList.ElementAt(jobNumber).JobsButtonIsEnabled == 1)
                {
                    jobsPageBar = null;
                    jobsList.ElementAt(jobNumber).AssigneeJobButtonClick(driver);
                    jobMenu = new JobsOnClickJobsMenu(driver);
                }
            }
        }

        public void TagSingleJob(IWebDriver driver, int jobNumber)
        {
            if (AssigneesJobsListIsEmpty == false)
            {
                if (jobsList.ElementAt(jobNumber).JobsButtonIsEnabled == 1)
                {
                    SelectSingleJob(driver, jobNumber);
                    jobMenu.ClickTagJobsButton(driver);
                }
            }
        }

        public void SelectMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (AssigneesJobsListIsEmpty == false && rangeEnd <= jobsList.Count)
            {
                if (jobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && jobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    Actions selectingMultipleItems = new Actions(driver);

                    selectingMultipleItems.Click(jobsList.ElementAt(rangeStart).GetJobButton)
                    .KeyDown(Keys.Shift)
                    .Click(driver.FindElement(By.ClassName("r_GH")))
                    .MoveToElement(jobsList.ElementAt(rangeEnd).GetJobButton)
                    .Click(jobsList.ElementAt(rangeEnd).GetJobButton)
                    .Build()
                    .Perform();

                    jobMenu = new JobsOnClickJobsMenu(driver);
                }
            }
        }

        public void TagMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (AssigneesJobsListIsEmpty == false && rangeEnd <= jobsList.Count)
            {
                if (jobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && jobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    SelectMultipleJobs(driver, rangeStart, rangeEnd);
                    jobMenu.ClickTagJobsButton(driver);
                }
            }
        }


        /* Constructors */

        public JobsSectionJobs(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                Jobs auxiliaryJobs;

                auxiliaryCollection = driver.FindElements(By.ClassName("r_GH"));
                if (auxiliaryCollection.Count == 1)
                {
                    jobsResultsContainer = auxiliaryCollection.ElementAt(0);

                    jobsPageBar = new PageBar(driver);

                    auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));
                    if (auxiliaryCollection.Count > 0)
                    {
                        foreach (IWebElement element in auxiliaryCollection)
                        {
                            auxiliaryJobs = new Jobs(element);
                            if (auxiliaryJobs.IsParsingCorrect) jobsList.Add(auxiliaryJobs);
                        }
                    }

                }
            }
        }

    }
}
