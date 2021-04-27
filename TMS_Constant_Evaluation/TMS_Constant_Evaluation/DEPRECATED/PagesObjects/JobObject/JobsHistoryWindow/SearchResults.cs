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

namespace TMS_Constant_Evaluation.PagesObjects.JobObject.JobsHistoryWindow
{
    public class SearchResults
    {
        /* Fields */

        private IWebElement jobsResultsContainer;
        public List<ResultJob> jobsList = new List<ResultJob>();

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

        public List<string> GetListOfTranslatorNames
        {
            get
            {
                List<string> jobTranslatorList = new List<string>();

                if (JobsListIsEmpty == false)
                {
                    foreach (ResultJob job in jobsList)
                    {
                        jobTranslatorList.Add(job.GetTranlatorName);
                    }

                    return jobTranslatorList;
                }
                else
                {
                    return jobTranslatorList;
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

        /* Constructors */

        public SearchResults(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                ResultJob auxiliaryJobs = new ResultJob();
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("r_L")));

                auxiliaryCollection = driver.FindElements(By.Id("pup_avw"));
                if (auxiliaryCollection.Count == 1)
                {
                    jobsResultsContainer = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));
                    if (auxiliaryCollection.Count > 0)
                    {
                        foreach (IWebElement element in auxiliaryCollection)
                        {
                            auxiliaryJobs = new ResultJob(element);
                            jobsList.Add(auxiliaryJobs);
                        }
                    }

                }
            }
        }
    }
}
