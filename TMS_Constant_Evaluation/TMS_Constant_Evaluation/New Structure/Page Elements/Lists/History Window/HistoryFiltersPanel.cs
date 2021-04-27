using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Lists.History_Window
{
    public class HistoryFiltersPanel
    {
        /* Fields */

        private PopUpDropDown activity;
        private PopUpDropDown completedBy;
        private PopUpDropDown sourceLanguage;
        private PopUpDropDown targetLanguage;

        /* Properties */

        public PopUpDropDown Activity
        {
            get
            {
                return activity;
            }
        }

        public PopUpDropDown CompletedBy
        {
            get
            {
                return completedBy;
            }
        }

        public PopUpDropDown SourceLanguage
        {
            get
            {
                return sourceLanguage;
            }
        }

        public PopUpDropDown TargetLanguage
        {
            get
            {
                return targetLanguage;
            }
        }

        /* Methods */

        public void ActivityClick(IWebDriver driver)
        {
            activity.DropDownFilterClick(driver);
        }

        public void ChoseActivityOption(IWebDriver driver, string chosenOption)
        {
            activity.ChoseDropDownOption(driver, chosenOption);
        }

        public void CompletedByClick(IWebDriver driver)
        {
            completedBy.DropDownFilterClick(driver);
        }

        public void ChoseCompletedByOption(IWebDriver driver, string chosenOption)
        {
            completedBy.ChoseDropDownOption(driver, chosenOption);
        }

        public void SourceLanguageClick(IWebDriver driver)
        {
            sourceLanguage.DropDownFilterClick(driver);
        }

        public void ChoseSourceLanguageOption(IWebDriver driver, string chosenOption)
        {
            sourceLanguage.ChoseDropDownOption(driver, chosenOption);
        }

        public void TargetLanguageClick(IWebDriver driver)
        {
            targetLanguage.DropDownFilterClick(driver);
        }

        public void ChoseTargetLanguageOption(IWebDriver driver, string chosenOption)
        {
            targetLanguage.ChoseDropDownOption(driver, chosenOption);
        }

        /* Constructors */

        public HistoryFiltersPanel()
        {

        }

        public HistoryFiltersPanel(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementExists(By.Id("pup_fpName_child")));

            activity = new PopUpDropDown(driver, "pup_fpName_titletext");
            completedBy = new PopUpDropDown(driver, "pup_fpFullName_titletext");
            sourceLanguage = new PopUpDropDown(driver, "pup_fpSourceLanguage_titletext");
            targetLanguage = new PopUpDropDown(driver, "pup_fpTargetLanguage_titletext");
        }
    }
}
