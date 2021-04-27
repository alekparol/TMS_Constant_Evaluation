using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.PagesObjects;

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class LeftMenu
    {

        /* Fields */

        private IWebElement tagsPanel;

        /* To fill */

        private IWebElement viewsPanel;

        private LeftMenuButton tasksView;
        private LeftMenuButton jobsView;
        private LeftMenuButton planningView;
        private LeftMenuButton statusView;
        private LeftMenuButton activityLogsView;
        private LeftMenuButton reportsView;

        private LeftMenuButton referencesView;
        private LeftMenuButton deliverablesView;

        private LeftMenuButton categoriesView;
        private LeftMenuButton usersView;
        private LeftMenuButton workflowsView;

        /* Properties */

        public LeftMenuButton TasksView
        {
            get
            {
                return tasksView;
            }
        }

        public LeftMenuButton JobsView
        {
            get
            {
                return jobsView;
            }
        }

        public LeftMenuButton PlanningView
        {
            get
            {
                return planningView;
            }
        }

        public LeftMenuButton StatusView
        {
            get
            {
                return statusView;
            }
        }

        public LeftMenuButton ActivityLogsView
        {
            get
            {
                return activityLogsView;
            }
        }

        public LeftMenuButton ReportsView
        {
            get
            {
                return reportsView;
            }
        }

        public LeftMenuButton ReferencesView
        {
            get
            {
                return referencesView;
            }
        }

        public LeftMenuButton DeliverablesView
        {
            get
            {
                return deliverablesView;
            }
        }

        public LeftMenuButton CategoriesView
        {
            get
            {
                return categoriesView;
            }
        }

        public LeftMenuButton UsersView
        {
            get
            {
                return usersView;
            }
        }

        public LeftMenuButton WorkflowsView
        {
            get
            {
                return workflowsView;
            }
        }

        /* Methods */

        /* Constructors */

        public LeftMenu()
        {

        }

        public LeftMenu(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lup_actionPanel")));

            auxiliaryCollection = driver.FindElements(By.Id("lup_actionPanel"));

            if (auxiliaryCollection.Count != 1) throw new Exception("Left menu panel was not found on the page or was found more than one.");
            viewsPanel = auxiliaryCollection.ElementAt(0);

            tasksView = new LeftMenuButton(viewsPanel, driver, "inworktasks");
            jobsView = new LeftMenuButton(viewsPanel, driver, "jobsdashboard");
            planningView = new LeftMenuButton(viewsPanel, driver, "planning");
            statusView = new LeftMenuButton(viewsPanel, driver, "status");
            activityLogsView = new LeftMenuButton(viewsPanel, driver, "referencelog");
            reportsView = new LeftMenuButton(viewsPanel, driver, "reports");

            referencesView = new LeftMenuButton(viewsPanel, driver, "documentreference");
            deliverablesView = new LeftMenuButton(viewsPanel, driver, "documentdeliverable");

            categoriesView = new LeftMenuButton(viewsPanel, driver, "admincategories");
            usersView = new LeftMenuButton(viewsPanel, driver, "projectuser");
            workflowsView = new LeftMenuButton(viewsPanel, driver, "adminconfig");
        }
    }
}
