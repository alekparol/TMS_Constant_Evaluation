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
    public class AssigneeElement
    {

        /* Fields */
        private string assigneeName;
        private int assigneeJobsNumber;
        private string assigneeLanguage;

        private List<AssigneesJobs> assigneesJobList;
        private IReadOnlyCollection<IWebElement> jobList;

        private bool isParsedCorrectly;

        /* Properties */

        public string AssigneeName
        {
            get
            {
                return assigneeName;
            }
        }

        public int AssigneeJobsNumber
        {
            get
            {
                return assigneeJobsNumber;
            }
        }

        public string AssigneeLanguage
        {
            get
            {
                return assigneeLanguage;
            }
        }

        public List<AssigneesJobs> AssigneesJobsList
        {
            get
            {
                return assigneesJobList;
            }
        }

        public IReadOnlyCollection<IWebElement> JobList
        {
            get
            {
                return jobList;
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        /* Methods */

        /* Constructors */

        public AssigneeElement(Assignees assignee, List<AssigneesJobs> assigneeJobs)
        {

            Regex jobsNumber = new Regex("\\d*");

            if (assignee.IsParsingCorrect)
            {
                assigneeName = assignee.AssigneeName;
                assigneeJobsNumber = assignee.AssingeeJobsInt;
            }

            if (assigneeJobs.Count > assigneeJobsNumber)
            {

                string auxiliaryTargetLanguage; 

                assigneesJobList = assigneeJobs.GetRange(0, assigneeJobsNumber);
                auxiliaryTargetLanguage = assigneesJobList[0].TargetLanguage;

                foreach(AssigneesJobs el in assigneesJobList)
                {
                    //jobList.Append(el.JobsIWebElement);
                    if (el.TargetLanguage != auxiliaryTargetLanguage)
                    {
                        auxiliaryTargetLanguage = null;
                    }
                }

                if (auxiliaryTargetLanguage != null)
                {
                    assigneeLanguage = auxiliaryTargetLanguage;
                    isParsedCorrectly = true;
                }
                
            }


        }

    }
}
