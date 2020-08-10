using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects
{
    public class AssingeesOnClickJobsMenu
    {
        /* Fields */
     
        private IWebElement menuContainer;
        private IWebElement tagJobButton;

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

        public int TagJobButtonIsNull
        {
            get
            {
                if (MenuContainerIsNull == false)
                {
                    if (tagJobButton != null)
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

        public int TagJobButtonIsEnabled
        {
            get
            {
                if (TagJobButtonIsNull == 0)
                {
                    if (tagJobButton.Enabled)
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

        public void ClickTagJobsButton(IWebDriver driver)
        {
            if (TagJobButtonIsEnabled == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                tagJobButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        /* Constructors */
        public AssingeesOnClickJobsMenu(IWebDriver driver)
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
             
                auxiliaryEnumerable = auxiliaryCollection.Where(x => x.Text == "Tag Job");
                if (auxiliaryEnumerable.Count() == 1) tagJobButton = auxiliaryEnumerable.ElementAt(0);
            }

        }
    }
}
