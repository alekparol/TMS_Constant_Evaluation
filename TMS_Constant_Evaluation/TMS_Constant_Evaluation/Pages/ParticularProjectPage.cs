﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.Pages.PagesObjects;

/* TODO: Make a new class for sections which would contain: 
 * 1. IWebElement section;
 * 2. Name = section.FindElements(By.ClassName("act_ttl")).ElementAt(0).Text;
 * 3. Notifications = 
 **/

namespace TMS_Constant_Evaluation.Pages
{
    public class ParticularProjectPage
    {
        /* Fields */

        private TabMenu myTabMenu;
        public ApplicationBoard myApplicationBoard;

        private MyProfile myProfileInstance;

        private ViewsMenu myViewsMenu;

        private IWebElement infoMessage;

        /* Properties */

        public string GetSelectedProjectName
        {
            get
            {
                if (myTabMenu.IsParsingCorrect)
                {
                    return myTabMenu.CurrentProjectName;
                }
                else
                {
                    return "";
                }          
            }
        }

        public string GetLoggedUserName
        {
            get
            {
                if (myApplicationBoard.IsParsingCorrect)
                {
                    return myApplicationBoard.GetUserName;
                }
                else
                {
                    return "";
                }
            }
        }

        public bool UserActivitiesAreClicked
        {
            get
            {
                if (myApplicationBoard.UserActivitiesAreClicked == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string GetInfoMessage
        {
            get
            {
                if (infoMessage != null)
                {
                    return infoMessage.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int JobsViewIsClicked
        {
            get
            {
                if (myViewsMenu != null)
                {
                    return myViewsMenu.JobsViewIsClicked;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int PlanningViewIsClicked
        {
            get
            {
                if (myViewsMenu != null)
                {
                    return myViewsMenu.PlanningViewIsClicked;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int StatusViewIsClicked
        {
            get
            {
                if (myViewsMenu != null)
                {
                    return myViewsMenu.StatusViewIsClicked;
                }
                else
                {
                    return -1;
                }
            }
        }

        public string GetNameOfClickedView
        {
            get
            {
                if (myViewsMenu != null)
                {
                    if (JobsViewIsClicked == 1)
                    {
                        return "Jobs";
                    }
                    else if (PlanningViewIsClicked == 1)
                    {
                        return "Planning";
                    }
                    else if (StatusViewIsClicked == 1)
                    {
                        return "Status";
                    }
                    else
                    {
                        return "Unspecified";
                    }
                }
                else
                {
                    return "";
                }      
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                if (myApplicationBoard.IsParsingCorrect && myTabMenu.IsParsingCorrect && myViewsMenu.IsParsingCorrect)
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

        public void LoggedUserClick(IWebDriver driver)
        {

            myApplicationBoard.LoggedUserClick(driver);

        }

        public void ProfileClick(IWebDriver driver)
        {

            myApplicationBoard.ProfileClick(driver);
            myProfileInstance = new MyProfile(driver);

        }

        public void ChangeItemsPerPage(IWebDriver driver)
        {
            if (myProfileInstance != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                myProfileInstance.ChangeNumberOfItems(driver, 25);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("jnotify-item-msg")));

                auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
                if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);
            }
        }
            
        public void JobsClick(IWebDriver driver)
        {

            myViewsMenu.JobsClick(driver);

        }

        public void PlanningClick(IWebDriver driver)
        {

            myViewsMenu.PlanningClick(driver);

        }
        public void StatusClick(IWebDriver driver)
        {

            myViewsMenu.StatusClick(driver);

        }

        /* Constructors */

        public ParticularProjectPage(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                myApplicationBoard = new ApplicationBoard(driver);
                myTabMenu = new TabMenu(driver);
                myViewsMenu = new ViewsMenu(driver);

            }
            else
            {
                myApplicationBoard = new ApplicationBoard();
                myTabMenu = new TabMenu();
                myViewsMenu = new ViewsMenu();
            }
        }
    }
}