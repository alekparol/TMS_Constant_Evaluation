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
 * This class mean to model TMS Application Tab Menu which is displayed above main view - this tab contains selected project name nad options common on
 * all pages. 
 * 
 * Preassumptions: 
 * 
 * TODO: 
 * 
 */

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class TabMenu
    {

        /* Fields */

        private IWebElement tabMenuPanel;
        private IWebElement tabMenuOptions;

        public IEnumerable<IWebElement> tabMenuOptionList;
        private IEnumerable<IWebElement> openedProjectsList;
        private IWebElement currentProject;

        /* Properties */

        public bool TabMenuPanelIsNull
        {
            get
            {
                if (tabMenuPanel != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int TabMenuOptionsIsNull
        {
            get
            {
                if (TabMenuPanelIsNull == false)
                {
                    if (tabMenuOptions != null)
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

        public int TabMenuOptionListCount
        {
            get
            {
                if (tabMenuOptionList != null)
                {
                    return tabMenuOptionList.Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        public int OpenedProjectsListCount
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

        public bool CurrentProjectIsNull
        {
            get
            {
                if (OpenedProjectsListCount != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string CurrentProjectName
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

        public bool IsParsingCorrect
        {
            get
            {
                if (TabMenuOptionsIsNull == 0 && TabMenuOptionListCount == 4 && OpenedProjectsListCount > 0)
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

        public TabMenu(IWebDriver driver)
        {

            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IEnumerable<IWebElement> auxiliaryIEnumerable;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("tab_mn1"))) != null)
                {

                    auxiliaryCollection = driver.FindElements(By.Id("tab_c"));
                    if (auxiliaryCollection.Count == 1)
                    {

                        tabMenuPanel = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = tabMenuPanel.FindElements(By.Id("tab_m"));
                        if (auxiliaryCollection.Count == 1) tabMenuOptions = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = tabMenuPanel.FindElements(By.ClassName("menuItem"));
                        if (auxiliaryCollection.Count > 0)
                        {

                            auxiliaryIEnumerable = auxiliaryCollection.Where(x => x.GetAttribute("title") != "");
                            if (auxiliaryIEnumerable.Count() > 0) tabMenuOptionList = auxiliaryIEnumerable;

                            auxiliaryIEnumerable = auxiliaryCollection.Where(x => x.GetAttribute("title") == "");
                            if (auxiliaryIEnumerable.Count() > 0) openedProjectsList = auxiliaryIEnumerable;
                            {

                                openedProjectsList = auxiliaryIEnumerable;

                                auxiliaryIEnumerable = openedProjectsList.Where(x => x.GetAttribute("class").Contains("menuSelectedItem"));
                                if (auxiliaryIEnumerable.Count() == 1) currentProject = auxiliaryIEnumerable.ElementAt(0);

                            }
                           
                        }

                    }

                }
            }

        }
    }
}
