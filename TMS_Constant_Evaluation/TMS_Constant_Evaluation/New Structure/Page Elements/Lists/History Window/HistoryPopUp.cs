using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements.TMS_Assingees_Subpage_Elements;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Lists.History_Window
{
    public class HistoryPopUp
    {
        /* Fields */

        private IWebElement popUpContainer;

        private IWebElement reduceButton;
        private IWebElement fullScreenButton;
        private IWebElement closeButton;

        private HistoryFilterInitBar historyFiltersInitBar;
        private HistoryFiltersPanel historyFiltersPanel;

        public IWebElement errorMessage;

        /* Properties */

        public int ActivitiesCount
        {
            get
            {
                if (historyFiltersPanel != null)
                {
                    return historyFiltersPanel.Activity.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int CompletedByCount
        {
            get
            {
                if (historyFiltersPanel != null)
                {
                    return historyFiltersPanel.CompletedBy.DropDownOptionsCount;
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
                if (historyFiltersPanel != null)
                {
                    return historyFiltersPanel.SourceLanguage.DropDownOptionsCount;
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
                if (historyFiltersPanel != null)
                {
                    return historyFiltersPanel.TargetLanguage.DropDownOptionsCount;
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Methods */

        public void InitializeFiltersPanel(IWebDriver driver)
        {
            historyFiltersInitBar.FiltersInitButtonClick();
            historyFiltersPanel = new HistoryFiltersPanel(driver);
        }

        public void ActivityClick(IWebDriver driver)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.ActivityClick(driver);
        }

        public void ChoseActivityOption(IWebDriver driver, string chosenOption)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.ChoseActivityOption(driver, chosenOption);
            historyFiltersPanel = new HistoryFiltersPanel(driver);
        }

        public void CompletedByClick(IWebDriver driver)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.CompletedByClick(driver);
        }

        public void ChoseCompletedByOption(IWebDriver driver, string chosenOption)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.ChoseCompletedByOption(driver, chosenOption);
            historyFiltersPanel = new HistoryFiltersPanel(driver);
        }

        public void SourceLanguageClick(IWebDriver driver)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.SourceLanguageClick(driver);
        }

        public void ChoseSourceLanguageOption(IWebDriver driver, string chosenOption)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.ChoseSourceLanguageOption(driver, chosenOption);
            historyFiltersPanel = new HistoryFiltersPanel(driver);
        }

        public void TargetLanguageClick(IWebDriver driver)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.TargetLanguageClick(driver);
        }

        public void ChoseTargetLanguageOption(IWebDriver driver, string chosenOption)
        {
            if (historyFiltersPanel != null) historyFiltersPanel.ChoseTargetLanguageOption(driver, chosenOption);
            historyFiltersPanel = new HistoryFiltersPanel(driver);
        }

        /* Constructors */

        public HistoryPopUp(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            string auxiliaryString;

            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("r_L")));

            auxiliaryCollection = driver.FindElements(By.Id("pup"));

            if (auxiliaryCollection.Count != 1)
            {
                throw new Exception("Pop-up window do not exists or there exists more than one instances.");
            }

            popUpContainer = auxiliaryCollection.ElementAt(0);

            reduceButton = popUpContainer.FindElement(By.Id("pup_btn_r"));
            fullScreenButton = popUpContainer.FindElement(By.Id("pup_btn_f"));
            closeButton = popUpContainer.FindElement(By.Id("pup_btn_c"));

            historyFiltersInitBar = new HistoryFilterInitBar(driver);
        }
    }
}
