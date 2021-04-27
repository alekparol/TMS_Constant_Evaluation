using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements.TMS_Assingees_Subpage_Elements
{
    public class AssigneesFiltersPanel
    {
        /* Fields */

        private DropDown dueDate;
        private DropDown assignee;
        private DropDown job;
        private DropDown activity;
        private DropDown sourceLanguage;
        private DropDown targetLanguage;
        private DropDown workPlacementType;

        /* Properties */

        /*        public void DisplayFiltersPanel(IWebDriver driver)
        {
            if (FiltersButtonIsDisplayed == 1)
            {
                if (FiltersButtonIsClicked == 0)
                {
                    FiltersButtonClick(driver);
                }
            }
        }*/

        public DropDown DueDate
        {
            get
            {
                return dueDate;
            }
        }

        public DropDown Assignee
        {
            get
            {
                return assignee;
            }
        }

        public DropDown Job
        {
            get
            {
                return job;
            }
        }

        public DropDown Activity
        {
            get
            {
                return activity;
            }
        }

        public DropDown SourceLanguage
        {
            get
            {
                return sourceLanguage;
            }
        }

        public DropDown TargetLanguage
        {
            get
            {
                return targetLanguage;
            }
        }

        public DropDown WorkPlacementType
        {
            get
            {
                return workPlacementType;
            }
        }

        /* Methods */

        public void DueDateClick(IWebDriver driver)
        {
            dueDate.DropDownFilterClick(driver);
        }

        public void ChoseDueDateOption(IWebDriver driver, string chosenOption)
        {
            dueDate.ChoseDropDownOption(driver, chosenOption);
        }

        public void AssigneeClick(IWebDriver driver)
        {
            assignee.DropDownFilterClick(driver);
        }

        public void ChoseAssigneeOption(IWebDriver driver, string chosenOption)
        {
            assignee.ChoseDropDownOption(driver, chosenOption);
        }

        public void JobClick(IWebDriver driver)
        {
            job.DropDownFilterClick(driver);
        }

        public void ChoseJobOption(IWebDriver driver, string chosenOption)
        {
            job.ChoseDropDownOption(driver, chosenOption);
        }

        public void ActivityClick(IWebDriver driver)
        {
            activity.DropDownFilterClick(driver);
        }

        public void ChoseActivityOption(IWebDriver driver, string chosenOption)
        {
            activity.ChoseDropDownOption(driver, chosenOption);
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

        public void WorkPlacementTypeClick(IWebDriver driver)
        {
            workPlacementType.DropDownFilterClick(driver);
        }

        public void ChoseWorkPlacementTypeOption(IWebDriver driver, string chosenOption)
        {
            workPlacementType.ChoseDropDownOption(driver, chosenOption);
        }

        /* Constructors */

        public AssigneesFiltersPanel()
        {

        }

        public AssigneesFiltersPanel(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fp_btn")));

            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementExists(By.Id("cup_fpFlag_child")));

            dueDate = new DropDown(driver, "cup_fpFlag_titletext");
            assignee = new DropDown(driver, "cup_fpAssigneeId_titletext");
            job = new DropDown(driver, "cup_fpJobId_titletext");
            activity = new DropDown(driver, "cup_fpName_titletext");
            sourceLanguage = new DropDown(driver, "cup_fpSourceLanguage_titletext");
            targetLanguage = new DropDown(driver, "cup_fpTargetLanguage_titletext");
            workPlacementType = new DropDown(driver, "cup_fpIsExternalWork_titletext");

        }
    }
}
