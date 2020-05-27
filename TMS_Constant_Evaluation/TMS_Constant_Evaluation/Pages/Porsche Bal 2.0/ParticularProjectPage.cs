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
    public class ParticularProjectPage
    {
        /* Fields */
        
        private IWebElement selectedProject;

        private IWebElement jobsSection;
        private IWebElement planningSection;
        private IWebElement statusSection;

        /* Properties */

        public string SelectedProjectName
        {
            get
            {
                return selectedProject.Text.ToLower().Trim();
            }
        }
    
        /* Methods */ 
            
        public void JobsClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            jobsSection.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }

        public void PlanningClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            planningSection.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }
        public void StatusClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            statusSection.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }


        /* Constructors */

        public ParticularProjectPage(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("inworktasks")));

            auxiliaryCollection = driver.FindElements(By.ClassName("menuSelectedItem"));
            if (auxiliaryCollection.Count > 0) selectedProject = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("jobsdashboard"));
            if (auxiliaryCollection.Count > 0) jobsSection = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("planning"));
            if (auxiliaryCollection.Count > 0) planningSection = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("status"));
            if (auxiliaryCollection.Count > 0) statusSection = auxiliaryCollection.ElementAt(0);

        }

    }
}
