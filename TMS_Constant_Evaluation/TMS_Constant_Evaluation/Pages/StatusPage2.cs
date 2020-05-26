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
    public class StatusPage2
    {

        /* Fields */

        private IWebElement pageName;

        private IWebElement viewBar; 
        private IWebElement activitiesSubPage;
        private IWebElement assigneesSubPage;

        private IWebElement filtersButton;

        /* Properties */
    
        public string PageName
        {
            get
            {
                return pageName.Text.ToLower().Trim();
            }
        }

        /* Methods */

        public void AssigneesClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            assigneesSubPage.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }
                
        /* Constructors */

        public StatusPage2(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn")));

            auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_itm"));
            if (auxiliaryCollection.Count > 0) pageName = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("sel_mnu_vws"));
            if (auxiliaryCollection.Count > 0) viewBar = auxiliaryCollection.ElementAt(0);

            if (viewBar != null)
            {

                auxiliaryCollection = viewBar.FindElements(By.Id("status"));
                if (auxiliaryCollection.Count > 0) activitiesSubPage = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = viewBar.FindElements(By.Id("statusassignees"));
                if (auxiliaryCollection.Count > 0) assigneesSubPage = auxiliaryCollection.ElementAt(0);

            }

            auxiliaryCollection = driver.FindElements(By.Id("cup_fp_btn"));
            if (auxiliaryCollection.Count > 0) filtersButton = auxiliaryCollection.ElementAt(0);

        }

    }
}
