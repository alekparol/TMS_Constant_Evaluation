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

namespace TMS_Constant_Evaluation.PagesObjects.JobObject
{
    public class Jobs
    {

        /* Fields */

        private IWebElement jobsContainer;
        private IWebElement jobsButton;

        private IWebElement jobsName;

        /* Properties */

        public bool JobsContainerIsNull
        {
            get
            {
                if (jobsContainer != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int JobIsSelected
        {
            get
            {
                if (JobsContainerIsNull == false)
                {
                    if (jobsContainer.GetAttribute("class").Contains("row_slt"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int JobsButtonIsNull
        {
            get
            {
                if (JobsContainerIsNull == false)
                {
                    if (jobsButton != null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int JobsButtonIsEnabled
        {
            get
            {
                if (JobsButtonIsNull == 0)
                {
                    if (jobsButton.Enabled)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public IWebElement GetJobButton
        {
            get
            {
                if (JobsButtonIsNull == 0)
                {
                    return jobsButton;
                }
                else
                {
                    return null;
                }
            }
        }      
        public bool JobsNameIsNull
        {
            get
            {
                if (jobsName != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string GetJobsName
        {
            get
            {
                if (JobsNameIsNull == false)
                {
                    return jobsName.Text;
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
                if (JobsButtonIsNull == 0 && JobsNameIsNull == false)
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

        public void JobButtonClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            jobsButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"m1 lay_flt\"]")));
        }

        /* Constructors */

        public Jobs(IWebElement r_LObject)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IEnumerable<IWebElement> auxiliarayEnumerable;

            Regex languagesRegex = new Regex("(\\w{2,3}\\-\\w{2,3})\\s{1}→\\s{1}(\\w{2,3}\\-\\w{2,3})");

            if (r_LObject.GetAttribute("class") == "r_L")
            {
                jobsContainer = r_LObject;

                auxiliaryCollection = r_LObject.FindElements(By.ClassName("firstColumn"));
                if (auxiliaryCollection.Count > 0) jobsName = auxiliaryCollection.ElementAt(0);

                auxiliarayEnumerable = r_LObject.FindElements(By.XPath("child::*")).Where(x => languagesRegex.IsMatch(x.Text));
                if (auxiliarayEnumerable.Count() == 1)
                {
                    jobsButton = auxiliarayEnumerable.ElementAt(0);
                }
            }
        }

    }
}
