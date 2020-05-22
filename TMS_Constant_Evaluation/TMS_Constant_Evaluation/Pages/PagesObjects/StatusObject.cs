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

    }
}
