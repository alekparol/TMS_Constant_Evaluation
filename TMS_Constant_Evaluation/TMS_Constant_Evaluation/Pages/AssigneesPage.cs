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

/*
 * This class mean to model TMS Assignees Page which is displayed on all of the pages on the top of the screen. 
 * 
 * Preassumptions: 
 * 
 * TODO: 
 * 
 */
namespace TMS_Constant_Evaluation.Pages
{
    public class AssigneesPage
    {

        /* Fields */

        private StatusNavigationBar assigneeNavigationBar;
        private StatusFilters assigneeFilters;

        private IWebElement pageName;

        private IWebElement viewBar;
        private IWebElement activitiesSubpageButton;
        private IWebElement assigneesSubpageButton;

        private IWebElement filtersButton;
        private bool isFilterClicked; // TODO; Add this element to every page which contains Filter button. 

        private IWebElement activityFilter; // TODO: Create a class for modelling every dropdown menu in the filter bar.

        /* Those two elements are displayed on every page after particular project page. 
         * TODO: Add them to some class which from they could be inherited.*/
        private IWebElement searchField;
        private IWebElement searchButton;

        private AssigneesObject assigneesObjects;
        private bool isParsedCorrectly;


        /* Properties */

        public string GetPageName
        {
            get
            {
                return assigneeNavigationBar.GetPageName;
            }
        }

        public int IsActivitiesSelected
        {
            get
            {
                return assigneeNavigationBar.ActivitiesSubpageIsClicked;
            }
        }

        public int IsAssigneesSelected
        {
            get
            {
                return assigneeNavigationBar.AssigneesSubpageIsClicked;
            }
        }

        public int ActivitiesFilterIsExpanded
        {
            get
            {
                return assigneeFilters.ActivitiesFilterIsExpanded;
            }
        }

        public string ActivitiesFilterSelection
        {
            get
            {
                return assigneeFilters.ActivitiesFilterSelection;
            }
        }

        public int LanguagesFilterIsExpanded
        {
            get
            {
                return assigneeFilters.LanguagesFilterIsExpanded;
            }
        }

        public string LanguagesFilterSelection
        {
            get
            {
                return assigneeFilters.LanguageFilterSelection;
            }
        }

