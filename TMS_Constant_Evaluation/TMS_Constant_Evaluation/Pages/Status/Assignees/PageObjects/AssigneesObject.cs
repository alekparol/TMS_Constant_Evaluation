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
    public class AssigneesObject
    {

        /* Fields */



        /* Properties */

        /* Methods */

        /* Constructors */ 
        
        /* I think the process should be like that: 
         * 1. We get the whole list of assignees on the internal review page. 
         * 2. We get the whole list of the assignees jobs on the internal review page. 
         * 3. We go through the assignees list and create an AssigneesObject for each element - passing jobs numbers we get the list of the assignees 
         * jobs containing the jobs from the whole list of jobs from 0 to number of jobs for this assignee - 1. 
         * 4. We delete the jobs assigneed for the assignee from the list. 
         * 5. We do it until the list of assignees is on the end and list of jobs.count == 0. 
         **/
        public AssigneesObject(Assignees assignee, List<AssigneesJobs> assigneesJobs)
        {

        }

    }
}
