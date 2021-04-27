using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.Pages
{
    public class TMSStatusPage : TMSProjectHomePage
    {

        /* Fields */

        private StatusNavBar statusNavBar;
        private FiltersInitBar statusFiltersInitBar;

        private StatusFiltersPanel statusFiltersPanel; 

        public IWebElement errorMessage;

        /* Properties */

        public string PageName
        {
            get
            {
                return statusNavBar.GetPageName;
            }
        }

        public int DueDateCount
        {
            get
            {
                if (statusFiltersPanel != null)
                {
                    return statusFiltersPanel.DueDate.DropDownOptionsCount;
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
                if (statusFiltersPanel != null)
                {
                    return statusFiltersPanel.Job.DropDownOptionsCount;
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
                if (statusFiltersPanel != null)
                {
                    return statusFiltersPanel.Activity.DropDownOptionsCount;
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
                if (statusFiltersPanel != null)
                {
                    return statusFiltersPanel.SourceLanguage.DropDownOptionsCount;
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
                if (statusFiltersPanel != null)
                {
                    return statusFiltersPanel.TargetLanguage.DropDownOptionsCount;
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
                if (statusFiltersPanel != null)
                {
                    return statusFiltersPanel.WorkPlacementType.DropDownOptionsCount;
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
            statusNavBar.ActivitiesClick();
        }

        public void AlertsClick()
        {
            statusNavBar.AlertsClick();
        }

        public void FilesClick()
        {
            statusNavBar.FilesClick();
        }

        public void AssingeeClick()
        {
            statusNavBar.AssingeesClick();
        }

        public void InitializeFiltersPanel(IWebDriver driver)
        {
            statusFiltersInitBar.FiltersInitButtonClick();
            statusFiltersPanel = new StatusFiltersPanel(driver);
        }

        public void DueDateClick(IWebDriver driver)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.DueDateClick(driver);
        }

        public void ChoseDueDateOption(IWebDriver driver, string chosenOption)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ChoseDueDateOption(driver, chosenOption);
        }

        public void JobClick(IWebDriver driver)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.JobClick(driver);
        }

        public void ChoseJobOption(IWebDriver driver, string chosenOption)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ChoseJobOption(driver, chosenOption);
        }

        public void ActivityClick(IWebDriver driver)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ActivityClick(driver);
        }

        public void ChoseActivityOption(IWebDriver driver, string chosenOption)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ChoseActivityOption(driver, chosenOption);
        }

        public void SourceLanguageClick(IWebDriver driver)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.SourceLanguageClick(driver);
        }

        public void ChoseSourceLanguageOption(IWebDriver driver, string chosenOption)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ChoseSourceLanguageOption(driver, chosenOption);
        }

        public void TargetLanguageClick(IWebDriver driver)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.TargetLanguageClick(driver);
        }

        public void ChoseTargetLanguageOption(IWebDriver driver, string chosenOption)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ChoseTargetLanguageOption(driver, chosenOption);
        }

        public void WorkPlacementTypeClick(IWebDriver driver)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.WorkPlacementTypeClick(driver);
        }

        public void ChoseWorkPlacementTypeOption(IWebDriver driver, string chosenOption)
        {
            if (statusFiltersPanel != null) statusFiltersPanel.ChoseWorkPlacementTypeOption(driver, chosenOption);
        }

        /* Constructors */

        public TMSStatusPage(IWebDriver driver) : base(driver)
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
             
                statusNavBar = new StatusNavBar(driver);
                statusFiltersInitBar = new FiltersInitBar(driver);

            }   
        }
    }
}
