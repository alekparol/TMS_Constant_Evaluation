using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects
{
    public class OnClickJobsMenu
    {
        /* Fields */
        private IWebElement menuContainer;
        private bool menuContainerDisplayed;

        private IWebElement tagJobsButton;

        /* Properties */

        /* Methods */

        public void ClickTagJobsButton(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            tagJobsButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
        }

        /* Constructors */
        public OnClickJobsMenu(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='m1 lay_flt']")));

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IEnumerable<IWebElement> auxiliaryEnumerable;

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count == 1) menuContainer = auxiliaryCollection.ElementAt(0);

            if (menuContainer != null)
            {
                menuContainerDisplayed = true;

                auxiliaryCollection = menuContainer.FindElements(By.TagName("li"));
                auxiliaryEnumerable = auxiliaryCollection.Where(x => x.Text == "Tag Job");

                if (auxiliaryEnumerable.Count() == 1) tagJobsButton = auxiliaryEnumerable.ElementAt(0);

            }

        }
    }
}
