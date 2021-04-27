using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements
{
    public class HistoryItemElement : ItemElement
    {
        /* Fields */

        private IWebElement stepName;
        private IWebElement stepStatus;
        private IWebElement stepCompletedBy;

        /* Properties */

        public string StepName
        {
            get
            {
                return stepName.Text;
            }
        }

        public string StepStatus
        {
            get
            {
                return stepStatus.Text;
            }
        }

        public string StepCompletedBy
        {
            get
            {
                return stepCompletedBy.Text;
            }
        }

        public bool IsSelected
        {
            get
            {
                if (elementObject.GetAttribute("class").Contains("row_slt"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /* Methods */

        public void StepCompletedByClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            stepCompletedBy.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("puk_cnt")));
        }

        /* Constructors */

        public HistoryItemElement()
        {

        }
        public HistoryItemElement(IWebElement elementObject) : base(elementObject)
        {
            stepName = elementTableData.ElementAt(2);
            stepStatus = elementTableData.ElementAt(3);
            stepCompletedBy = elementObject.FindElement(By.XPath(".//*[contains(@class,\"icn_usr_lnk\")]"));
        }
    }
}
