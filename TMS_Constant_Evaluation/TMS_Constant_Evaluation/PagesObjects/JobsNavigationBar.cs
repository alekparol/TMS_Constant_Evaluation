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
namespace TMS_Constant_Evaluation.PagesObjects
{
    public class JobsNavigationBar
    {
        /* Fields */

        private IWebElement navigationPanel;

        private IWebElement pageName;
        private IWebElement newButton;
        private IWebElement inWorkButton;
        private IWebElement allButton;

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

        public int NewJobsButtonIsNull
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    if (newButton != null)
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

        public int NewJobsButtonIsDisplayed
        {
            get
            {
                if (NewJobsButtonIsNull == 0)
                {
                    if (newButton.Displayed)
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

        public int NewJobsButtonIsClicked
        {
            get
            {
                if (NewJobsButtonIsNull == 0)
                {
                    string auxiliaryString = newButton.GetAttribute("class");
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

        public int InWorkJobsButtonIsNull
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    if (inWorkButton != null)
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

        public int InWorkJobsButtonIsDisplayed
        {
            get
            {
                if (InWorkJobsButtonIsNull == 0)
                {
                    if (inWorkButton.Displayed)
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

        public int InWorkJobsButtonIsClicked
        {
            get
            {
                if (InWorkJobsButtonIsNull == 0)
                {
                    string auxiliaryString = inWorkButton.GetAttribute("class");
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

        public int AllJobsButtonIsNull
        {
            get
            {
                if (NavigationPanelIsNull == false)
                {
                    if (allButton != null)
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

        public int AllJobsButtonIsDisplayed
        {
            get
            {
                if (AllJobsButtonIsNull == 0)
                {
                    if (allButton.Displayed)
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

        public int AllJobsButtonIsClicked
        {
            get
            {
                if (AllJobsButtonIsNull == 0)
                {
                    string auxiliaryString = allButton.GetAttribute("class");
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

        public void NewJobsClick(IWebDriver driver)
        {
            if (NewJobsButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                newButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));
            }
        }

        public void InWorkJobsClick(IWebDriver driver)
        {
            if (InWorkJobsButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                inWorkButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));
            }
        }

        public void AllJobsClick(IWebDriver driver)
        {
            if (AllJobsButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                allButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));
            }
        }

        /* Constructors */

        public JobsNavigationBar()
        {

        }

        public JobsNavigationBar(IWebDriver driver)
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

                    auxiliaryCollection = navigationPanel.FindElements(By.Id("jobs"));
                    if (auxiliaryCollection.Count > 0) newButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = navigationPanel.FindElements(By.Id("jobsdashboard"));
                    if (auxiliaryCollection.Count > 0) inWorkButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = navigationPanel.FindElements(By.Id("jobsactivity"));
                    if (auxiliaryCollection.Count > 0) allButton = auxiliaryCollection.ElementAt(0);
                }
            }
        }
    }
}
