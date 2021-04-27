using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons
{
    public class ListMenuButton
    {
        /* Fields */

        protected IWebDriver driver;

        protected IWebElement buttonWebElement;

        /* Properties */

        public string GetButtonName
        {
            get
            {
                return buttonWebElement.Text;
            }
        }

        /* Methods */
        public void ButtonClick()
        {
            if (buttonWebElement != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                buttonWebElement.Click();

                // Wait for the loading animation to appear and then to disapeear. 
                //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }


        /* Constructors */

        public ListMenuButton()
        {

        }

        public ListMenuButton(IWebElement parentElement, IWebDriver driver, string xpathClassLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            auxiliaryCollection = parentElement.FindElements(By.XPath(xpathClassLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0);
        }

        public ListMenuButton(IReadOnlyCollection<IWebElement> listMenuCollection, IWebDriver driver, string classLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            buttonWebElement = listMenuCollection.FirstOrDefault(x => x.GetAttribute("class")
                                                                       .Contains(classLocator));
        }

        public ListMenuButton(IReadOnlyCollection<IWebElement> listMenuCollection, IWebDriver driver, string classLocator, string containingText)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            buttonWebElement = listMenuCollection.FirstOrDefault(x => x.GetAttribute("class")
                                                                       .Contains(classLocator) 
                                                                   && x.Text.Contains(containingText));
        }
    }
}
