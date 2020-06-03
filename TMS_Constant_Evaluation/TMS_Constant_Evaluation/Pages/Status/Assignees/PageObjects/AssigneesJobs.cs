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

        private string jobsName;

        private bool isParsedCorrectly;

        /* Properties */

        public string JobsName
        {
            get
            {
                return jobsName;
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
                

            }
        }

    }
}
