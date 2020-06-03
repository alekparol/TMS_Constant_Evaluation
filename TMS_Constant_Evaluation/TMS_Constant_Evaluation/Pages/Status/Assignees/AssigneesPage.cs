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

        private bool isParsedCorrectly;


        /* Those two elements are displayed on every page after particular project page. 
         * TODO: Add them to some class which from they could be inherited.*/ 
        private IWebElement searchField;
        private IWebElement searchButton;

        private bool isFilterClicked; // TODO; Add this element to every page which contains Filter button. 
        private IWebElement activityFilter;

        private AssigneesObject assigneesObjects;

        private PageBar assigneesPageBar;


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

        /* Methods */



        /* Constructors */

        public AssigneesPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

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

                }
            }
        }
    }
}
