using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Lists.List_Objects;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_Home_Page_Elements;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Lists
{
    public class JobList
    {
        /* Fields */

        private IWebElement listContainer;

        List<JobsItem> jobsItemsList;

        private PageNavBar pageNavBar;

        private JobsListMenu jobsListMenu;

        /* Properties */

        public List<JobsItem> JobsItemsList
        {
            get
            {
                return jobsItemsList;
            }
        }

        public int JobsItemsListCount
        {
            get
            {
                return jobsItemsList.Count;
            }
        }

        public PageNavBar PageNavBar
        {
            get
            {
                return pageNavBar;
            }
        }

        /* Methods */

        public void SelectSingleJob(IWebDriver driver, int jobNumber)
        {
            if (jobsItemsList.Count != 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                jobsItemsList.ElementAt(jobNumber).JobsJobClick(driver);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                jobsListMenu = new JobsListMenu(driver);
            }
        }

        public void SelectSingleJob(IWebDriver driver, string jobName)
        {
            if (jobsItemsList.Count != 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                jobsItemsList.Find(x => x.JobsJobName == jobName).JobsJobClick(driver);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                jobsListMenu = new JobsListMenu(driver);
            }
        }

        public void TagSingleJob(IWebDriver driver, int jobNumber)
        {
            if (jobsItemsList.Count != 0)
            {
                SelectSingleJob(driver, jobNumber);
                jobsListMenu.ClickTagJobs();
            }
        }

        public void JobShowHistory(IWebDriver driver, int jobNumber)
        {
            SelectSingleJob(driver, jobNumber);
            jobsListMenu.ClickShowHistory();
        }

        public void JobShowHistory(IWebDriver driver, string jobName)
        {
            SelectSingleJob(driver, jobName);
            jobsListMenu.ClickShowHistory();
        }

        /*public void SelectMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (AssigneesJobsListIsEmpty == false && rangeEnd <= assigneesJobsList.Count)
            {
                if (assigneesJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && assigneesJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    Actions selectingMultipleItems = new Actions(driver);

                    selectingMultipleItems.Click(assigneesJobsList.ElementAt(rangeStart).GetJobButton)
                    .KeyDown(Keys.Shift)
                    .Click(driver.FindElement(By.ClassName("r_GH")))
                    .MoveToElement(assigneesJobsList.ElementAt(rangeEnd).GetJobButton)
                    .Click(assigneesJobsList.ElementAt(rangeEnd).GetJobButton)
                    .Build()
                    .Perform();

                    assigneeJobMenu = new AssingeesOnClickJobsMenu(driver);
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
        }*/


        /* Constructors */

        public JobList(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.ClassName("r_GH"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("List container was not found on the page or multiple were found."));

            listContainer = auxiliaryCollection.ElementAt(0);

            jobsItemsList = new List<JobsItem>();

            auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));

            foreach (IWebElement headerObject in auxiliaryCollection)
            {
                jobsItemsList.Add(new JobsItem(headerObject));
            }
        }
    }
}
