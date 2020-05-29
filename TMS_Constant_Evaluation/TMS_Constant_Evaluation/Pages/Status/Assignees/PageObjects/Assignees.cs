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

namespace TMS_Constant_Evaluation.Pages
{
    public class Assignees
    {

        /* Fields */

        private IWebElement containerObject;

        private string assigneeName;
        private int assigneeJobsNumber;

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
                return AssigneeJobsNumber;
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

        public Assignees(IWebElement r_LHObject)
        {

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            string auxiliaryString;

            if(r_LHObject.GetAttribute("class") == "r_LH")
            {
                isParsedCorrectly = true;

                auxiliaryCollection = r_LHObject.FindElements(By.ClassName("grp_usr_True"));
                if (auxiliaryCollection.Count == 1) assigneeName = auxiliaryCollection.ElementAt(0).Text;

                auxiliaryCollection = r_LHObject.FindElements(By.ClassName("r_LCount"));
                if (auxiliaryCollection.Count == 1)
                {
                    auxiliaryString = auxiliaryCollection.ElementAt(0).Text;

                    if (auxiliaryString.Length > 0)
                    {

                        auxiliaryString = auxiliaryString.Replace("(", "").Replace(")", "");
                        Int32.TryParse(auxiliaryString, out assigneeJobsNumber);
                    }

                }

            }

        }

    }
}