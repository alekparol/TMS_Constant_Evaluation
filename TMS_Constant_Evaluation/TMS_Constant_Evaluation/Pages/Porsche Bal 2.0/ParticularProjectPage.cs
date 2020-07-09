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
using TMS_Constant_Evaluation.Pages.PagesObjects;

/* TODO: Make a new class for sections which would contain: 
 * 1. IWebElement section;
 * 2. Name = section.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text;
 * 3. Notifications = 
 **/

namespace TMS_Constant_Evaluation.Pages
{
    public class ParticularProjectPage
    {
        /* Fields */
        
        /*private IWebElement selectedProject;

        private IWebElement loggedUser;
        private IWebElement userActivitiesMenu;
        private IReadOnlyCollection<IWebElement> userActivitiesList;*/

        private TabMenu myTabMenu;
        private ApplicationBoard myApplicationBoard;
        private MyProfile myProfileInstance;
        private ViewsMenu myViewsMenu;

        /*private IWebElement jobsSection;
        private IWebElement planningSection;
        private IWebElement statusSection;*/

        private IWebElement infoMessage;

        //private bool isParsedCorrectly;

        /* Properties */

        public ApplicationBoard MyApplicationBoard
        {
            get
            {
                return myApplicationBoard;
            }
        }

        public TabMenu MyTabMenu
        {
            get
            {
                return myTabMenu;
            }
        }

        public MyProfile MyProfileInstance
        {
            get
            {
                return myProfileInstance;
            }
        }

        public ViewsMenu MyViewsMenu
        {
            get
            {
                return myViewsMenu;
            }
        }

        public string SelectedProjectName
        {
            get
            {
                return myTabMenu.CurrentProjectName;
            }
        }

        public string LoggedUser
        {
            get
            {
                return myApplicationBoard.GetUserName;
            }
        }

        public bool UserActivitiesClicked
        {
            get
            {
                if (myApplicationBoard.UserActivitiesIsClicked == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string InfoMessage
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

        public bool IsParsedCorrectly
        {
            get
            {
                if (myApplicationBoard.IsParsingCorrect && myTabMenu.IsParsingCorrect && myViewsMenu.IsParsingCorrect)
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

            myApplicationBoard.LoggedUserClick(driver);

        }

        public void ProfileClick(IWebDriver driver)
        {

            myApplicationBoard.ProfileClick(driver);
            myProfileInstance = new MyProfile(driver);

        }

        public void ChangeItemsPerPage(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            if (myProfileInstance != null)
            {
                myProfileInstance.ChangeNumberOfItems(driver, 25);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("jnotify-item-msg")));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);
            }
        }
            
        public void JobsClick(IWebDriver driver)
        {

            myViewsMenu.JobsClick(driver);

        }

        public void PlanningClick(IWebDriver driver)
        {

            myViewsMenu.PlanningClick(driver);

        }
        public void StatusClick(IWebDriver driver)
        {

            myViewsMenu.StatusClick(driver);

        }

        /* Constructors */

        public ParticularProjectPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if(wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("inworktasks"))) != null)
                {

                    myApplicationBoard = new ApplicationBoard(driver);
                    myTabMenu = new TabMenu(driver);
                    myViewsMenu = new ViewsMenu(driver);

                }

            }
        }

        /*public string SelectedProjectName
        {
            get
            {
                return myTabMenu.CurrentProjectName;
            }
        }

        public string LoggedUser
        {
            get
            {
                return loggedUser.Text;
            }
        }

        public bool UserActivitiesClicked
        {
            get
            {
                if (userActivitiesMenu.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
     
        public IWebElement JobsSection
        {
            get
            {
                return jobsSection;
            }
        }

        public IWebElement PlanningSection
        {
            get
            {
                return planningSection;
            }
        }

        public IWebElement StatusSection
        {
            get
            {
                return statusSection;
            }
        }

        public string InfoMessage
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

        public bool IsParsedCorrectly
        {
            get
            {
                return isParsedCorrectly;
            }
        }*/

        /* Methods */

        /*public void LoggedUserClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            loggedUser.Click();
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("usr_act")));

        }

        public void ProfileClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            LoggedUserClick(driver);

            userActivitiesList.Where(x => x.Text == "Profile").ElementAt(0).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup")));
            myProfileInstance = new MyProfile(driver);

        }

        public void ChangeItemsPerPage(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            if (myProfileInstance != null)
            {
                myProfileInstance.ChangeNumberOfItems(driver);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("jnotify-item-msg")));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);
            }
        }
            
        public void JobsClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            jobsSection.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

        }

        public void PlanningClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            planningSection.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

        }
        public void StatusClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            statusSection.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

        }*/


        /* Constructors */

        /*public ParticularProjectPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if(wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("inworktasks"))) != null)
                {

                    isParsedCorrectly = true;

                    auxiliaryCollection = driver.FindElements(By.ClassName("menuSelectedItem"));
                    if (auxiliaryCollection.Count > 0) selectedProject = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("log_usr"));
                    if (auxiliaryCollection.Count == 1) loggedUser = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("usr_act"));
                    if (auxiliaryCollection.Count == 1) userActivitiesMenu = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = userActivitiesMenu.FindElements(By.TagName("li"));
                    if (auxiliaryCollection.Count > 0) userActivitiesList = auxiliaryCollection;

                    auxiliaryCollection = driver.FindElements(By.Id("jobsdashboard"));
                    if (auxiliaryCollection.Count == 1) jobsSection = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("planning"));
                    if (auxiliaryCollection.Count == 1) planningSection = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("status"));
                    if (auxiliaryCollection.Count > 0) statusSection = auxiliaryCollection.ElementAt(0);


                }

            }
        }*/

    }
}
