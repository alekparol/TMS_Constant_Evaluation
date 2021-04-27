using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons
{
    public abstract class Button
    {

        /* Fields */

        protected IWebDriver driver;

        protected IWebElement buttonWebElement;
        protected string displayedClass;

        protected WebDriverWait wait;

        /* Properties */

        public string GetButtonName
        {
            get
            {
                return buttonWebElement.Text;
            }
        }

        public abstract int ButtonIsClicked
        {
            get;
        }

        /* Methods */
        public void LoadingWait(string loadingId)
        {
            if (wait != null)
            {
                // Wait for the loading animation to appear and then to disapeear. 
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(loadingId)));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(loadingId)));
            }
        }

        public void HomePageLoadingWait()
        {
            LoadingWait("cup_lod");
        }

        public void ProfileLoadingWait()
        {
            LoadingWait("pup_lod");
        }

        public void ClickableWait(string xpathLocator)
        {
            // Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        public void BaseButtonClick(string loadingId, string xpathLocator)
        {
            if (buttonWebElement != null)
            {
                buttonWebElement.Click();

                LoadingWait(loadingId);
                ClickableWait(xpathLocator);
            }
        }

        public void ButtonClick()
        {
            if (buttonWebElement != null)
            {
                buttonWebElement.Click();

                // Wait for the loading animation to appear and then to disapeear. 
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

                // Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='hdr_sub_sel tlp_on']")));
            }
        }


        /* Constructors */

        public Button()
        {

        }

        public Button(IWebElement parentElement, IWebDriver driver, string idLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            auxiliaryCollection = parentElement.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0);
        }

        public Button(IWebElement buttonWebElement, WebDriverWait wait)
        {
            this.wait = wait;
            this.buttonWebElement = buttonWebElement;
        }
    }
}
