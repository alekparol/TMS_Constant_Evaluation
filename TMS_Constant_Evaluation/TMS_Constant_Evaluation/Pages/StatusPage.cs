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
    public class StatusPage
    {

        /* Fields */

        private StatusNavigationBar statusNavigationBar;

        private StatusFilters statusFilters;

        public IReadOnlyCollection<IWebElement> activitiesList;

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

        public int ActivitiesFilterIsExpanded
        {
            get
            {
                return statusFilters.ActivitiesFilterIsExpanded;
            }
        }

        public string ActivitiesFilterSelection
        {
            get
            {
                return statusFilters.ActivitiesFilterSelection;
            }
        }

        public int LanguagesFilterIsExpanded
        {
            get
            {
                return statusFilters.LanguagesFilterIsExpanded;
            }
        }

        public string LanguagesFilterSelection
        {
            get
            {
                return statusFilters.LanguageFilterSelection;
            }
        }

        public int AllButtonIsClicked
        {
            get
            {
                return statusFilters.ShowAllButtonIsClicked;
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

        public void ActivitiesFilterClick(IWebDriver driver)
        {
            statusFilters.FiltersPanelInitialization(driver);
            statusFilters.ActivitiesFilterClick(driver);

            statusNavigationBar = new StatusNavigationBar(driver);
        }

        public void ChosenActivityClick(IWebDriver driver, string chosenActivityName)
        {
            ActivitiesFilterClick(driver);
            statusFilters.ChosenActivityClick(driver, chosenActivityName);

            statusNavigationBar = new StatusNavigationBar(driver);
            statusFilters = new StatusFilters(driver);
        }

        public void LanguageFilterClick(IWebDriver driver)
        {
            statusFilters.FiltersPanelInitialization(driver);
            statusFilters.LanguageFilterClick(driver);

            statusNavigationBar = new StatusNavigationBar(driver);
        }

        public void ChosenTargetLanguageClick(IWebDriver driver, string chosenLanguageCode)
        {
            LanguageFilterClick(driver);
            statusFilters.ChosenTargetLanguageClick(driver, chosenLanguageCode);

            statusNavigationBar = new StatusNavigationBar(driver);
            statusFilters = new StatusFilters(driver);
        }

        public void ClickAll(IWebDriver driver)
        {
            statusFilters.ClickAll(driver);

            statusNavigationBar = new StatusNavigationBar(driver);
            statusFilters = new StatusFilters(driver);
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
    }
}
