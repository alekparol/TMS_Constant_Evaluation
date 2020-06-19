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
    public class AssigneesAndTheirJobs
    {

        /* Fields */

        private List<AssigneeAndHisJob> assigneesAngTheirJobsList;

        private bool isParsedCorrectly;

        /* Properties */

        /* Methods */

        /* Constructors */

        public AssigneesAndTheirJobs(IReadOnlyCollection<IWebElement> assigneesList, IReadOnlyCollection<IWebElement> jobsList)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            AssigneeAndHisJob auxiliaryObject = new AssigneeAndHisJob();

            int jobNumber;

            if (assigneesList.Count > 0 && assigneesList.ElementAt(0).GetAttribute("class") == "r_LH" &&
                jobsList.Count > 0 && jobsList.ElementAt(0).GetAttribute("class") == "r_L")
            {
                isParsedCorrectly = true;

                foreach (IWebElement assignee in assigneesList)
                {

                    auxiliaryCollection = assignee.FindElements(By.ClassName("r_LCount"));
                    if (auxiliaryCollection.Count == 1)
                    {
                        jobNumber = Int32.Parse(auxiliaryCollection.ElementAt(0).Text.Trim().Replace("(", "").Replace(")", ""));

                        for (int i = 0; i <= jobNumber; i++)
                        {
                            auxiliaryObject = new AssigneeAndHisJob(assignee, jobsList.ElementAt(i));
                            assigneesAngTheirJobsList.Add(auxiliaryObject);
                        }

                    }

                }

            }

        }

    }
}
