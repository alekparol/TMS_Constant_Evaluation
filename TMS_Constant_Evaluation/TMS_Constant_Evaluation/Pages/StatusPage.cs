﻿using OpenQA.Selenium;
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
    public class StatusPage
    {

        /* Fields */

        private StatusNavigationBar statusNavigationBar;

        private StatusFilters statusFilters;

        private IWebElement activityFilter;
        public IReadOnlyCollection<IWebElement> activitiesList;

        private IWebElement languageFilter;
        private IReadOnlyCollection<IWebElement> languageList;

        private bool isParsedCorrectly;

        /* Properties */
    
        public string GetPageName
        {
            get
            {
                return statusNavigationBar.GetPageName;
            }
        }

        public int IsActivitiesSelected
        {
            get
            {
                return statusNavigationBar.ActivitiesSubpageIsClicked;
            }
        }

        public int IsAssigneesSelected
        {
            get
            {
                return statusNavigationBar.AssigneesSubpageIsClicked;
            }
        }

        public string ActivitiesFilterSelection
        {
            get
            {
                return statusFilters.ActivitiesFilterSelection;
            }
        }

        public IReadOnlyCollection<IWebElement> ActivityFilterOptions
        {
            get
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                Regex activityListRegex = new Regex("cup_fpStepActivityName_msa_\\d+");

                return activitiesList;
            }
        }

        public string LanguagesFilterSelection
        {
            get
            {
                return statusFilters.LanguageFilterSelection;
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                if (statusNavigationBar != null && statusFilters != null)
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
            statusNavigationBar.ActivitiesClick(driver);
        }

        public void AssigneesClick(IWebDriver driver)
        {
            statusNavigationBar.AssigneesClick(driver);
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
            statusFilters.FiltersPanelInitialization(driver);
            statusFilters.ChosenActivityClick(driver, chosenActivityName);
        }

        public void LanguageFilterClick()
        {
            if (languageFilter != null)
            {
                languageFilter.Click();

            }
        }

        public void ChosenTargetLanguageClick(string chosenLanguageCode, IWebDriver driver)
        {
            statusFilters.FiltersPanelInitialization(driver);
            statusFilters.ChosenTargetLanguageClick(driver, chosenLanguageCode);
        }

        public void ClickAll(IWebDriver driver)
        {
            statusFilters.ClickAll(driver);
        }

        /* Constructors */

        public StatusPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                statusNavigationBar = new StatusNavigationBar(driver);
                statusFilters = new StatusFilters(driver);


                    /*IWebElement errorMessage;

                    auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                    if (auxiliaryCollection.Count != 0) errorMessage = auxiliaryCollection.ElementAt(0);*/
            }

        }

        /*private IWebElement pageName;

        private IWebElement viewBar; 
        private IWebElement activitiesSubpageButton;
        private IWebElement assigneesSubpageButton;

        private IWebElement filtersButton;
        private bool isFilterClicked;

        private IWebElement activityFilter;
        public IReadOnlyCollection<IWebElement> activitiesList;

        private IWebElement languageFilter;
        private IReadOnlyCollection<IWebElement> languageList;

        private bool isParsedCorrectly;


        public string GetPageName
        {
            get
            {
                return statusNavigationBar.GetPageName;
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

                return activitiesList;
            }
        }

        public void AssigneesClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            assigneesSubpageButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

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

        public void LanguageFilterClick()
        {
            if (languageFilter != null)
            {
                languageFilter.Click();

            }
        }

        public void ChosenTargetLanguageClick(string chosenLanguageCode, IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement chosenElement;

            if (this.languageList.Where(x => x.Text == chosenLanguageCode).Count() > 0)
            {
                chosenElement = this.languageList.Where(x => x.Text == chosenLanguageCode).ElementAt(0);
                chosenElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            }
        }

        public void ClickAll(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.Id("cup_cupavNull"));
            if (auxiliaryCollection.Count == 1) auxiliaryCollection.ElementAt(0).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }

        public StatusPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                string auxiliaryString;

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn"))) != null)
                {

                    isParsedCorrectly = true;

                    auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
                    if (auxiliaryCollection.Count > 0) filtersButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryString = filtersButton.GetAttribute("class");
                    if (auxiliaryString.Contains("icn_flt_on")) isFilterClicked = true;


                    if (isFilterClicked == false && driver.FindElements(By.Id("jnotify-item-msg")).Count == 0 && filtersButton != null)
                    {

                        filtersButton.Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fpStepActivityName_titletext")));

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpStepActivityName_titletext"));
                        if (auxiliaryCollection.Count == 1) activityFilter = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpTargetLanguage_titletext"));
                        if (auxiliaryCollection.Count == 1) languageFilter = auxiliaryCollection.ElementAt(0);

                    }

                    else if (isFilterClicked == true && driver.FindElements(By.Id("jnotify-item-msg")).Count == 0 && filtersButton != null)
                    {

                        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fpStepActivityName_titletext")));

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpStepActivityName_titletext"));
                        if (auxiliaryCollection.Count == 1) activityFilter = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpTargetLanguage_titletext"));
                        if (auxiliaryCollection.Count == 1) languageFilter = auxiliaryCollection.ElementAt(0);

                    }

                    auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));
                    if (auxiliaryCollection.Count > 0) pageName = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_vws"));
                    if (auxiliaryCollection.Count > 0) viewBar = auxiliaryCollection.ElementAt(0);

                    if (viewBar != null)
                    {

                        auxiliaryCollection = viewBar.FindElements(By.Id("status"));
                        if (auxiliaryCollection.Count > 0) activitiesSubpageButton = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = viewBar.FindElements(By.Id("statusassignees"));
                        if (auxiliaryCollection.Count > 0) assigneesSubpageButton = auxiliaryCollection.ElementAt(0);

                    }

                    if (activityFilter != null)
                    {
                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpStepActivityName_child"));
                        if (auxiliaryCollection.Count == 1)
                        {
                            auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                            activitiesList = auxiliaryCollection;

                        }

                        auxiliaryCollection = driver.FindElements(By.Id("cup_fpTargetLanguage_child"));
                        if (auxiliaryCollection.Count == 1)
                        {
                            auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                            languageList = auxiliaryCollection;
                        }

                    }


                    IWebElement errorMessage;

                    auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                    if (auxiliaryCollection.Count != 0) errorMessage = auxiliaryCollection.ElementAt(0);

                }
            }

        }*/

    }
}