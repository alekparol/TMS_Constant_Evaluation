using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation
{
    public class StatusObject
    {
        /* Fields */

        public string jobName;

        public string sourceTargetLanguages;
        public string jobStatus;

        public int stepsCount;
        public IReadOnlyCollection<IWebElement> stepsCollection;

        public IWebElement moreInfo;
       
        /* Properties */

        /* Methods */

        /* Constructors */

        /*
         * jobName = class="grp_ttl"
         * sourceTargetLanguages = class="grp_lg"
         * jobStatus = class="grp_aty_501 tlp_on title="
         **/

        public StatusObject()
        {
            jobName = string.Empty;

            sourceTargetLanguages = string.Empty;
            jobStatus = string.Empty;

            stepsCount = 0;

            moreInfo = null;

        }

        public StatusObject(IWebElement statusObjectTitle)
        {

            jobName = statusObjectTitle.Text;

            sourceTargetLanguages = statusObjectTitle.FindElement(By.XPath("..")).FindElement(By.ClassName("grp_lg")).Text;
            jobStatus = statusObjectTitle.FindElement(By.XPath("..")).FindElement(By.XPath("//*[contains(@class, 'tlp_on title')]")).Text;

            Int32.TryParse(statusObjectTitle.FindElement(By.XPath("../../..")).FindElement(By.ClassName("r_LCount")).Text,out stepsCount);


        }

        public StatusObject(IWebElement statusObjectTitle, int statusObjectIndex)
        {
            /*
             * The structure of the ActivityObjest is like this: r_LH class element contains all the information which are modeled by fields above,
             * then the r_L class elements are after r_LH and before next r_LH - they are representing steps. After clicking on the step it is no longer
             * a member of [class='r_L'] but r_L row_slt and after it is expanded - there is another element after it which is a member of the class expanded
             * 
             * [class='r_L']*/
        }

    }
}
