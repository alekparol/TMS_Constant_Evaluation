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

namespace TMS_Constant_Evaluation.Pages
{
    public class Assignee
    {

        /* Fields */

        private IWebElement assigneeNameObject;
        private IWebElement assigneeJobsNumber;
       
        /* Properties */

        public bool AssigneeNameObjectIsNull
        {
            get
            {
                if (assigneeNameObject != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int AssigneeNameObjectIsEnabled
        {
            get
            {
                if (AssigneeNameObjectIsNull == false)
                {
                    if (assigneeNameObject.Enabled)
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

        public string GetAssigneeName
        {
            get
            {
                if (AssigneeNameObjectIsNull == false)
                {
                    return assigneeNameObject.Text;
                }
                else
                {
                    return "";
                }
                
            }
        }

        public int AssigneeJobsNumberIsNull
        {
            get
            {
                if (AssigneeNameObjectIsNull == false)
                {
                    if (assigneeJobsNumber != null)
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

        public string GetAssigneeJobsNumberString
        {
            get
            {
                if (AssigneeJobsNumberIsNull == 0)
                {
                    return assigneeJobsNumber.Text;
                }
                else
                {
                    return "";
                }
            }
        }

        public int GetAssingeeJobsNumberInt
        {
            get
            {
                if (GetAssigneeJobsNumberString != "")
                {
                    return Int32.Parse(assigneeJobsNumber.Text.Trim().Replace("(", "").Replace(")", ""));
                }
                else
                {
                    return -1;
                }           
            }
        }

        public bool IsParsingCorrect
        {
            get
            {
                if (assigneeNameObject != null && assigneeJobsNumber != null)
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

        public Assignee(IWebElement r_LHObject)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            if(r_LHObject.GetAttribute("class") == "r_LH")
            {

                auxiliaryCollection = r_LHObject.FindElements(By.ClassName("grp_usr_True"));
                if (auxiliaryCollection.Count == 1) assigneeNameObject = auxiliaryCollection.ElementAt(0);

                auxiliaryCollection = r_LHObject.FindElements(By.ClassName("r_LCount"));
                if (auxiliaryCollection.Count == 1) assigneeJobsNumber = auxiliaryCollection.ElementAt(0);
            }
        }
    }
}
