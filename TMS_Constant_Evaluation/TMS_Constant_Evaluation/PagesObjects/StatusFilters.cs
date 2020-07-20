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
 * This class mean to model TMS Application Board which is displayed on all of the pages on the top of the screen. 
 * 
 * Preassumptions: 
 * 
 * TODO: 
 * 
 */
namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    class StatusFilters
    {

        /* Fields */

        private IWebElement filtersButton;

        private IWebElement filtersBody;

        private IWebElement languageFilter;
        private IReadOnlyCollection<IWebElement> languageList;

        private IWebElement activitiesFilter;
        private IReadOnlyCollection<IWebElement> activitiesList;

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

        /* Methods */



        /* Constructors */

        public StatusFilters()
        {

        }

        public StatusFilters(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IEnumerable<IWebElement> auxiliaryIEnumerable;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fp_btn")));

                auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
                if (auxiliaryCollection.Count == 1) filtersButton = auxiliaryCollection.ElementAt(0);
            }
        }

    }
}
