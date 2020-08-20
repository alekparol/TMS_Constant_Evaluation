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
using TMS_Constant_Evaluation.MenuLeftContent;

namespace TMS_Constant_Evaluation.MenuLeftContent
{
    public class TagsMenuButton : IMenuLeftContentButton
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
                    IReadOnlyCollection<IWebElement> tagButtonPopUpList = driver.FindElements(By.XPath("//*[@class='m3 lay_flt']"));

                    if (tagButtonPopUpList.Any(x => x.Displayed))
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

                // Wait for the Pop Up window to be displayed. 
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("m3 lay_flt")));
            }

        }

        /* Constructors */

        public TagsMenuButton(IWebDriver driver, string idLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            auxiliaryCollection = driver.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0);

        }

        public TagsMenuButton(IWebElement parentElement, IWebDriver driver, string idLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            auxiliaryCollection = parentElement.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0);

        }

    }
}
