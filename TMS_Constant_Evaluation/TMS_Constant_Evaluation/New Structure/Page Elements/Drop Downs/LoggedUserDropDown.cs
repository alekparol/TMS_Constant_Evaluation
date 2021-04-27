using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

/* This can be developed in the future by: 
 * 1) modelling each button for logged user buttons.
 * 2) modelling each route for buttons.
 */

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Drop_Downs
{
    public class LoggedUserDropDown
    {
        /* Fields */

        protected IWebElement loggedUserButton;

        protected IWebElement loggedUserOptionsContainer;
        protected IReadOnlyCollection<IWebElement> loggedUserOptionsList;

        /* Properties */

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

        public int IsActivitiesMenuUnfolded
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

        public void LoggedUserClick(IWebDriver driver)
        {

            if (loggedUserButton != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                loggedUserButton.Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("UserStatus_WebHelpLink")));
            }

        }

        public void ProfileClick(IWebDriver driver)
        {
            if (loggedUserOptionsList != null && loggedUserOptionsList.Count > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                LoggedUserClick(driver);

                loggedUserOptionsList.Where(x => x.Text == "Profile").ElementAt(0).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup")));
            }
        }

        /* Constructors */

        public LoggedUserDropDown()
        {

        }

        /// <summary>
        /// Creates a new object. Firstly initialized a tab menu panel, then a list of its children of a class "menuItem". Basing on this class the rest of the fields is initialized.
        /// </summary>
        /// <exception cref="System.Exception">Thrown when actual URL adress is different than https:\/\/tms.lionbridge.com\/</exception>
        /// <exception cref="System.Exception">Thrown when initialized project list is lesser or equal to 0. In this case it is a blocker.</exception>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public LoggedUserDropDown(IWebDriver driver, IWebElement parentElement)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = parentElement.FindElements(By.Id("log_usr"));
            if (auxiliaryCollection.Count != 1) throw new Exception("Logged user button on the page was not found or found more than one.");

            loggedUserButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = parentElement.FindElements(By.Id("usr_act"));
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
