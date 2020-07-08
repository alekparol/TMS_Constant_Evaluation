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
    public class ApplicationBoard
    {
        /* Fields */

        private IWebElement appBoardPanel;

        private IWebElement loggedUser;
        private IWebElement userActivitiesMenu;
        private IReadOnlyCollection<IWebElement> userActivitiesList;

        /* Properties */

        public bool AppBoardPanelIsNull
        {
            get
            {
                if (appBoardPanel != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int LoggedUserIsNull
        {
            get
            {
                if (appBoardPanel != null)
                {
                    if (loggedUser != null)
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

        public string GetUserName
        {
            get
            {
                if (LoggedUserIsNull == 0)
                {
                    return loggedUser.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int UserActivitiesMenuIsNull
        {
            get
            {
                if (appBoardPanel != null)
                {
                    if (loggedUser != null)
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

        public int UserActivitiesIsClicked
        {
            get
            {
                if (UserActivitiesMenuIsNull == 0)
                {
                    if (userActivitiesMenu.Displayed)
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

        public int UserActivitiesListIsFull
        {
            get
            {
                if (userActivitiesMenu != null)
                {
                    IReadOnlyCollection<IWebElement> auxiliaryCollection = userActivitiesMenu.FindElements(By.TagName("li"));

                    if (auxiliaryCollection.Count == 5)
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

        public int ProfileActivityIsNull
        {
            get
            {
                if (UserActivitiesListIsFull == 1)
                {
                    IEnumerable<IWebElement> auxiliaryIEnumerable = userActivitiesList.Where(x => x.Text == "Profile");

                    if (auxiliaryIEnumerable.Count() == 1)
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

        public int ProfileActivityIsDisplayed
        {
            get
            {
                if (ProfileActivityIsNull == 0)
                {

                    IEnumerable<IWebElement> auxiliaryIEnumerable = userActivitiesList.Where(x => x.Text == "Profile");

                    if (auxiliaryIEnumerable.ElementAt(0).Displayed)
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

        public int ProfileWindowIsNull
        {
            get
            {
                if (UserActivitiesListIsFull == 1)
                {
                    IReadOnlyCollection<IWebElement> auxiliaryCollection = userActivitiesMenu.FindElements(By.XPath("//*[@id=\"pup\"]"));
                    
                    if (auxiliaryCollection.Count > 0)
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

        public int ProfileWindowIsDisplayed
        {
            get
            {
                
                if (ProfileWindowIsNull == 0)
                {
                    IReadOnlyCollection<IWebElement> auxiliaryCollection = userActivitiesMenu.FindElements(By.XPath("//*[@id=\"pup\"]"));

                    if (auxiliaryCollection.Count == 1 && auxiliaryCollection.ElementAt(0).Displayed)
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
                if (LoggedUserIsNull == 0 && UserActivitiesMenuIsNull == 0 && UserActivitiesListIsFull == 1)
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

        public void LoggedUserClick(IWebDriver driver)
        {

            if (loggedUser != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                loggedUser.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("usr_act")));
            }

        }

        public void ProfileClick(IWebDriver driver)
        {
            if (userActivitiesList != null && userActivitiesList.Count > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                LoggedUserClick(driver);

                userActivitiesList.Where(x => x.Text == "Profile").ElementAt(0).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup")));
            }
        }

        /* Constructors */

        public ApplicationBoard(IWebDriver driver)
        {

            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IEnumerable<IWebElement> auxiliaryIEnumerable;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("log_usr"))) != null)
                {

                    auxiliaryCollection = driver.FindElements(By.Id("app_brd"));
                    if (auxiliaryCollection.Count == 1)
                    {

                        appBoardPanel = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = appBoardPanel.FindElements(By.Id("log_usr"));
                        if (auxiliaryCollection.Count == 1) loggedUser = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = appBoardPanel.FindElements(By.Id("usr_act"));
                        if (auxiliaryCollection.Count == 1)
                        {
                            userActivitiesMenu = auxiliaryCollection.ElementAt(0);

                            auxiliaryCollection = userActivitiesMenu.FindElements(By.TagName("li"));
                            if (auxiliaryCollection.Count > 0) userActivitiesList = auxiliaryCollection;

                        }

                    }

                }

            }

        }


    }
}
