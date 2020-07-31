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


/* I think the process should be like that: 
 * 1. We get the whole list of assignees on the internal review page. 
 * 2. We get the whole list of the assignees jobs on the internal review page. 
 * 3. We go through the assignees list and create an AssigneesAndJobs for each element - passing jobs numbers we get the list of the assignees 
 * jobs containing the jobs from the whole list of jobs from 0 to number of jobs for this assignee - 1. 
 * 4. We delete the jobs assigneed for the assignee from the list. 
 * 5. We do it until the list of assignees is on the end and list of jobs.count == 0. 
 * 
 * 
 * 
 **/
namespace TMS_Constant_Evaluation.PagesObjects.AssigneeObject
{
    public class AssigneesAndJobs
    {

        /* Fields */

        public List<Assignee> assigneesList = new List<Assignee>();
        public List<AssigneeJobs> assigneesJobsList = new List<AssigneeJobs>();

        private PageBar assigneePageBar;
        private int numberOfPages;

        private OnClickJobsMenu assigneeJobMenu;

        /* Properties */

        public bool AssigneesListIsEmpty
        {
            get
            {
                if (assigneesList.Count != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int GetAssigneesListSize
        {
            get
            {
                if (AssigneesListIsEmpty == false)
                {
                    return assigneesList.Count;
                }
                else
                {
                    return -1;
                }
            }
        }

        public bool AssigneesJobsListIsEmpty
        {
            get
            {
                if (assigneesJobsList.Count != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int GetAssigneeJobsListSize
        {
            get
            {
                if (AssigneesJobsListIsEmpty == false)
                {
                    return assigneesJobsList.Count;
                }
                else
                {
                    return -1;
                }
            }
        }

        public List<string> GetListOfAssigneeNames
        {
            get
            {
                List<string> assigneeNames = new List<string>();

                if (AssigneesListIsEmpty == false)
                {
                    foreach(Assignee assignee in assigneesList)
                    {
                        assigneeNames.Add(assignee.GetAssigneeName);
                    }

                    return assigneeNames;
                }
                else
                {
                    return assigneeNames;
                }
            }
        }

        public List<string> GetListOfJobsSourceLanguages
        {
            get
            {
                List<string> differentLanguagesList = new List<string>();

                if (AssigneesJobsListIsEmpty == false)
                {
                    IOrderedEnumerable<AssigneeJobs> assigneesJobsOrdered = assigneesJobsList.OrderBy(x => x.GetSourceLanguage);
                    IEnumerable<AssigneeJobs> auxiliaryEnumerable;

                    string auxiliaryString;
                    int auxiliaryInt = 0;

                    while (auxiliaryInt < GetAssigneesListSize)
                    {
                        auxiliaryString = assigneesJobsOrdered.ElementAt(auxiliaryInt).GetSourceLanguage;
                        if (auxiliaryString != "" && auxiliaryString != null)
                        {
                            differentLanguagesList.Add(auxiliaryString);
                        }

                        auxiliaryEnumerable = assigneesJobsList.Where(x => x.GetSourceLanguage == auxiliaryString);
                        auxiliaryInt += auxiliaryEnumerable.Count();
                    }

                    return differentLanguagesList;
                }
                else
                {
                    return differentLanguagesList;
                }
            }
        }

        public List<string> GetListOfJobsTargetLanguages
        {
            get
            {
                List<string> differentLanguagesList = new List<string>();

                if (AssigneesJobsListIsEmpty == false)
                {
                    IOrderedEnumerable<AssigneeJobs> assigneesJobsOrdered = assigneesJobsList.OrderBy(x => x.GetTargetLanguage);
                    IEnumerable<AssigneeJobs> auxiliaryEnumerable;

                    string auxiliaryString;
                    int auxiliaryInt = 0;

                    while (auxiliaryInt < GetAssigneesListSize)
                    {
                        auxiliaryString = assigneesJobsOrdered.ElementAt(auxiliaryInt).GetTargetLanguage;
                        if (auxiliaryString != "" && auxiliaryString != null)
                        {
                            differentLanguagesList.Add(auxiliaryString);
                        }

                        auxiliaryEnumerable = assigneesJobsList.Where(x => x.GetTargetLanguage == auxiliaryString);
                        auxiliaryInt += auxiliaryEnumerable.Count();
                    }

                    return differentLanguagesList;
                }
                else
                {
                    return differentLanguagesList;
                }
            }
        }

        public bool PageBarIsNull
        {
            get
            {
                if (assigneePageBar.PageBarContainerIsNull == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public List<string> GetAssigneesJobNames
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
                return true;
                //return isParsedCorrectly;
            }
        }

        /* Methods */

        public void SelectSingleJob(IWebDriver driver, int jobNumber)
        {
            //if (AssigneesJobsListIsEmpty == false)
            //{
                //if (assigneesJobsList.ElementAt(jobNumber).JobsButtonIsEnabled == 1)
                //{
                    assigneesJobsList.ElementAt(jobNumber).AssigneeJobButtonClick(driver);
                    assigneeJobMenu = new OnClickJobsMenu(driver);
                //}
            //}
        }

        public void TagSingleJob(IWebDriver driver, int jobNumber)
        {
            //if (AssigneesJobsListIsEmpty == false)
            //{
               // if (assigneesJobsList.ElementAt(jobNumber).JobsButtonIsEnabled == 1)
                //{
                    SelectSingleJob(driver, jobNumber);
                    assigneeJobMenu.ClickTagJobsButton(driver);
                //}
            //}
        }

        public void SelectMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (AssigneesJobsListIsEmpty == false && rangeEnd <= assigneesJobsList.Count)
            {
                if (assigneesJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && assigneesJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    Actions selectingMultipleItems = new Actions(driver);

                    selectingMultipleItems.Click(assigneesJobsList.ElementAt(rangeStart).GetJobButton)
                    .KeyDown(Keys.Shift)
                    .MoveToElement(assigneesJobsList.ElementAt(rangeEnd).GetJobButton)
                    .Click(assigneesJobsList.ElementAt(rangeEnd).GetJobButton)
                    .Build()
                    .Perform();

                    assigneeJobMenu = new OnClickJobsMenu(driver);
                }
            }
        }

        public void TagMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (AssigneesJobsListIsEmpty == false && rangeEnd <= assigneesJobsList.Count)
            {
                if (assigneesJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && assigneesJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    SelectMultipleJobs(driver, rangeStart, rangeEnd);
                    assigneeJobMenu.ClickTagJobsButton(driver);
                }
            }
        }


        /* Constructors */

        public AssigneesAndJobs(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                Assignee auxiliaryAssignee;
                AssigneeJobs auxiliaryAssigneeJobs;

                //while (true)
                //{
                   // numberOfPages++;

                    //wait.Until(ExpectedConditions.ElementExists(By.ClassName("r_LH")));
                    //assigneePageBar = new PageBar(driver);

                    //if (assigneePageBar.CurrentPageIsFirst == 1)
                   // {
                    //    assigneePageBar.ItemsPerPageSetMaximalValue(driver);
                   // }

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

                    //if (assigneePageBar.NextPageIsNull == 0)
                    //{
                    //    break;
                    //}
                    //else
                   // {
                   ///     assigneePageBar.GoToNextPage(driver);
                   //// }
               // }
            }
        }
    }
}
