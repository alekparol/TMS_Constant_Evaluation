using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation
{
    class StatusPage
    {

        /* Fields */

        public IWebElement pageTitle; // This is title of the page to validate if the page was displayed properly.

        public IWebElement filtersButton;

        public IWebElement jobsFilter;
        public IWebElement activityFilter;

        public IReadOnlyCollection<IWebElement> jobsList;
        public IReadOnlyCollection<IWebElement> activityList;


        /* Constructors */

        /* filtersButton //button[contains(text(),'Filters')]
         *  after clicking the bar should be displayed - it should be validated by checking if next element "Activity" is displayed. 
         *  It can be checked <input type="hidden" name="cup$display" id="cup_display" value="display:none"> - when the Filters is not clicked. 
         *  <input type="hidden" name="cup$display" id="cup_display" value=""> if is. 
         *  activityList //*[@id='cup_fpStepActivityName_titletext']
         *  statusList //*[@id='cup_fpStatusId_titletext']
         *  
         *  Options from the list are child nodes of cup_fpStepActivityName_child.
         *  
         *  After clicking on activityList there will be dropDown menu displayed. Each element has an id cup_fpStepActivityName_msa_N, where N 
         *  is an index of the option. There should be created list there to check it with a regex expression. Also cup_fpStepActivityName_msa_N is 
         *  an option with text the same as the field.
         * */

        public StatusPage(IWebDriver statusPageDriver)
        {
            
            Regex jobsListRegex = new Regex("cup_fpJobId_msa_\\d+");
            Regex activityListRegex = new Regex("cup_fpStepActivityName_msa_\\d+");

            IWebElement jobsChild;
            IWebElement activityChild;

            var auxiliaryValidationList = statusPageDriver.FindElements(By.XPath("//*[@id='sel_mnu_itm']"));


            if(auxiliaryValidationList.Count == 1)
            {
                pageTitle = auxiliaryValidationList[0];
            }

            auxiliaryValidationList = statusPageDriver.FindElements(By.XPath("//button[contains(text(),'Filters')]"));

            if(auxiliaryValidationList.Count == 1)
            {
                filtersButton = auxiliaryValidationList[0];
            }

            if(filtersButton != null)
            {
                filtersButton.Click();
                Thread.Sleep(35000);
            }

            auxiliaryValidationList = statusPageDriver.FindElements(By.XPath("//*[@id='cup_fpJobId_msdd']"));

            if(auxiliaryValidationList.Count == 1)
            {
                jobsFilter = auxiliaryValidationList[0];
            }

            auxiliaryValidationList = statusPageDriver.FindElements(By.XPath("//*[@id='cup_fpStepActivityName_msdd']"));

            if(auxiliaryValidationList.Count == 1)
            {
                activityFilter = auxiliaryValidationList[0];
            }

            //auxiliaryValidationList = statusPageDriver.FindElements(By.XPath("//*[@id='cup_fpJobId_msdd']"))[0].FindElements(By.XPath("//div[@id='cup_fpJobId_child']"));

            /*if(auxiliaryValidationList.Count == 1)
            {
                jobsChild = auxiliaryValidationList[0];
                jobsList = jobsChild.FindElements(By.XPath(".//*"));

                foreach(IWebElement element in jobsList)
                {
                    if (jobsListRegex.Match(element.GetAttribute("id")) == null)
                    { 
                        
                    }
                }
            }*/

        }

    }
}
