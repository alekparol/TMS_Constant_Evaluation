using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.New_Structure
{
    public class TMSProjectHomePage
    {

        /* Fields */

        protected IWebDriver driver;

        protected TableMenu tableMenu;
        protected AppBoard appBoard;
        protected LeftMenu leftMenu;

        protected UserProfile userProfile;

        protected IWebElement infoMessage;

        /* Properties */

        public TableMenu TableMenu
        {
            get
            {
                return tableMenu;
            }
        }

        public AppBoard AppBoard
        {
            get
            {
                return appBoard;
            }
        }

        public UserProfile UserProfile
        {
            get
            {
                return userProfile;
            }
        }

        public LeftMenu LeftMenu
        {
            get
            {
                return leftMenu;
            }
        }

        public string GetSelectedProjectName
        {
            get
            {
                return tableMenu.GetCurrentProjectName;
            }
        }

        public string GetLoggedUserName
        {
            get
            {
                return appBoard.GetUserName;
            }
        }

        public int IsActivitiesMenuUnfolded
        {
            get
            {
                return appBoard.IsUserOptionsListUnfolded;
            }
        }

        public string GetInfoMessage
        {
            get
            {
                if (infoMessage != null)
                {
                    return infoMessage.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int IsJobsViewClicked
        {
            get
            {
                return leftMenu.JobsView.ButtonIsClicked;
            }
        }

        public int IsPlanningViewClicked
        {
            get
            {
                return leftMenu.PlanningView.ButtonIsClicked;
            }
        }

        public int IsStatusViewClicked
        {
            get
            {
                return leftMenu.StatusView.ButtonIsClicked;
            }
        }

        /* Methods */

        public void LoggedUserClick(IWebDriver driver)
        {
            appBoard.LoggedUserClick();
        }

        public void ProfileClick(IWebDriver driver)
        {
            appBoard.ProfileClick();
            userProfile = new UserProfile(driver);
        }

        public void ChangeItemsPerPageToMinimum(IWebDriver driver)
        {
            if (userProfile != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                userProfile.ItemsPerPageMinimal(driver);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("jnotify-item-msg")));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);
            }
        }

        public void ChangeItemsPerPageToMaximum(IWebDriver driver)
        {
            if (userProfile != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                userProfile.ItemsPerPageMaximal(driver);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("jnotify-item-msg")));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);
            }
        }

        public void JobsClick()
        {
            leftMenu.JobsView.ButtonClick();
        }

        public void PlanningClick()
        {
            leftMenu.PlanningView.ButtonClick();
        }
        public void StatusClick()
        {
            leftMenu.StatusView.ButtonClick();
        }

        /* Constructors */

        public TMSProjectHomePage()
        {

        }

        /// <summary>
        /// Creates a new TMS Home Page object by initializing elements that are genetical for all class' children - left hand menu, projects tabs and right corner application board.  
        /// </summary>
        /// <exception cref="System.Exception">Thrown when actual URL adress is different than https:\/\/tms.lionbridge.com\/</exception>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public TMSProjectHomePage(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            this.driver = driver;

            /* If there should be a wait here, it should be a maximum for three initialized fields. */

            tableMenu = new TableMenu(driver);
            appBoard = new AppBoard(driver);
            leftMenu = new LeftMenu(driver);
        }
    }
}
