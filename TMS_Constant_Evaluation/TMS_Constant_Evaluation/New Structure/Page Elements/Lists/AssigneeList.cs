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
    public class AssigneeList
    {
        /* Fields */

        private IWebElement listContainer;

        List<AssigneeItem> assigneeItemsList;

        private PageNavBar pageNavBar;

        private AssigneeListMenu assigneeListMenu;

        /* Properties */

        public List<AssigneeItem> AssigneeItemsList
        {
            get
            {
                return assigneeItemsList;
            }
        }

        public int AssigneeItemsListCount
        {
            get
            {
                return assigneeItemsList.Count;
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

        public string GetJobSourceLanguage(int jobNumber)
        {
            return assigneeItemsList.ElementAt(jobNumber).AssigneeItemElements[0].AssingeeJobsSourceLanguage;
        }

        public string GetJobTargetLanguage(int jobNumber)
        {
            return assigneeItemsList.ElementAt(jobNumber).AssigneeItemElements[0].AssingeeJobsTargetLanguage;
        }

        public void SelectSingleJob(IWebDriver driver, int jobNumber)
        {
            if (assigneeItemsList.Count != 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                assigneeItemsList.ElementAt(jobNumber).AssigneeItemElements[0].AssigneeJobClick(driver);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                assigneeListMenu = new AssigneeListMenu(driver);
            }
        }

        public void TagSingleJob(IWebDriver driver, int jobNumber)
        {
            if (assigneeItemsList.Count != 0)
            {
                SelectSingleJob(driver, jobNumber);
                assigneeListMenu.ClickTagJobs();
            }
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

        public AssigneeList(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.ClassName("r_GH"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("List container was not found on the page or multiple were found."));

            listContainer = auxiliaryCollection.ElementAt(0);

            assigneeItemsList = new List<AssigneeItem>();

            auxiliaryCollection = driver.FindElements(By.ClassName("r_LH"));

            foreach(IWebElement headerObject in auxiliaryCollection)
            {
                IReadOnlyCollection<IWebElement> followingHeaders = headerObject.FindElements(By.XPath("(.//following-sibling::tr[@class=\"r_LH\"])[1]"));
                if (followingHeaders.Count == 1)
                {
                    IReadOnlyCollection<IWebElement> followingSiblings = headerObject.FindElements(By.XPath(".//following-sibling::tr[@class=\"r_L\"]"));
                    IReadOnlyCollection<IWebElement> previousSiblings = followingHeaders.ElementAt(0).FindElements(By.XPath(".//preceding-sibling::tr[@class=\"r_L\"]"));
                    List<IWebElement> jobs = followingSiblings.AsQueryable().Intersect(previousSiblings).ToList();

                    assigneeItemsList.Add(new AssigneeItem(headerObject, jobs));
                }
                else if (followingHeaders.Count == 0) 
                {
                    IReadOnlyCollection<IWebElement> followingSiblings = headerObject.FindElements(By.XPath(".//following-sibling::tr[@class=\"r_L\"]"));
                    List<IWebElement> jobs = followingSiblings.ToList();

                    assigneeItemsList.Add(new AssigneeItem(headerObject, jobs));
                }              
            }
        }
    }
}
