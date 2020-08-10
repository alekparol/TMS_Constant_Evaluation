using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation.PagesObjects.JobObject
{
    public class JobsOnClickJobsMenu
    {

        /* Fields */

        private IWebElement menuContainer;
        private IWebElement showHistoryButton;

        /* Properties */

        public bool MenuContainerIsNull
        {
            get
            {
                if (menuContainer != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public int MenuContainerIsDisplayed
        {
            get
            {
                if (MenuContainerIsNull == false)
                {
                    if (menuContainer.Displayed)
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

        public int ShowHistoryButtonIsNull
        {
            get
            {
                if (MenuContainerIsNull == false)
                {
                    if (showHistoryButton != null)
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
        }

        public int ShowHistoryButtonIsEnabled
        {
            get
            {
                if (ShowHistoryButtonIsNull == 0)
                {
                    if (showHistoryButton.Enabled)
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

        /* Methods */

        public void ClickShowHistoryButton(IWebDriver driver)
        {
            if (ShowHistoryButtonIsEnabled == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                showHistoryButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_cnt")));
            }
        }

        /* Constructors */
        public JobsOnClickJobsMenu(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IEnumerable<IWebElement> auxiliaryEnumerable;

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count == 1) menuContainer = auxiliaryCollection.ElementAt(0);

            if (menuContainer != null)
            {
                auxiliaryCollection = menuContainer.FindElements(By.TagName("li"));

                auxiliaryEnumerable = auxiliaryCollection.Where(x => x.Text == "Show History");
                if (auxiliaryEnumerable.Count() == 1) showHistoryButton = auxiliaryEnumerable.ElementAt(0);
            }

        }

    }
}
