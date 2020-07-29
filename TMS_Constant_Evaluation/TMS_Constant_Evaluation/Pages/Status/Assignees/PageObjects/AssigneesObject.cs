using OpenQA.Selenium;
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

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class AssigneesObject
    {

        /* Fields */

        public List<Assignee> assigneesList = new List<Assignee>();
        public List<AssigneeJobs> assigneesJobsList = new List<AssigneeJobs>();

        private PageBar assigneePageBar;

        private bool isParsedCorrectly;

        /* Properties */

        public int AssigneesListSize
        {
            get
            {
                return assigneesList.Count;
            }
        }

        public int AssigneeJobsListSize
        {
            get
            {
                return assigneesJobsList.Count;
            }
        }

        public List<string> AssigneesJobNames
        {
            get
            {
                List<string> auxiliaryList = new List<string>();

                foreach(AssigneeJobs job in assigneesJobsList)
                {
                    auxiliaryList.Add(job.GetJobsName );
                }

                return auxiliaryList;
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        /* Methods */

        /* Constructors */

        /* I think the process should be like that: 
         * 1. We get the whole list of assignees on the internal review page. 
         * 2. We get the whole list of the assignees jobs on the internal review page. 
         * 3. We go through the assignees list and create an AssigneesObject for each element - passing jobs numbers we get the list of the assignees 
         * jobs containing the jobs from the whole list of jobs from 0 to number of jobs for this assignee - 1. 
         * 4. We delete the jobs assigneed for the assignee from the list. 
         * 5. We do it until the list of assignees is on the end and list of jobs.count == 0. 
         * 
         * 
         * 
         **/
        public AssigneesObject(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                Assignee auxiliaryAssignee;
                AssigneeJobs auxiliaryAssigneeJobs;

                wait.Until(ExpectedConditions.ElementExists(By.ClassName("r_LH")));

                assigneePageBar = new PageBar(driver);
                if (assigneePageBar.IsParsingCorrect && assigneePageBar.PageNavigationContainerIsNull == 0)
                {

                    isParsedCorrectly = true;

                    while (true)
                    {
                        if (wait.Until(ExpectedConditions.ElementExists(By.ClassName("r_LH"))) != null)
                        {

                            auxiliaryCollection = driver.FindElements(By.ClassName("r_LH"));
                            if (auxiliaryCollection.Count > 0)
                            {
                                foreach (IWebElement element in auxiliaryCollection)
                                {
                                    auxiliaryAssignee = new Assignee(element);
                                    if (auxiliaryAssignee.IsParsingCorrect) assigneesList.Add(auxiliaryAssignee);
                                }
                            }

                            auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));
                            if (auxiliaryCollection.Count > 0)
                            {
                                foreach (IWebElement element in auxiliaryCollection)
                                {
                                    auxiliaryAssigneeJobs = new AssigneeJobs(element);
                                    if (auxiliaryAssigneeJobs.IsParsingCorrect) assigneesJobsList.Add(auxiliaryAssigneeJobs);
                                }
                            }

                            if(assigneePageBar.NextPageIsNull == 0)
                            {
                                break;
                            }
                            else
                            {
                                assigneePageBar.GoToNextPage(driver);
                            }
                            

                            assigneePageBar = new PageBar(driver);

                        }
                    }
                }
            }
        }
    }
}
