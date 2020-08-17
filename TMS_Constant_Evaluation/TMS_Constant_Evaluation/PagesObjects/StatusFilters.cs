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

/*
 * This class mean to model Filters Panel which is displayed on all of the pages on the top of the screen. 
 * 
 * Preassumptions: 
 * 
 * TODO: 
 * 
 */
namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class StatusFilters
    {

        /* Fields */

        private IWebElement filtersButton;

        private IWebElement filtersPanel;

        private IWebElement languageFilter;
        private IWebElement languageFilterChild;
        private IReadOnlyCollection<IWebElement> languageList;

        private IWebElement activitiesFilter;
        private IWebElement activitiesFilterChild;
        private IReadOnlyCollection<IWebElement> activitiesList;

        private IWebElement showAllButton;

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

        public int LanguageFilterIsNull
        {
            get
            {
                if (FiltersPanelIsNull == 0)
                {
                    if (languageFilter != null)
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

        public int LanguageFilterIsDisplayed
        {
            get
            {
                if (LanguageFilterIsNull == 0)
                {
                    if (languageFilter.Displayed)
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

        public int LanguagesFilterIsExpanded
        {
            get
            {
                if (LanguageFilterIsDisplayed == 1)
                {
                    if (languageFilterChild.Displayed)
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

        public string LanguageFilterSelection
        {
            get
            {
                if (LanguageFilterIsNull == 0)
                {
                    return languageFilter.Text;
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

        public bool ShowAllButtonIsNull
        {
            get
            {
                if (showAllButton != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int ShowAllButtonIsEnabled
        {
            get
            {
                if (ShowAllButtonIsNull == false)
                {
                    if (showAllButton.Enabled)
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

        public int ShowAllButtonIsClicked
        {
            get
            {
                if (ShowAllButtonIsNull == false)
                {
                    string auxiliaryString = showAllButton.GetAttribute("class");
                    if (auxiliaryString == "lnk_off")
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

        /* Methods */

        public void FiltersButtonClick(IWebDriver driver)
        {
            if (FiltersButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                filtersButton.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_titletext")));
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

                auxiliaryCollection = driver.FindElements(By.Id("cup_fp"));
                if (auxiliaryCollection.Count == 1) filtersPanel = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("cup_fpStepActivityName_titletext"));
                if (auxiliaryCollection.Count == 1) activitiesFilter = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("cup_fpStepActivityName_child"));
                if (auxiliaryCollection.Count == 1)
                {
                    activitiesFilterChild = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                    activitiesList = auxiliaryCollection;

                }
                auxiliaryCollection = driver.FindElements(By.Id("cup_fpGetTargetLanguage_titletext"));
                if (auxiliaryCollection.Count == 1) languageFilter = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("cup_fpGetTargetLanguage_child"));
                if(auxiliaryCollection.Count == 1)
                {
                    languageFilterChild = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = auxiliaryCollection.ElementAt(0).FindElements(By.XPath(".//a"));
                    languageList = auxiliaryCollection;
                }
            }
        }

        public void TargetLanguageFilterClick(IWebDriver driver)
        {
            if (LanguageFilterIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                languageFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpGetTargetLanguage_child")));
            }
        }

        public void ChosenGetTargetLanguageClick(IWebDriver driver, string chosenLanguageCode)
        {
            TargetLanguageFilterClick(driver);

            if (LanguagesFilterIsExpanded == 1)
            {
                IWebElement chosenElement;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                chosenElement = languageList.Where(x => x.Text.Contains(chosenLanguageCode)).ElementAt(0);
                chosenElement.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        public void ActivitiesFilterClick(IWebDriver driver)
        {
            if (ActivitiesFilterIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                
                activitiesFilter.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fpStepActivityName_child")));
            }
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

        public void ClickAll(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.Id("cup_cupavNull"));
            if (auxiliaryCollection.Count == 1) auxiliaryCollection.ElementAt(0).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }

        /* Constructors */

        public StatusFilters()
        {

        }

        public StatusFilters(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fp_btn")));

                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
                if (auxiliaryCollection.Count == 1) filtersButton = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = driver.FindElements(By.Id("cup_cupavNull"));
                if (auxiliaryCollection.Count == 1) showAllButton = auxiliaryCollection.ElementAt(0);
            }
        }

    }
}
