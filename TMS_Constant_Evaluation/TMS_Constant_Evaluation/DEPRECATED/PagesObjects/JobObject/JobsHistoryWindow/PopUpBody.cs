using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
using TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects;
using TMS_Constant_Evaluation.PagesObjects.AssigneeObject;

namespace TMS_Constant_Evaluation.PagesObjects.JobObject.JobsHistoryWindow
{
    public class PopUpBody
    {

        /* Fields */

        private IWebElement popUpContainer;

        private IWebElement reduceButton;
        private IWebElement fullScreenButton;
        private IWebElement closeButton;

        private IWebElement titleBar;

        /* Properties */

        public bool PopUpContainerIsNull
        {
            get
            {
                if (popUpContainer != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int PopUpIsDisplayed
        {
            get
            {
                if (PopUpContainerIsNull == false)
                {
                    if (popUpContainer.Displayed)
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

        public int ReduceButtonIsNull
        {
            get
            {
                if (PopUpContainerIsNull == false)
                {
                    if (reduceButton != null)
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

        public int ReduceButtonIsEnabled
        {
            get
            {
                if (ReduceButtonIsNull == 0)
                {
                    if (reduceButton.Enabled)
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

        public int FullScreenButtonIsNull
        {
            get
            {
                if (PopUpContainerIsNull == false)
                {
                    if (fullScreenButton != null)
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

        public int FullScreenButtonIsEnabled
        {
            get
            {
                if (FullScreenButtonIsNull == 0)
                {
                    if (fullScreenButton.Enabled)
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

        public int CloseButtonIsNull
        {
            get
            {
                if (PopUpContainerIsNull == false)
                {
                    if (closeButton != null)
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

        public int CloseButtonIsEnabled
        {
            get
            {
                if (CloseButtonIsNull == 0)
                {
                    if (closeButton.Enabled)
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

        public bool TitleBarIsNull
        {
            get
            {
                if (titleBar != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string GetTitleBar
        {
            get
            {
                if (TitleBarIsNull == false)
                {
                    return titleBar.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        /* Methods */

        public void CloseButtonClick(IWebDriver driver)
        {
            if (CloseButtonIsEnabled == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                closeButton.Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("pup")));
            }
        }

        /* Constructors */

        public PopUpBody(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup")));

                auxiliaryCollection = driver.FindElements(By.Id("pup"));
                if (auxiliaryCollection.Count == 1)
                {
                    popUpContainer = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = popUpContainer.FindElements(By.Id("pup_btn_r"));
                    if (auxiliaryCollection.Count == 1) reduceButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = popUpContainer.FindElements(By.Id("pup_btn_f"));
                    if (auxiliaryCollection.Count == 1) fullScreenButton = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = popUpContainer.FindElements(By.Id("pup_btn_c"));
                    if (auxiliaryCollection.Count == 1) closeButton = auxiliaryCollection.ElementAt(0);

                }

                auxiliaryCollection = driver.FindElements(By.Id("pup_hp"));
                if (auxiliaryCollection.Count == 1) titleBar = auxiliaryCollection.ElementAt(0);
            }
        }
    }
}
