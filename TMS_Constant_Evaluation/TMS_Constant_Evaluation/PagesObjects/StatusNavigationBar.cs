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
    public class StatusNavigationBar
    {

        /* Fields */

        private IWebElement navigationPanel;

        private IWebElement pageName;
        private IWebElement activitiesSubpageButton;
        private IWebElement assigneesSubpageButton;

        /* Properties */

        public bool NavigationPanelIsNull
        {
            get
            {
                if (navigationPanel != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int NavigationPanelIsDisplayed
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    if (navigationPanel.Displayed)
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

        public string GetPageName
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    return pageName.Text.ToLower().Trim();
                }
                else
                {
                    return "";
                }                   
            }
        }

        public int ActivitiesSubpageIsNull
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    if (activitiesSubpageButton != null)
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

        public int ActivitiesSubpageIsDisplayed
        {
            get
            {
                if (ActivitiesSubpageIsNull == 0)
                {
                    if (activitiesSubpageButton.Displayed)
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

        public int ActivitiesSubpageIsClicked
        {
            get
            {
                if (ActivitiesSubpageIsNull == 0)
                {
                    string auxiliaryString = activitiesSubpageButton.GetAttribute("class");
                    if (auxiliaryString.Contains("hdr_sub_sel"))
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

        public int AssigneesSubpageIsNull
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    if (assigneesSubpageButton != null)
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

        public int AssigneesSubpageIsDisplayed
        {
            get
            {
                if (AssigneesSubpageIsNull == 0)
                {
                    if (assigneesSubpageButton.Displayed)
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

        public int AssigneesSubpageIsClicked
        {
            get
            {
                if (AssigneesSubpageIsNull == 0)
                {
                    string auxiliaryString = assigneesSubpageButton.GetAttribute("class");
                    if (auxiliaryString.Contains("hdr_sub_sel"))
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

        public void ActivitiesClick(IWebDriver driver)
        {
            if (ActivitiesSubpageIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                activitiesSubpageButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));
            }
        }

        public void AssigneesClick(IWebDriver driver)
        {
            if (AssigneesSubpageIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                assigneesSubpageButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));
            }
        }

        /* Constructors */

        public StatusNavigationBar()
        {

        }

        public StatusNavigationBar(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav_bar_vws")));

                auxiliaryCollection = driver.FindElements(By.Id("nav_bar_vws"));
                if (auxiliaryCollection.Count == 1)
                {
                    navigationPanel = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = navigationPanel.FindElements(By.Id("sel_mnu_itm"));
                    if (auxiliaryCollection.Count > 0) pageName = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = navigationPanel.FindElements(By.Id("status"));
                    if (auxiliaryCollection.Count > 0) activitiesSubpageButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = navigationPanel.FindElements(By.Id("statusassignees"));
                    if (auxiliaryCollection.Count > 0) assigneesSubpageButton = auxiliaryCollection.ElementAt(0);
                }
            }
        }

    }
}
