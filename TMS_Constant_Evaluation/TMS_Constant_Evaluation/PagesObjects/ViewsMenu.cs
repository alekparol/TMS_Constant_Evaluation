using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
using TMS_Constant_Evaluation.PagesObjects;
using TMS_Constant_Evaluation.PagesObjects.JobObject;


/*
 * This class means to model TMS Views Menu which is a part of MenuLeftContent displayed on most of the pages after clicking on particular project, on the left side of the screen. 
 * 
 * Preassumptions: 
 * 
 * TODO: This class should be splitted in at least two other classes:
 * 1) Interface which would describe the methods of every button.
 * 2) 
 * 
 */
namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class ViewsMenu
    {

        /* Fields */

        private IWebElement viewsPanel;

        private MenuLeftContentButton jobsView;
        private MenuLeftContentButton planningView;
        private MenuLeftContentButton statusView;

        /* Properties */

        public bool ViewsPanelIsNull
        {
            get
            {
                if (viewsPanel != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public MenuLeftContentButton JobsView
        {
            get
            {
                return jobsView;
            }
        }

        public MenuLeftContentButton PlanningView
        {
            get
            {
                return planningView;
            }
        }

        public MenuLeftContentButton StatusView
        {
            get
            {
                return statusView;
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                if (true)
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

        /* Constructors */

        public ViewsMenu()
        {

        }

        public ViewsMenu(IWebDriver driver)
        {

            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IEnumerable<IWebElement> auxiliaryIEnumerable;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lup_actionPanel")));

                auxiliaryCollection = driver.FindElements(By.Id("lup_actionPanel"));
                if (auxiliaryCollection.Count == 1)
                {

                    viewsPanel = auxiliaryCollection.ElementAt(0);

                    jobsView = new MenuLeftContentButton(viewsPanel, driver, "jobsdashboard");
                    planningView = new MenuLeftContentButton(viewsPanel, driver, "planning");
                    statusView = new MenuLeftContentButton(viewsPanel, driver, "status");

                }

            }

        }
        /*

        private IWebElement viewsPanel;
        private IWebElement viewsList;

        private IWebElement jobsView;
        private IWebElement planningView;
        private IWebElement statusView;

      

        public bool ViewsPanelIsNull
        {
            get
            {
                if (viewsPanel != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int ViewsListIsFull
        {
            get
            {

                if (viewsList != null)
                {
                    IReadOnlyCollection<IWebElement> auxiliaryCollection = viewsList.FindElements(By.TagName("li"));

                    if (auxiliaryCollection.Count == 6)
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

        public int JobsViewIsNull
        {
            get
            {
                if (viewsList != null)
                {
                    if (jobsView == null)
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

        public int JobsView.ButtonIsClicked
        {
            get
            {
                if (jobsView != null)
                {
                    string className = jobsView.GetAttribute("class");

                    if (className == "treeviewLISelected")
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

        public int PlanningViewIsNull
        {
            get
            {
                if (viewsList != null)
                {
                    if (planningView == null)
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

        public int PlanningView.ButtonIsClicked
        {
            get
            {
                if (planningView != null)
                {
                    string className = planningView.GetAttribute("class");

                    if (className == "treeviewLISelected")
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

        public int StatusViewIsNull
        {
            get
            {
                if (viewsList != null)
                {
                    if (statusView == null)
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

        public int StatusViewIsClicked
        {
            get
            {
                if (statusView != null)
                {
                    string className = statusView.GetAttribute("class");

                    if (className == "treeviewLISelected")
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

        public bool IsParsingCorrect
        {
            get
            {
                if (JobsViewIsNull == 0 && PlanningViewIsNull == 0 && StatusViewIsNull == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public void JobsClick(IWebDriver driver)
        {
            if (jobsView != null)
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                jobsView.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

            }

        }

        public void PlanningClick(IWebDriver driver)
        {
            if (planningView != null)
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                planningView.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

            }

        }
        public void StatusClick(IWebDriver driver)
        {
            if (statusView != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                statusView.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));
            }

        }

        public ViewsMenu()
        {

        }

        public ViewsMenu(IWebDriver driver)
        {

            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IEnumerable<IWebElement> auxiliaryIEnumerable;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("inworktasks"))) != null)
                {

                    auxiliaryCollection = driver.FindElements(By.Id("lup_actionPanel"));
                    if (auxiliaryCollection.Count == 1)
                    {

                        viewsPanel = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = viewsPanel.FindElements(By.ClassName("treeviewUL"));
                        if (auxiliaryCollection.Count > 0)
                        {

                            auxiliaryIEnumerable = auxiliaryCollection.Where(x => x.FindElements(By.TagName("li")).Any(y => y.GetAttribute("id") == "jobsdashboard"));
                            if (auxiliaryIEnumerable.Count() == 1)
                            {
                                viewsList = auxiliaryIEnumerable.ElementAt(0);

                                auxiliaryCollection = viewsList.FindElements(By.Id("jobsdashboard"));
                                if (auxiliaryCollection.Count == 1) jobsView = auxiliaryCollection.ElementAt(0);

                                auxiliaryCollection = viewsList.FindElements(By.Id("planning"));
                                if (auxiliaryCollection.Count == 1) planningView = auxiliaryCollection.ElementAt(0);

                                auxiliaryCollection = viewsList.FindElements(By.Id("status"));
                                if (auxiliaryCollection.Count == 1) statusView = auxiliaryCollection.ElementAt(0);

                            }

                        }

                    }

                }

            }

        }*/

    }
}
