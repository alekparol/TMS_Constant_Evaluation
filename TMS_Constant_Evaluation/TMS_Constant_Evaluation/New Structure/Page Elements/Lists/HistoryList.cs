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
    public class HistoryList
    {
        /* Fields */

        private IWebElement listContainer;

        List<HistoryItem> historyItemsList;

        private PageNavBar pageNavBar;

        /* Properties */

        public List<HistoryItem> HistoryItemsList
        {
            get
            {
                return historyItemsList;
            }
        }

        public int HistoryItemsListCount
        {
            get
            {
                return historyItemsList.Count;
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

        /*public void SelectSingleJob(IWebDriver driver, int jobNumber)
        {
            if (historyItemsList.Count != 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                historyItemsList.ElementAt(jobNumber).HistoryItemElements[0].HistoryJobClick(driver);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                historyListMenu = new HistoryListMenu(driver);
            }
        }

        public void TagSingleJob(IWebDriver driver, int jobNumber)
        {
            if (historyItemsList.Count != 0)
            {
                SelectSingleJob(driver, jobNumber);
                historyListMenu.ClickTagJobs();
            }
        }*/

        /*public void SelectMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (HistorysJobsListIsEmpty == false && rangeEnd <= historysJobsList.Count)
            {
                if (historysJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && historysJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    Actions selectingMultipleItems = new Actions(driver);

                    selectingMultipleItems.Click(historysJobsList.ElementAt(rangeStart).GetJobButton)
                    .KeyDown(Keys.Shift)
                    .Click(driver.FindElement(By.ClassName("r_GH")))
                    .MoveToElement(historysJobsList.ElementAt(rangeEnd).GetJobButton)
                    .Click(historysJobsList.ElementAt(rangeEnd).GetJobButton)
                    .Build()
                    .Perform();

                    historyJobMenu = new AssingeesOnClickJobsMenu(driver);
                }
            }
        }

        public void TagMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (HistorysJobsListIsEmpty == false && rangeEnd <= historysJobsList.Count)
            {
                if (historysJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && historysJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    SelectMultipleJobs(driver, rangeStart, rangeEnd);
                    historyJobMenu.ClickTagJobsButton(driver);
                }
            }
        }*/


        /* Constructors */

        public HistoryList(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@id=\"pup\"]//tr[@class=\"r_GH\"]"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("List container was not found on the page or multiple were found."));

            listContainer = auxiliaryCollection.ElementAt(0);

            historyItemsList = new List<HistoryItem>();

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@id=\"pup_bdp\"]//tr[@class=\"r_LH\"]"));

            foreach (IWebElement headerObject in auxiliaryCollection)
            {
                IReadOnlyCollection<IWebElement> followingHeaders = headerObject.FindElements(By.XPath("(.//following-sibling::tr[@class=\"r_LH\"])[1]"));
                if (followingHeaders.Count == 1)
                {
                    IReadOnlyCollection<IWebElement> followingSiblings = headerObject.FindElements(By.XPath(".//following-sibling::tr[@class=\"r_L\"]"));
                    IReadOnlyCollection<IWebElement> previousSiblings = followingHeaders.ElementAt(0).FindElements(By.XPath(".//preceding-sibling::tr[@class=\"r_L\"]"));
                    List<IWebElement> jobs = followingSiblings.AsQueryable().Intersect(previousSiblings).ToList();

                    historyItemsList.Add(new HistoryItem(headerObject, jobs));
                }
                else if (followingHeaders.Count == 0)
                {
                    IReadOnlyCollection<IWebElement> followingSiblings = headerObject.FindElements(By.XPath(".//following-sibling::tr[@class=\"r_L\"]"));
                    List<IWebElement> jobs = followingSiblings.ToList();

                    historyItemsList.Add(new HistoryItem(headerObject, jobs));
                }
            }
        }
    }
}
