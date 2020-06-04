using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.Pages.PagesObjects;

/* TODO: Make this class inherit from StatusPage class. */

namespace TMS_Constant_Evaluation.Pages
{
    public class AssigneesPage
    {

        /* Fields */

        private IWebElement pageName;

        private IWebElement viewBar;
        private IWebElement activitiesSubPage;
        private IWebElement assigneesSubPage;

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

        public string PageName
        {
            get
            {
                return pageName.Text.ToLower().Trim();
            }
        }

        public bool IsParsedCorrectly
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
                if (activitiesSubPage != null)
                {
                    if (activitiesSubPage.GetAttribute("class").Contains("hdr_sub_sel"))
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
                if (assigneesSubPage != null)
                {
                    if (assigneesSubPage.GetAttribute("class").Contains("hdr_sub_sel"))
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

        public string ActivityFilterSelection
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
        /* Methods */

        public void ActivityFilterClick()
        {
            if(activityFilter != null)
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
                        if (auxiliaryCollection.Count > 0) activitiesSubPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = viewBar.FindElements(By.Id("statusassignees"));
                        if (auxiliaryCollection.Count > 0) assigneesSubPage = auxiliaryCollection.ElementAt(0);

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
    }
}
