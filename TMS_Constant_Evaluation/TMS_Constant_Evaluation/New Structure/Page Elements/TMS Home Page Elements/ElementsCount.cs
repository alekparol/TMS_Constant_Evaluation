using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_Home_Page_Elements
{
    public class ElementsCount : CupMessage
    {

        /* Fields */

        /* Properties */

        public int GetNumberOfAllItems
        {
            get
            {
                Regex number = new Regex("\\d*");
                string auxiliaryString;

                if (number.IsMatch(cupMessage.Text))
                {
                    auxiliaryString = number.Match(cupMessage.Text).Value;
                    return Int32.Parse(auxiliaryString);
                }
                else
                {
                    return 0;
                }
            }
        }

        /* Methods */

        /* Constructors */

        /* Constructors */
        public ElementsCount()
        {

        }

        public ElementsCount(IWebDriver driver, IWebElement pageNavBarPanel) : base(driver, pageNavBarPanel)
        {

        }
    }
}
