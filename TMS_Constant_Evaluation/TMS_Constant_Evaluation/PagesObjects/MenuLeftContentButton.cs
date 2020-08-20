using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

namespace TMS_Constant_Evaluation.PagesObjects
{
    public class MenuLeftContentButton
    {

        /* Fields */

        private IWebDriver driver;

        private IWebElement buttonWebElement;


        /* Properties */

          public bool ButtonIsNull
        {
            get
            {
                if (buttonWebElement != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int ButtonIsClickable
        {
            get
            {
                if (ButtonIsNull == false)
                {
                    if (buttonWebElement.Displayed)
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

        public int ButtonIsClicked
        {
            get
            {
                if (ButtonIsNull == false)
                {
                    string className = buttonWebElement.GetAttribute("class");

                    if (className == "treeviewLISelected")
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
        public void ButtonClick()
        {
            if (buttonWebElement != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                buttonWebElement.Click();

                // Wait for the loading animation to appear and then to disapeear. 
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                // Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='hdr_sub_sel tlp_on']")));
            }

        }


        /* Constructors */

        public MenuLeftContentButton(IWebDriver driver, string idLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;
            
            auxiliaryCollection = driver.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0); 

        }

        public MenuLeftContentButton(IWebElement parentElement, IWebDriver driver, string idLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            auxiliaryCollection = parentElement.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0);

        }

    }
}