        public int AllButtonIsClicked
        {
            get
            {
                return assigneeFilters.ShowAllButtonIsClicked;
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                if (assigneeNavigationBar != null && assigneeFilters != null)
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

        public void ActivitiesClick(IWebDriver driver)
        {
            assigneeNavigationBar.ActivitiesClick(driver);
        }

        public void AssigneesClick(IWebDriver driver)
        {
            assigneeNavigationBar.AssigneesClick(driver);
        }

        public void ActivitiesFilterClick(IWebDriver driver)
        {
            assigneeFilters.FiltersPanelInitialization(driver);
            assigneeFilters.ActivitiesFilterClick(driver);

            assigneeNavigationBar = new StatusNavigationBar(driver);
        }

        public void ChosenActivityClick(IWebDriver driver, string chosenActivityName)
        {
            ActivitiesFilterClick(driver);
            assigneeFilters.ChosenActivityClick(driver, chosenActivityName);

            assigneeNavigationBar = new StatusNavigationBar(driver);
            assigneeFilters = new StatusFilters(driver);
        }

        public void LanguageFilterClick(IWebDriver driver)
        {
            assigneeFilters.FiltersPanelInitialization(driver);
            assigneeFilters.LanguageFilterClick(driver);

            assigneeNavigationBar = new StatusNavigationBar(driver);
        }

        public void ChosenTargetLanguageClick(IWebDriver driver, string chosenLanguageCode)
        {
            LanguageFilterClick(driver);
            assigneeFilters.ChosenTargetLanguageClick(driver, chosenLanguageCode);

            assigneeNavigationBar = new StatusNavigationBar(driver);
            assigneeFilters = new StatusFilters(driver);
        }

        public void ClickAll(IWebDriver driver)
        {
            assigneeFilters.ClickAll(driver);

            assigneeNavigationBar = new StatusNavigationBar(driver);
            assigneeFilters = new StatusFilters(driver);
        }

        public List<string> GetJobNames(IWebDriver driver)
        {
           
            assigneesObjects = new AssigneesObject(driver);
            return assigneesObjects.AssigneesJobNames;

        }

        public void SearchJobByName(string jobName, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            searchField.SendKeys(jobName);
            searchButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }


        /* Constructors */

        public AssigneesPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                string auxiliaryString;

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn"))) != null)
                {

                    isParsedCorrectly = true;

                    auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));
                    if (auxiliaryCollection.Count > 0) pageName = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_vws"));
                    if (auxiliaryCollection.Count > 0) viewBar = auxiliaryCollection.ElementAt(0);

                    if (viewBar != null)
                    {

                        auxiliaryCollection = viewBar.FindElements(By.Id("status"));
                        if (auxiliaryCollection.Count > 0) activitiesSubpageButton = auxiliaryCollection.Where(x => x.Text == "Activities").First();

                        auxiliaryCollection = viewBar.FindElements(By.Id("statusassignees"));
                        if (auxiliaryCollection.Count > 0) assigneesSubpageButton = auxiliaryCollection.ElementAt(0);

                    }

                    auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
                    if (auxiliaryCollection.Count > 0) filtersButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryString = filtersButton.GetAttribute("class");
                    if (auxiliaryString.Contains("icn_flt_on")) isFilterClicked = true;

                    if (isFilterClicked == false)
                    {

                        filtersButton.Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fpName_msdd")));

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpName_msdd"));
                        if (auxiliaryCollection.Count == 1) activityFilter = auxiliaryCollection.ElementAt(0);

                    }

                    auxiliaryCollection = driver.FindElements(By.Id("sjid"));
                    if (auxiliaryCollection.Count == 1) searchField = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("sjib"));
                    if (auxiliaryCollection.Count == 1) searchButton = auxiliaryCollection.ElementAt(0);

                }
            }
        }
        
        /*
        private IWebElement pageName;

        private IWebElement viewBar;
        private IWebElement activitiesSubpageButton;
        private IWebElement assigneesSubpageButton;

        private IWebElement filtersButton;
        private bool isFilterClicked; // TODO; Add this element to every page which contains Filter button. 

        private IWebElement activityFilter; // TODO: Create a class for modelling every dropdown menu in the filter bar.

       
        private IWebElement searchField;
        private IWebElement searchButton;

        private AssigneesObject assigneesObjects;
        private bool isParsedCorrectly;



        public string GetPageName
        {
            get
            {
                return pageName.Text.ToLower().Trim();
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        public int IsActivitiesSelected
        {
            get
            {
                if (activitiesSubpageButton != null)
                {
                    if (activitiesSubpageButton.GetAttribute("class").Contains("hdr_sub_sel"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int IsAssigneesSelected
        {
            get
            {
                if (assigneesSubpageButton != null)
                {
                    if (assigneesSubpageButton.GetAttribute("class").Contains("hdr_sub_sel"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public string ActivitiesFilterSelection
        {
            get
            {
                IReadOnlyCollection<IWebElement> auxiliaryColection;

                if (activityFilter != null)
                {
                    auxiliaryColection = activityFilter.FindElements(By.Id("cup_fpName_titletext"));
                    if (auxiliaryColection.Count == 1) return auxiliaryColection.ElementAt(0).Text;
                    else return null;
                }
                else
                {
                    return null;
                }
            }
        }

        public IReadOnlyCollection<IWebElement> ActivityFilterOptions
        {
            get
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                Regex activityListRegex = new Regex("cup_fpStepActivityName_msa_\\d+");

                if (activityFilter != null)
                {
                    auxiliaryCollection = activityFilter.FindElements(By.Id("cup_fpName_child"));
                    if (auxiliaryCollection.Count == 1)
                    {
                        auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                        return auxiliaryCollection;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public void ActivitiesFilterClick()
        {
            if (activityFilter != null)
            {
                activityFilter.Click();

            }
        }

        public void ChosenActivityClick(string chosenActivityName, IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement chosenElement;

            if (this.ActivityFilterOptions.Where(x => x.Text == chosenActivityName).Count() > 0)
            {
                chosenElement = this.ActivityFilterOptions.Where(x => x.Text == chosenActivityName).ElementAt(0);
                chosenElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            }
        }


        public void ActivitiesSubPageClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("status")));
            //activitiesSubpageButton.Click();

            IWebElement statusPageClick = driver.FindElements(By.Id("status")).Where(x => x.Text == "Activities").First();
            statusPageClick.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }

        public List<string> GetJobNames(IWebDriver driver)
        {

            assigneesObjects = new AssigneesObject(driver);
            return assigneesObjects.AssigneesJobNames;

        }

        public void SearchJobByName(string jobName, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            searchField.SendKeys(jobName);
            searchButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }


        public AssigneesPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                string auxiliaryString;

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn"))) != null)
                {

                    isParsedCorrectly = true;

                    auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));
                    if (auxiliaryCollection.Count > 0) pageName = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_vws"));
                    if (auxiliaryCollection.Count > 0) viewBar = auxiliaryCollection.ElementAt(0);

                    if (viewBar != null)
                    {

                        auxiliaryCollection = viewBar.FindElements(By.Id("status"));
                        if (auxiliaryCollection.Count > 0) activitiesSubpageButton = auxiliaryCollection.Where(x => x.Text == "Activities").First();

                        auxiliaryCollection = viewBar.FindElements(By.Id("statusassignees"));
                        if (auxiliaryCollection.Count > 0) assigneesSubpageButton = auxiliaryCollection.ElementAt(0);

                    }

                    auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
                    if (auxiliaryCollection.Count > 0) filtersButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryString = filtersButton.GetAttribute("class");
                    if (auxiliaryString.Contains("icn_flt_on")) isFilterClicked = true;

                    if (isFilterClicked == false)
                    {

                        filtersButton.Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fpName_msdd")));

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpName_msdd"));
                        if (auxiliaryCollection.Count == 1) activityFilter = auxiliaryCollection.ElementAt(0);

                    }

                    auxiliaryCollection = driver.FindElements(By.Id("sjid"));
                    if (auxiliaryCollection.Count == 1) searchField = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("sjib"));
                    if (auxiliaryCollection.Count == 1) searchButton = auxiliaryCollection.ElementAt(0);

                }
            }
        }*/
    }
}
