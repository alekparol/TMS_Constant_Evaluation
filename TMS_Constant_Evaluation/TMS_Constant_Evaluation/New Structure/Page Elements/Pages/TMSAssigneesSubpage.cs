using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements.TMS_Assingees_Subpage_Elements;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.New_Structure
{
    public class TMSAssigneesSubpage : TMSProjectHomePage
    {

        /* Fields */

        private StatusNavBar assigneesNavBar;
        private FiltersInitBar assigneesFiltersInitBar;

        private AssigneesFiltersPanel assigneesFiltersPanel;

        public IWebElement errorMessage;

        /* Properties */

        public string PageName
        {
            get
            {
                return assigneesNavBar.GetPageName;
            }
        }

        public int DueDateCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.DueDate.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int AssigneeCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.Assignee.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int JobCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.Job.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int ActivitiesCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.Activity.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int SourceLanguageCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.SourceLanguage.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int TargetLanguageCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.TargetLanguage.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int WorkPlacementTypeCount
        {
            get
            {
                if (assigneesFiltersPanel != null)
                {
                    return assigneesFiltersPanel.WorkPlacementType.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Methods */

        public void ActivitiesClick()
        {
            assigneesNavBar.ActivitiesClick();
        }

        public void AlertsClick()
        {
            assigneesNavBar.AlertsClick();
        }

        public void FilesClick()
        {
            assigneesNavBar.FilesClick();
        }

        public void AssingeeClick()
        {
            assigneesNavBar.AssingeesClick();
        }

        public void InitializeFiltersPanel(IWebDriver driver)
        {
            assigneesFiltersInitBar.FiltersInitButtonClick();
            assigneesFiltersPanel = new AssigneesFiltersPanel(driver);
        }

        public void DueDateClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.DueDateClick(driver);
        }

        public void ChoseDueDateOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseDueDateOption(driver, chosenOption);
        }

        public void AssigneeClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.AssigneeClick(driver);
        }

        public void ChoseAssigneeOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseAssigneeOption(driver, chosenOption);
        }

        public void JobClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.JobClick(driver);
        }

        public void ChoseJobOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseJobOption(driver, chosenOption);
        }

        public void ActivityClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ActivityClick(driver);
        }

        public void ChoseActivityOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseActivityOption(driver, chosenOption);
        }

        public void SourceLanguageClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.SourceLanguageClick(driver);
        }

        public void ChoseSourceLanguageOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseSourceLanguageOption(driver, chosenOption);
        }

        public void TargetLanguageClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.TargetLanguageClick(driver);
        }

        public void ChoseTargetLanguageOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseTargetLanguageOption(driver, chosenOption);
        }

        public void WorkPlacementTypeClick(IWebDriver driver)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.WorkPlacementTypeClick(driver);
        }

        public void ChoseWorkPlacementTypeOption(IWebDriver driver, string chosenOption)
        {
            if (assigneesFiltersPanel != null) assigneesFiltersPanel.ChoseWorkPlacementTypeOption(driver, chosenOption);
        }

        /* Constructors */

        public TMSAssigneesSubpage(IWebDriver driver) : base(driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                string auxiliaryString;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("statusassignees")));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count != 0) errorMessage = auxiliaryCollection.ElementAt(0);

                assigneesNavBar = new StatusNavBar(driver);
                assigneesFiltersInitBar = new FiltersInitBar(driver);

            }
        }
    }
}
