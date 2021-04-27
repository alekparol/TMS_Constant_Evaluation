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

        public IWebElement errorMessage;

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

        public bool ErrorMessageIsNull
        {
            get
            {
                if (errorMessage != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string GetErrorMessage
        {
            get
            {
                if (ErrorMessageIsNull == false)
                {
                    return errorMessage.Text;
                }
                else
                {
                    return "";
                }
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

        public void TargetLanguageFilterClick(IWebDriver driver)
        {
            statusFilters.FiltersPanelInitialization(driver);
            statusFilters.TargetLanguageFilterClick(driver);

            statusNavigationBar = new StatusNavigationBar(driver);
        }

        public void ChosenGetTargetLanguageClick(IWebDriver driver, string chosenLanguageCode)
        {
            TargetLanguageFilterClick(driver);
            statusFilters.ChosenGetTargetLanguageClick(driver, chosenLanguageCode);

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
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                string auxiliaryString;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count != 0) errorMessage = auxiliaryCollection.ElementAt(0);
             
                statusNavigationBar = new StatusNavigationBar(driver);
                statusFilters = new StatusFilters(driver);

            }   
        }
    }
}
