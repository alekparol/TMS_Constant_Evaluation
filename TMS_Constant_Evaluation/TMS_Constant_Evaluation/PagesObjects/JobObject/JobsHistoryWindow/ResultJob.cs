using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
namespace TMS_Constant_Evaluation.PagesObjects.JobObject.JobsHistoryWindow
{
    public class ResultJob
    {
        /* Fields */

        private IWebElement jobsContainer;
        private IWebElement translatorName;

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

        public bool TranslatorNameIsNull
        {
            get
            {
                if (translatorName != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string GetTranlatorName
        {
            get
            {
                if (TranslatorNameIsNull == false)
                {
                    return translatorName.Text;
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
                if (TranslatorNameIsNull == false && JobsContainerIsNull == false)
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

        /* Constructors */

        public ResultJob()
        {

        }
        public ResultJob(IWebElement r_LObject)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            if (r_LObject.GetAttribute("class") == "r_L")
            {
                jobsContainer = r_LObject;

                auxiliaryCollection = r_LObject.FindElements(By.ClassName("icn_usr_lnk"));
                if (auxiliaryCollection.Count > 0) translatorName = auxiliaryCollection.ElementAt(0);

            }
        }
    }
}
