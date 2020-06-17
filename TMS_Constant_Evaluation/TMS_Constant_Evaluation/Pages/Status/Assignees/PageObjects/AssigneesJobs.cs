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
    public class AssigneesJobs
    {

        /* Fields */

        private IWebElement jobsIWebElement;
        private string jobsName;

        private string languages;
        private string sourceLanguage;
        private string targetLanguage;

        private bool isParsedCorrectly;

        /* Properties */

        public IWebElement JobsIWebElement
        {
            get
            {
                return jobsIWebElement;
            }
        }

        public string JobsName
        {
            get
            {
                return jobsName;
            }
        }

        public string SourceLanguage
        {
            get
            {
                return sourceLanguage;
            }
        }

        public string TargetLanguage
        {
            get
            {
                return targetLanguage;
            }
        }
       
        public bool IsParsedCorrectly
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        /* Methods */

        /* Constructors */

        public AssigneesJobs(IWebElement r_LObject)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IEnumerable<IWebElement> auxiliarayEnumerable;

            Regex languagesRegex = new Regex("(\\w{2}\\-\\w{2})\\s{1}→\\s{1}(\\w{2}\\-\\w{2})");

            string auxiliaryString;

            if (r_LObject.GetAttribute("class") == "r_L")
            {
                isParsedCorrectly = true;

                string rowID = r_LObject.GetAttribute("rowid");
                auxiliarayEnumerable = r_LObject.FindElements(By.XPath("child::*")).Where(x => x.GetAttribute("id") == rowID);

                if (auxiliarayEnumerable.Count() == 1)
                {
                   
                    IWebElement checkboxRow = auxiliarayEnumerable.ElementAt(0);

                    auxiliaryCollection = checkboxRow.FindElements(By.ClassName("tlp_on"));
                    if (auxiliaryCollection.Count == 1) jobsName = auxiliaryCollection.ElementAt(0).Text;


                }

                auxiliarayEnumerable = r_LObject.FindElements(By.XPath("child::*")).Where(x => languagesRegex.IsMatch(x.Text));

                if (auxiliarayEnumerable.Count() == 1)
                {

                    jobsIWebElement = auxiliarayEnumerable.ElementAt(0);
                    languages = auxiliarayEnumerable.ElementAt(0).Text;

                    sourceLanguage = languagesRegex.Match(languages).Groups[1].Value;
                    targetLanguage = languagesRegex.Match(languages).Groups[2].Value;

                }
                

            }
        }

    }
}
