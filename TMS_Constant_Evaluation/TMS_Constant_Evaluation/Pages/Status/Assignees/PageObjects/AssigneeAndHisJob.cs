using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.Pages.Status.Assignees.PageObjects
{
    public class AssigneeAndHisJob
    {

        /* Fields */

        public IWebElement webElement;

        public string assigneeName;
        public string jobName;

        public string sourceLanguage;
        public string targetLanguage;

        /* Properties */

        /* Methods */

        /* Constructors */

        public AssigneeAndHisJob()
        {

        }

        public AssigneeAndHisJob(IWebElement assigneeElement, IWebElement jobElement)
        {

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IEnumerable<IWebElement> auxiliaryEnumerable;
            string auxiliaryString = "";

            Regex languagesRegex = new Regex("(\\w{2}\\-\\w{2})\\s{1}→\\s{1}(\\w{2}\\-\\w{2})");

            auxiliaryCollection = assigneeElement.FindElements(By.ClassName("grp_usr_True"));
            if (auxiliaryCollection.Count > 0) assigneeName = auxiliaryCollection.ElementAt(0).Text;

            auxiliaryString = jobElement.GetAttribute("rowid");

            auxiliaryEnumerable = jobElement.FindElements(By.ClassName("checkboxRow")).Where(x => x.GetAttribute("id") == auxiliaryString);
            if (auxiliaryCollection.Count == 1)
            {

                auxiliaryCollection = auxiliaryEnumerable.ElementAt(0).FindElements(By.ClassName("tlp_on"));
                if (auxiliaryCollection.Count == 1) jobName = auxiliaryCollection.ElementAt(0).Text;

                

            }

            auxiliaryEnumerable = jobElement.FindElements(By.XPath("child::*")).Where(x => languagesRegex.IsMatch(x.Text));
            if (auxiliaryEnumerable.Count() == 1)
            {

                webElement = auxiliaryEnumerable.ElementAt(0);
                auxiliaryString = auxiliaryEnumerable.ElementAt(0).Text;

                sourceLanguage = languagesRegex.Match(auxiliaryString).Groups[1].Value;
                targetLanguage = languagesRegex.Match(auxiliaryString).Groups[2].Value;

            }


        }

    }
}
