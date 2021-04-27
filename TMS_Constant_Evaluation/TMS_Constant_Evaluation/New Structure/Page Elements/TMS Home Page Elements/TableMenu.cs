using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

/* This can be developed in the future by: 
 * 1) modelling each button for project istead of IWebElements. 
 * 2) modelling each menu option. 
 * 3) modelling each route for menu option / project button.
 */ 

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class TableMenu
    {

        /* Fields */

        protected IWebElement tableMenuPanel;

        protected IEnumerable<IWebElement> tableMenuOptionsList;
        protected IEnumerable<IWebElement> openedProjectsList;
        protected IWebElement currentProject;

        /* Properties */

        /// <summary>
        /// Returns integral number of table menu option buttons.
        /// </summary>
        private int GetOptionListCount
        {
            get
            {
                if (tableMenuOptionsList != null)
                {
                    return tableMenuOptionsList.Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Returns integral number of opened projects.
        /// </summary>
        public int GetOpenedProjectsCount
        {
            get
            {
                if (openedProjectsList != null)
                {
                    return openedProjectsList.Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Returns a string denoting name of the opened project. The string is processed using ToLower() and Trim() methods.
        /// </summary>
        public string GetCurrentProjectName
        {
            get
            {
                if (currentProject != null)
                {
                    return currentProject.Text.ToLower().Trim();
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /* Methods */

        /* Constructors */

        /// <summary>
        /// Creates empty Table Menu object.
        /// </summary>
        public TableMenu()
        {

        }

        /// <summary>
        /// Creates a new object. Firstly initialized a tab menu panel, then a list of its children of a class "menuItem". Basing on this class the rest of the fields is initialized.
        /// </summary>
        /// <exception cref="System.Exception">Thrown when actual URL adress is different than https:\/\/tms.lionbridge.com\/</exception>
        /// <exception cref="System.Exception">Thrown when initialized project list is lesser or equal to 0. In this case it is a blocker.</exception>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public TableMenu(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            auxiliaryCollection = driver.FindElements(By.Id("tab_m"));

            if (auxiliaryCollection.Count != 1) throw new Exception("Table menu on the page was not found or found more than one.");
            tableMenuPanel = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = tableMenuPanel.FindElements(By.ClassName("menuItem"));

            tableMenuOptionsList = auxiliaryCollection.Where(x => x.GetAttribute("title") != "");
            openedProjectsList = auxiliaryCollection.Where(x => x.GetAttribute("title") == "");
            currentProject = openedProjectsList.FirstOrDefault(x => x.GetAttribute("class").Contains("menuSelectedItem"));

            /*var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("tab_mn1")));
            
            Enumerable<IWebElement> auxiliaryIEnumerable;
            auxiliaryIEnumerable = auxiliaryCollection.Where(x => x.GetAttribute("title") != "");
            if (auxiliaryIEnumerable.Count() > 0) tabMenuOptionList = auxiliaryIEnumerable;

            auxiliaryIEnumerable = auxiliaryCollection.Where(x => x.GetAttribute("title") == "");
            if (auxiliaryIEnumerable.Count() > 0) openedProjectsList = auxiliaryIEnumerable;

            auxiliaryIEnumerable = openedProjectsList.Where(x => x.GetAttribute("class").Contains("menuSelectedItem"));
            if (auxiliaryIEnumerable.Count() == 1) currentProject = auxiliaryIEnumerable.ElementAt(0);*/
        }
    }
}
