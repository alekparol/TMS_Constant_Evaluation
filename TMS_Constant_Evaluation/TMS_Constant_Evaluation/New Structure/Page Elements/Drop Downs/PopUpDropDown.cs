using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons
{
    public class PopUpDropDown
    {
        /* Fields */

        private IWebElement dropDownFilter;
        private IWebElement dropDownTitle;
        private IWebElement dropDownOptionContainer;
        private IReadOnlyCollection<IWebElement> dropDownOptions;

        private string dropDownFilterId;
        private string dropDownOptionContainerId;

        /* Properties */

        public bool DropDownIsExpanded
        {
            get
            {
                if (dropDownOptionContainer.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int DropDownOptionsCount
        {
            get
            {
                return dropDownOptions.Count;
            }
        }

        public string DropDownSelection
        {
            get
            {
                if (dropDownFilter != null)
                {
                    return dropDownFilter.Text;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /* Methods */

        public void DropDownFilterClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            dropDownFilter.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(dropDownOptionContainerId)));
        }

        public void ChoseDropDownOption(IWebDriver driver, string chosenOption)
        {
            DropDownFilterClick(driver);

            if (DropDownIsExpanded)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                dropDownOptions.Where(x =>
                                      x.Text.Equals(chosenOption))
                                     .ElementAt(0).Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("pup_lod")));
            }

        }

        /* Constructors */

        public PopUpDropDown()
        {

        }

        public PopUpDropDown(IWebDriver driver, string idLocator)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            dropDownFilterId = idLocator.Replace("titletext", "title");
            dropDownOptionContainerId = idLocator.Replace("titletext", "child");

            auxiliaryCollection = driver.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) dropDownTitle = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id(dropDownFilterId));
            if (auxiliaryCollection.Count == 1) dropDownFilter = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id(dropDownOptionContainerId));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Drop down menu of id {0} on the page was not found or found more than one.", dropDownOptionContainerId));

            dropDownOptionContainer = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = dropDownOptionContainer.FindElements(By.XPath(".//a"));
            dropDownOptions = auxiliaryCollection;
        }
    }
}
