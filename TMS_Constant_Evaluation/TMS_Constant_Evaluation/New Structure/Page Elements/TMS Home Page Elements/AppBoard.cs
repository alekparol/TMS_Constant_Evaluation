using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

/* This can be developed in the future by: 
 * 1) modelling each button for navigation bar options.
 * 2) modelling right side and left side of the bar. 
 * 3) modelling each route for buttons.
 */

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class AppBoard
    {
        /* Fields */

        protected IWebDriver driver;

        protected IWebElement applicationBoardPanel;

        protected IWebElement loggedUserButton;

        protected IWebElement loggedUserOptionsContainer;
        protected IReadOnlyCollection<IWebElement> loggedUserOptionsList;

        private WebDriverWait wait;

        /* Properties */

        /// <summary>
        /// Returns a string representing name of the logged user. 
        /// </summary>
        public string GetUserName
        {
            get
            {
                if (loggedUserButton != null)
                {
                    return loggedUserButton.Text;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Returns integral number as a value representing property of drop down being ufolded. 
        /// <returns>-1</returns> if container of options below logged user button is null; 
        /// <returns>0</returns> if option list is not unlfolded, <returns>1</returns> otherwise.
        /// </summary>
        public int IsUserOptionsListUnfolded
        {
            get
            {
                if (loggedUserOptionsContainer != null)
                {
                    if (loggedUserOptionsContainer.Displayed)
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

        /// <summary>
        /// Returns integral number of options contained in drop down menu under logged user button. 
        /// </summary>
        public int GetUserActivitiesCount
        {
            get
            {
                if (loggedUserOptionsList != null)
                {
                    return loggedUserOptionsList.Count;
                }
                return 0;
            }
        }

        /* Methods */

        /// <summary>
        /// Clicks on the logged user button enabling user options to be displayed and interactable. 
        /// </summary>
        public void LoggedUserClick()
        {
            if (loggedUserButton != null)
            {
                loggedUserButton.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("UserStatus_WebHelpLink")));
            }
        }

        /// <summary>
        /// Clicks on the logged user button and then click on the "Profile" button opening profile pop up. 
        /// </summary>
        public void ProfileClick()
        {
            if (loggedUserOptionsList != null && loggedUserOptionsList.Count > 0 && loggedUserOptionsContainer.Displayed)
            {
                LoggedUserClick();

                loggedUserOptionsList.Where(x => x.Text == "Profile").ElementAt(0).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup")));
            }
        }

        /* Constructors */

        /// <summary>
        /// Creates empty Table Menu object.
        /// </summary>
        public AppBoard()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        /// <summary>
        /// Creates a new object. Firstly initialized a application board panel, then an element representing logged user button is initialized. Then the options are initialized as <code>li</code> elements of logged user button.
        /// </summary>
        /// <exception cref="System.Exception">Thrown when actual URL adress is different than https:\/\/tms.lionbridge.com\/</exception>
        /// <exception cref="System.Exception">Thrown when initialized application board does not contain one instance of element of <code>id="app_brd"</code>. In such case it is a blocker.</exception>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public AppBoard(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            auxiliaryCollection = driver.FindElements(By.Id("app_brd"));

            if (auxiliaryCollection.Count != 1) throw new Exception("App board on the page was not found or found more than one.");
            applicationBoardPanel = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = applicationBoardPanel.FindElements(By.Id("log_usr"));
            if (auxiliaryCollection.Count == 1) loggedUserButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = applicationBoardPanel.FindElements(By.Id("usr_act"));
            if (auxiliaryCollection.Count == 1)
            {
                loggedUserOptionsContainer = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = loggedUserOptionsContainer.FindElements(By.TagName("li"));
                if (auxiliaryCollection.Count > 0) loggedUserOptionsList = auxiliaryCollection;
            }

            /*
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("log_usr")));
                        IEnumerable<IWebElement> auxiliaryIEnumerable;
             */
        }
    }
}
