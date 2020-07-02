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


namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    class ViewsMenu
    {

        /* Fields */

        private IWebElement viewsPanel;
        private IWebElement viewsList;

        private IWebElement jobsView;
        private IWebElement planningView;
        private IWebElement statusView;


        /* Properties */

        public IWebElement JobsView
        {
            get
            {
                return jobsView;
            }
        }

        public IWebElement PlanningView
        {
            get
            {
                return planningView;
            }
        }

        public IWebElement StatusView
        {
            get
            {
                return statusView;
            }
        }

        /* Methods */

        public void JobsClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            jobsView.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

        }

        public void PlanningClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            planningView.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

        }
        public void StatusClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            statusView.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

        }

        /* Constructors */

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

        }


    }
}
