using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_Home_Page_Elements;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Lists.List_Objects
{
    public class JobsListMenu : ListMenu
    {
        /* Fields */

        private IWebDriver driver;

        protected ListMenuButton tagJobButton;
        protected ListMenuButton editButton;
        protected ListMenuButton hideButton;
        protected ListMenuButton createCopyButton;
        protected ListMenuButton createRelatedJobButton;
        protected ListMenuButton cancelButton;
        protected ListMenuButton showSourceButton;
        protected ListMenuButton showWordCountButton;
        protected ListMenuButton showDeliveryButton;
        protected ListMenuButton showHistoryButton;
        protected ListMenuButton showAuditLogsButton;
        protected ListMenuButton copyToClipboardButton;

        /* Properties */

        public int MenuOptionsCount
        {
            get
            {
                return menuOptions.Count;
            }
        }

        /* Methods */

        public void ClickTagJobs()
        {
            tagJobButton.ButtonClick();
        }

        public void ClickEdit()
        {
            editButton.ButtonClick();
        }

        public void ClicHide()
        {
            hideButton.ButtonClick();
        }

        public void ClickCreateCopy()
        {
            createCopyButton.ButtonClick();
        }

        public void ClickCreateRelatedJob()
        {
            createRelatedJobButton.ButtonClick();
        }

        public void ClickCancel()
        {
            cancelButton.ButtonClick();
        }
        public void ClickShowSource()
        {
            showSourceButton.ButtonClick();
        }
        public void ClickShowWordCount()
        {
            showWordCountButton.ButtonClick();
        }

        public void ClickShowDelivery()
        {
            showDeliveryButton.ButtonClick();
        }

        public void ClickShowHistory()
        {
            showHistoryButton.ButtonClick();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_cnt")));
        }

        public void ClickShowAuditLogs()
        {
            showAuditLogsButton.ButtonClick();
        }

        public void ClickCopyToClipboard()
        {
            copyToClipboardButton.ButtonClick();
        }

        /* Constructors */
        public JobsListMenu(IWebDriver driver) : base(driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.driver = driver;

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Menu panel was not found on the page or multiple were found."));

            menuPanel = auxiliaryCollection.ElementAt(0);
            menuOptions = menuPanel.FindElements(By.TagName("li"));

            tagJobButton = new ListMenuButton(menuOptions, driver, "mnu_tag");
            editButton = new ListMenuButton(menuOptions, driver, "mnu_edt");
            hideButton = new ListMenuButton(menuOptions, driver, "mnu_shj");
            createCopyButton = new ListMenuButton(menuOptions, driver, "mnu_cpy");
            createRelatedJobButton = new ListMenuButton(menuOptions, driver, "mnu_null");
            cancelButton = new ListMenuButton(menuOptions, driver, "mnu_ccl");
            showSourceButton = new ListMenuButton(menuOptions, driver, "mnu_shw", "Source Files");
            showWordCountButton = new ListMenuButton(menuOptions, driver, "mnu_tag", "Word Counts");
            showHistoryButton = new ListMenuButton(menuOptions, driver, "mnu_fld");
            showAuditLogsButton = new ListMenuButton(menuOptions, driver, "mnu_tag", "Audit Logs");
            copyToClipboardButton = new ListMenuButton(menuOptions, driver, "mnu_cpy");
        }
    }
}
