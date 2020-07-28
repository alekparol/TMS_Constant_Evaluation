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

namespace TMS_Constant_Evaluation.PagesObjects
{
    class SearchEngine
    {

        /* Those two elements are displayed on every page after particular project page. 
         * TODO: Add them to some class which from they could be inherited.*/
        private IWebElement searchField;
        private IWebElement searchButton;

        public void SearchJobByName(string jobName, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            searchField.SendKeys(jobName);
            searchButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }

        public SearchEngine(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                string auxiliaryString;

                if (wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cup_fp_btn"))) != null)
                {

                    auxiliaryCollection = driver.FindElements(By.Id("sjid"));
                    if (auxiliaryCollection.Count == 1) searchField = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = driver.FindElements(By.Id("sjib"));
                    if (auxiliaryCollection.Count == 1) searchButton = auxiliaryCollection.ElementAt(0);

                }
            }
        }
    }
}
