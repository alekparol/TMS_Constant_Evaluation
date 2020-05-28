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
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.Pages
{
    public class AssigneesPage
    {

        /* Fields */

        private IWebElement searchField;
        private IWebElement searchButton;

        private IWebElement viewBar;
        private IWebElement assigneesSubPage;

        private IWebElement filtersButton;
        private bool isFilterClicked;

        private IWebElement activityFilter;

        private IReadOnlyCollection<IWebElement> r_LHObjects;
        private List<Assignees> assingeesList;

        private IReadOnlyCollection<IWebElement> r_LObjects;
        private List<AssigneesJobs> assigneesJobsList;

        private PageBar assigneesPageBar;


        /* Properties */

        /* Methods */

        /*public List<AssigneesObject> GetAllAssignees(IWebDriver driver)
        {

            List<AssigneesObject> auxiliaryAssigneesObjectList = new List<AssigneesObject>();

            if (assingeesList.Count > 0 && assigneesJobsList.Count > 0)
            {
                if (assigneesPageBar.IfPageBarExists)
                {
                    while(assigneesPageBar.IfLastPage != 0)
                    {
                        assigneesPageBar.GoToNextPage(driver);


                    }
                }
                Here will be initialization for the list
            }
            else
            {
                return auxiliaryAssigneesObjectList;
            }
        }*/

        /* Constructors */

        public AssigneesPage(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

            auxiliaryCollection = driver.FindElements(By.Id("sjid"));
            if (auxiliaryCollection.Count > 0) searchField = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("sjib"));
            if (auxiliaryCollection.Count > 0) searchButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_vws"));
            if (auxiliaryCollection.Count > 0) viewBar = auxiliaryCollection.ElementAt(0);

            if (viewBar != null)
            {

                auxiliaryCollection = driver.FindElements(By.Id("statusassignees"));
                if (auxiliaryCollection.Count > 0) assigneesSubPage = auxiliaryCollection.ElementAt(0);

            }

            auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
            if (auxiliaryCollection.Count > 0) filtersButton = auxiliaryCollection.ElementAt(0);

            if (filtersButton != null)
            {

                string auxiliaryString = filtersButton.GetAttribute("class");
                if (auxiliaryString.Contains("icn_flt_on")) isFilterClicked = true;

            }

            if(isFilterClicked == false)
            {
                filtersButton.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fp")));

            }

            auxiliaryCollection = driver.FindElements(By.Id("cup_fpStepActivityName_msdd"));
            if (auxiliaryCollection.Count > 0) activityFilter = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.ClassName("r_LH"));
            if (auxiliaryCollection.Count > 0) r_LHObjects = auxiliaryCollection;

            assigneesPageBar = new PageBar(driver);

            assingeesList = new List<Assignees>();
            Assignees auxiliaryAssignee;

            foreach(IWebElement element in r_LHObjects)
            {

                auxiliaryAssignee = new Assignees(element);

                if (auxiliaryAssignee.IsParsingCorrect)
                {
                    assingeesList.Add(auxiliaryAssignee);
                }

            }

            auxiliaryCollection = driver.FindElements(By.ClassName("r_L"));
            if (auxiliaryCollection.Count > 0) r_LObjects = auxiliaryCollection;

            AssigneesJobs auxiliaryAssigneesJob;

            foreach (IWebElement element in r_LObjects)
            {

                auxiliaryAssigneesJob = new AssigneesJobs(element);

                if (auxiliaryAssigneesJob.IsParsingCorrect)
                {
                    assigneesJobsList.Add(auxiliaryAssigneesJob);
                }

            }


        }

    }
}
