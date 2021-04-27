using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS_Constant_Evaluation.Pages
{
    public class TMSProjectsPage
    {

        /* Fields */

        protected IWebDriver driver;

        protected IReadOnlyCollection<IWebElement> projectsList;

        /* Properties */

        /// <summary>
        /// Returns a value of projects list length. 
        /// </summary>
        public int ProjectListCount
        {
            get
            {
                return projectsList.Count;
            }
        }

        /* Methods */

        /// <summary>
        /// Clicks on the first project thats name matches with the passed argument and then awaits for project page to be displayed.
        /// </summary>
        /// <param name="chosenProjectName"> denotes the name of the TMS project one wants to enter.</param>
        public void ClickChosenProject(string chosenProjectName)
        {
            IWebElement chosenProject = projectsList.FirstOrDefault(x => x.Text.ToLower()
                                                                          .Equals(chosenProjectName.ToLower()));

            if (chosenProject == null) throw new Exception(String.Format("TMS project of a name {0} not found on the home page.", chosenProjectName));
            chosenProject.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("newtasks")));
        }

        /* Constructors */

        /// <summary>
        /// Creates a new object. Firstly awaits for the projects list to be displayed and then initialize its field with it. 
        /// </summary>
        /// <exception cref="System.Exception">Thrown when actual URL adress is different than https:\/\/tms.lionbridge.com\/</exception>
        /// <exception cref="System.Exception">Thrown when initialized project list is lesser or equal to 0. In this case it is a blocker.</exception>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public TMSProjectsPage(IWebDriver driver)
        {
            this.driver = driver;

            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dsh_tds_ttl")));

            projectsList = driver.FindElements(By.ClassName("dsh_tds_ttl"));

            if (projectsList.Count <= 0)
            {
                throw new Exception(String.Format("Projects list was not initialized properly."));
            }
        }
    }
}
