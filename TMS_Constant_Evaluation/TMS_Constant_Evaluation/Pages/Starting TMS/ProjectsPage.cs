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
 * This class mean to model TMS starting page right after logging in. 
 * 
 * Preassumptions: 
 * 1. User is registered Lionbridge worker. 
 * 2. User turned on VPN correctly. 
 * 
 * TODO: 
 * 1. Check what kind of information we do need to get from three fields. 
 * 2. 
 * 
 */


namespace TMS_Constant_Evaluation.Pages
{
    public class ProjectsPage
    {

        /* Fields */

        private IReadOnlyCollection<IWebElement> projectsList;
        private IWebElement chosenProject;

        private bool isParsedCorrectly;

        /* Properties */

        /* Projects List Properties*/

        public bool ProjectListIsNull
        {
            get
            {
                if (projectsList != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int ProjectListCount
        {
            get
            {
                if (projectsList != null)
                {
                    return projectsList.Count;
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Chosen Project Properties*/
        
        public bool ChosenProjectIsNull
        {
            get
            {
                if (chosenProject != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string ChosenProjectName
        {
            get
            {
                if (chosenProject != null)
                {
                    return chosenProject.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int ChosenProjectIsDisplayed
        {
            get
            {
                if (chosenProject != null)
                {
                    if (chosenProject.Displayed)
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

        /* Constructor Properties */

        public bool IsParsingCorrect
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        /* Methods */

        public bool ClickChosenProject()
        {
            if (chosenProject != null)
            {
                chosenProject.Click();
                return true; 
            }
            else
            {
                return false;
            }
            
        }

        /* This method is used to initialize chosenProject field with a value. It returns:
         * 1 in case of success;
         * 0 in case of success but with a null value;
         * -1 in case when chosenProject field is initialized already. 
         */

        public int ChoseProject(string chosenProjectName)
        {

            IEnumerable<IWebElement> auxiliaryEnumerable;

            if (chosenProject == null)
            {
                auxiliaryEnumerable = projectsList.Where(x => x.Text.ToLower() == chosenProjectName.ToLower());
                if (auxiliaryEnumerable.Count() > 0) chosenProject = auxiliaryEnumerable.ElementAt(0);

                if (chosenProject == null)
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

        /* This method is used to chose and click chosenProject and it uses above methods. It returns:
         * 1 in case of proper initialization of chosenProject field with non-null value and clicking on it;
         * 0 in case of proper initialization of chosenProject fields with non-null value and not clicking on it; 
         * -1 in any other case when chosenProject wasn't initialized correctly and therefore ClickingChosensProject() wasn't even called. 
         */

        public int ChoseAndClickProject(string chosenProjectName)
        {
            int choseOperationResult = ChoseProject(chosenProjectName);

            if (choseOperationResult == 1)
            {
                if (ClickChosenProject())
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

        /* Constructors */

        public ProjectsPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dsh_tds_ttl")));

                projectsList = driver.FindElements(By.ClassName("dsh_tds_ttl"));
                if (projectsList.Count > 0)
                {
                    isParsedCorrectly = true;
                }
            }
        }

        public ProjectsPage(IWebDriver driver, string chosenProjectName)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IEnumerable<IWebElement> auxiliaryEnumerable;

                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dsh_tds_ttl")));

                projectsList = driver.FindElements(By.ClassName("dsh_tds_ttl"));
                if (projectsList.Count > 0)
                {
                    isParsedCorrectly = true;

                    auxiliaryEnumerable = projectsList.Where(x => x.Text.ToLower() == chosenProjectName.ToLower());
                    if (auxiliaryEnumerable.Count() > 0) chosenProject = auxiliaryEnumerable.ElementAt(0);
                }
            }
           
        }

    }
}
