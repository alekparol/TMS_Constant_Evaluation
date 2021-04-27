using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements;

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class StatusNavBar : NavBar
    {

        /* Fields */

        private NavBarButton activities;
        private NavBarButton alerts;
        private NavBarButton files;
        private NavBarButton assignees;

        /* Properties */     

        public NavBarButton Activities
        {
            get
            {
                return activities;
            }
        }

        public NavBarButton Alerts
        {
            get
            {
                return alerts;
            }
        }

        public NavBarButton Files
        {
            get
            {
                return files;
            }
        }

        public NavBarButton Assignees
        {
            get
            {
                return assignees;
            }
        }

        /* Methods */

        public void ActivitiesClick()
        {
            activities.ButtonClick();
        }
        public void AlertsClick()
        {
            alerts.ButtonClick();
        }

        public void FilesClick()
        {
            files.ButtonClick();
        }

        public void AssingeesClick()
        {
            assignees.ButtonClick();
        }

        /* Constructors */

        public StatusNavBar()
        {

        }

        public StatusNavBar(IWebDriver driver) : base(driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            activities = new NavBarButton(navBarPanel, driver, "status");
            alerts = new NavBarButton(navBarPanel, driver, "statusalerts");
            files = new NavBarButton(navBarPanel, driver, "statusfiles");
            assignees = new NavBarButton(navBarPanel, driver, "statusassignees");
        }
    }
}
