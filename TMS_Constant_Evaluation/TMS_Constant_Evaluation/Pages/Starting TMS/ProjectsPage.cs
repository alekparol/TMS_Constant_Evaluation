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

        public IReadOnlyCollection<IWebElement> ProjectsList
        {
            get
            {
                return projectsList;
            }
        }

        public IWebElement ChosenProject
        {
            get
            {
                return chosenProject;
            }
        }

        public bool IsParsedCorrectly
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        /* Methods */

        public void ClickChosenProject()
        {
            chosenProject.Click();
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
