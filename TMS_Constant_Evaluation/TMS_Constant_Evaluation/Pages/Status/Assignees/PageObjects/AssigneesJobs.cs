using OpenQA.Selenium;
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

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    public class AssigneeJobs
    {

        /* Fields */

        private IWebElement jobsButton;

        private string languages;
        private string sourceLanguage;
        private string targetLanguage;

        private IWebElement jobsName;

        /* Properties */

        public bool JobsButtonIsNull
        {
            get
            {
                if (jobsButton != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int JobsButtonIsEnabled
        {
            get
            {
                if (JobsButtonIsNull == false)
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

        public int LanguagesIsNull
        {
            get
            {
                if (JobsButtonIsNull == false)
                {
                    if (languages != null)
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

        public string GetSourceLanguage
        {
            get
            {
                if (LanguagesIsNull == 0)
                {
                    return sourceLanguage;
                }
                else
                {
                    return "";
                }
            }
        }

        public string GetTargetLanguage
        {
            get
            {
                if (LanguagesIsNull == 0)
                {
                    return targetLanguage;
                }
                else
                {
                    return "";
                }
            }
        }


        public IWebElement JobsIWebElement
        {
            get
            {
                return jobsButton;
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
                if (JobsButtonIsNull == false && JobsNameIsNull == false)
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

        public AssigneeJobs(IWebElement r_LObject)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IEnumerable<IWebElement> auxiliarayEnumerable;

            Regex languagesRegex = new Regex("(\\w{2,3}\\-\\w{2,3})\\s{1}→\\s{1}(\\w{2,3}\\-\\w{2,3})");

            if (r_LObject.GetAttribute("class") == "r_L")
            {

                auxiliaryCollection = r_LObject.FindElements(By.ClassName("firstColumn"));
                if (auxiliaryCollection.Count > 0) jobsName = auxiliaryCollection.ElementAt(0);

                auxiliarayEnumerable = r_LObject.FindElements(By.XPath("child::*")).Where(x => languagesRegex.IsMatch(x.Text));
                if (auxiliarayEnumerable.Count() == 1)
                {
                    jobsButton = auxiliarayEnumerable.ElementAt(0);
                    languages = auxiliarayEnumerable.ElementAt(0).Text;

                    sourceLanguage = languagesRegex.Match(languages).Groups[1].Value;
                    targetLanguage = languagesRegex.Match(languages).Groups[2].Value;
                }               
            }
        }
    }
}
