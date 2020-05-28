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
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dsh_tds_ttl")));

                IReadOnlyCollection<IWebElement> auxiliaryCollection;

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
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dsh_tds_ttl")));

                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                projectsList = driver.FindElements(By.ClassName("dsh_tds_ttl"));
                if (projectsList.Count > 0)
                {
                    isParsedCorrectly = true;
                    chosenProject = projectsList.Where(x => x.Text.ToLower() == chosenProjectName.ToLower()).ElementAt(0);
                }
            }
           
        }

    }
}
