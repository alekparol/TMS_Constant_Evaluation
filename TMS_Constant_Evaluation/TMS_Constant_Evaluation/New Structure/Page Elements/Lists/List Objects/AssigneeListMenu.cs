using OpenQA.Selenium;
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
    public class AssigneeListMenu : ListMenu
    {
        /* Fields */

        protected ListMenuButton tagJobButton;
        protected ListMenuButton markAsCompleteButton;
        protected ListMenuButton markAsPassedButton;
        protected ListMenuButton markAsFailedButton;
        protected ListMenuButton unclaimButton;
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

        public void ClickMarkAsComplete()
        {
            markAsCompleteButton.ButtonClick();
        }

        public void ClicMarkAsPassed()
        {
            markAsPassedButton.ButtonClick();
        }

        public void ClickMarkAsFailed()
        {
            markAsFailedButton.ButtonClick();
        }

        public void ClickUnclaim()
        {
            unclaimButton.ButtonClick();
        }

        public void ClickCopyToClipboard()
        {
            copyToClipboardButton.ButtonClick();
        }

        /* Constructors */
        public AssigneeListMenu(IWebDriver driver) : base (driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Menu panel was not found on the page or multiple were found."));

            menuPanel = auxiliaryCollection.ElementAt(0);
            menuOptions = menuPanel.FindElements(By.TagName("li"));

            tagJobButton = new ListMenuButton(menuOptions, driver, "mnu_tag");
            markAsCompleteButton = new ListMenuButton(menuOptions, driver, "mnu_acp");
            markAsPassedButton = new ListMenuButton(menuOptions, driver, "mnu_pas");
            markAsFailedButton = new ListMenuButton(menuOptions, driver, "mnu_del");
            unclaimButton = new ListMenuButton(menuOptions, driver, "mnu_unc");
            copyToClipboardButton = new ListMenuButton(menuOptions, driver, "mnu_cpy");
        }
    }
}
