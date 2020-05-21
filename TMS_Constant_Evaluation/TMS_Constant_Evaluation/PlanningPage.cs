using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation
{
    class PlanningPage
    {

        /* Fields */

        private IWebElement planningTitle; // This is title of the page to validate if the page was displayed properly.

        private IWebElement filtersButton;
        private IWebElement activityList;
        private IWebElement statusList;



        /* Constructors */

        /* filtersButton //button[contains(text(),'Filters')]
         *  after clicking the bar should be displayed - it should be validated by checking if next element "Activity" is displayed. 
         *  It can be checked <input type="hidden" name="cup$display" id="cup_display" value="display:none"> - when the Filters is not clicked. 
         *  <input type="hidden" name="cup$display" id="cup_display" value=""> if is. 
         *  activityList //*[@id='cup_fpStepActivityName_titletext']
         *  statusList //*[@id='cup_fpStatusId_titletext']
         *  
         *  After clicking on activityList there will be dropDown menu displayed. Each element has an id cup_fpStepActivityName_msa_N, where N 
         *  is an index of the option. There should be created list there to check it with a regex expression. Also cup_fpStepActivityName_msa_N is 
         *  an option with text the same as the field.
         * */

    }
}
