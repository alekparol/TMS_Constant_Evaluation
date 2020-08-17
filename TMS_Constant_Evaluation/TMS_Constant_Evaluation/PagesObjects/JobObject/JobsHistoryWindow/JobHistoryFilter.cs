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
    public class JobHistoryFilter
    {
        /* Fields */

        private IWebElement filtersButton;

        private IWebElement filtersPanel;

        private IWebElement sourceLanguageFilter;
        private IWebElement sourceLanguageFilterChild;
        private IReadOnlyCollection<IWebElement> sourceLanguageList;

        private IWebElement targetLanguageFilter;
        private IWebElement targetLanguageFilterChild;
        private IReadOnlyCollection<IWebElement> targetLanguageList;

        private IWebElement activitiesFilter;
        private IWebElement activitiesFilterChild;
        private IReadOnlyCollection<IWebElement> activitiesList;

        private IWebElement infoMessage;

        /* Properties */

        public bool FiltersButtonIsNull
        {
            get
            {
                if (filtersButton != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int FiltersButtonIsDisplayed
        {
            get
            {
                if (FiltersButtonIsNull == false)
                {
                    if (filtersButton.Displayed)
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

        public int FiltersButtonIsClicked
        {
            get
            {
                if (FiltersButtonIsDisplayed == 1)
                {
                    string auxiliaryString = filtersButton.GetAttribute("class");
                    if (auxiliaryString.Contains("icn_flt_on"))
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

        public int FiltersPanelIsNull
        {
            get
            {
                if (FiltersButtonIsNull == false)
                {
                    if (filtersPanel != null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int FiltersPanelIsDisplayed
        {
            get
            {
                if (FiltersPanelIsNull == 0)
                {
                    if (filtersPanel.Displayed)
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

        public int SourceLanguageFilterIsNull
        {
            get
            {
                if (FiltersPanelIsNull == 0)
                {
                    if (sourceLanguageFilter != null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int SourceLanguageFilterIsDisplayed
        {
            get
            {
                if (SourceLanguageFilterIsNull == 0)
                {
                    if (sourceLanguageFilter.Displayed)
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

        public int SourceLanguagesFilterIsExpanded
        {
            get
            {
                if (SourceLanguageFilterIsDisplayed == 1)
                {
                    if (sourceLanguageFilterChild.Displayed)
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

        public string SourceLanguageFilterSelection
        {
            get
            {
                if (SourceLanguageFilterIsNull == 0)
                {
                    return sourceLanguageFilter.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int TargetLanguageFilterIsNull
        {
            get
            {
                if (FiltersPanelIsNull == 0)
                {
                    if (targetLanguageFilter != null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int TargetLanguageFilterIsDisplayed
        {
            get
            {
                if (TargetLanguageFilterIsNull == 0)
                {
                    if (targetLanguageFilter.Displayed)
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

        public int TargetLanguagesFilterIsExpanded
        {
            get
            {
                if (TargetLanguageFilterIsDisplayed == 1)
                {
                    if (targetLanguageFilterChild.Displayed)
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

        public string TargetLanguageFilterSelection
        {
            get
            {
                if (TargetLanguageFilterIsNull == 0)
                {
                    return targetLanguageFilter.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int ActivitiesFilterIsNull
        {
            get
            {
                if (FiltersPanelIsNull == 0)
                {
                    if (activitiesFilter != null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int ActivitiesFilterIsDisplayed
        {
            get
            {
                if (ActivitiesFilterIsNull == 0)
                {
                    if (activitiesFilter.Displayed)
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

        public int ActivitiesFilterIsExpanded
        {
            get
            {
                if (ActivitiesFilterIsDisplayed == 1)
                {
                    if (activitiesFilterChild.Displayed)
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
                if (ActivitiesFilterIsNull == 0)
                {
                    return activitiesFilter.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        /* Methods */

        public void FiltersButtonClick(IWebDriver driver)
        {
            if (FiltersButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                filtersButton.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fp")));
            }
        }

        public void DisplayFiltersPanel(IWebDriver driver)
        {
            if (FiltersButtonIsDisplayed == 1)
            {
                if (FiltersButtonIsClicked == 0)
                {
                    FiltersButtonClick(driver);
                }
            }
        }

        public void FiltersPanelInitialization(IWebDriver driver)
        {
            if (FiltersButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                DisplayFiltersPanel(driver);
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fpName_titletext")));

                auxiliaryCollection = driver.FindElements(By.Id("pup_fp"));
                if (auxiliaryCollection.Count == 1) filtersPanel = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("pup_fpName_titletext"));
                if (auxiliaryCollection.Count == 1) activitiesFilter = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("pup_fpName_child"));
                if (auxiliaryCollection.Count == 1)
                {
                    activitiesFilterChild = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                    activitiesList = auxiliaryCollection;

                }

                auxiliaryCollection = driver.FindElements(By.Id("pup_fpSourceLanguage_titletext"));
                if (auxiliaryCollection.Count == 1) sourceLanguageFilter = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("pup_fpSourceLanguage_child"));
                if (auxiliaryCollection.Count == 1)
                {
                    sourceLanguageFilterChild = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                    sourceLanguageList = auxiliaryCollection;
                }

                auxiliaryCollection = driver.FindElements(By.Id("pup_fpTargetLanguage_titletext"));
                if (auxiliaryCollection.Count == 1) targetLanguageFilter = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("pup_fpTargetLanguage_child"));
                if (auxiliaryCollection.Count == 1)
                {
                    targetLanguageFilterChild = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                    targetLanguageList = auxiliaryCollection;
                }
            }
        }

        public void SourceLanguageFilterClick(IWebDriver driver)
        {
            if (SourceLanguageFilterIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                sourceLanguageFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fpSourceLanguage_child")));
            }
        }

        public void ChosenSourceLanguageClick(IWebDriver driver, string chosenLanguageCode)
        {
            SourceLanguageFilterClick(driver);

            if (SourceLanguagesFilterIsExpanded == 1)
            {
                IWebElement chosenElement;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                chosenElement = sourceLanguageList.Where(x => x.Text.Contains(chosenLanguageCode)).ElementAt(0);
                chosenElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        public void TargetLanguageFilterClick(IWebDriver driver)
        {
            if (TargetLanguageFilterIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                targetLanguageFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fpTargetLanguage_child")));
            }
        }

        public void ChosenTargetLanguageClick(IWebDriver driver, string chosenLanguageCode)
        {
            TargetLanguageFilterClick(driver);

            if (TargetLanguagesFilterIsExpanded == 1)
            {
                IWebElement chosenElement;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                chosenElement = targetLanguageList.Where(x => x.Text.Contains(chosenLanguageCode)).ElementAt(0);
                chosenElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        public void ActivitiesFilterClick(IWebDriver driver)
        {
            //if (ActivitiesFilterIsDisplayed == 1)
            //{
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                activitiesFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fpName_child")));
            //}
        }

        public void ChosenActivityClick(IWebDriver driver, string chosenActivityName)
        {
            ActivitiesFilterClick(driver);

            if (ActivitiesFilterIsExpanded == 1)
            {
                IWebElement chosenElement;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                chosenElement = activitiesList.Where(x => x.Text == chosenActivityName).ElementAt(0);
                chosenElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        /* Constructors */

        public JobHistoryFilter()
        {

        }

        public JobHistoryFilter(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fp_btn")));

                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                auxiliaryCollection = driver.FindElements(By.Id("pup_fp_btn"));
                if (auxiliaryCollection.Count == 1) filtersButton = auxiliaryCollection.ElementAt(0);

                //auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
               //if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);

            }
        }

    }
}
