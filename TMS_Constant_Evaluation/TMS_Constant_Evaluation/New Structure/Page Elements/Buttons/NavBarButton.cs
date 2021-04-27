using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.PagesObjects;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons
{
    public class NavBarButton : Button
    {

        /* Fields */

        /* Properties */

        public override int ButtonIsClicked
        {
            get
            {
                if (buttonWebElement != null)
                {
                    if (buttonWebElement.GetAttribute("class").Contains("hdr_sub_sel"))
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

        /* Methods */

        /* Constructors */

        public NavBarButton() 
        {

        }

        public NavBarButton(IWebElement parentElement, IWebDriver driver, string idLocator) : base(parentElement, driver, idLocator)
        {

        }
    }
}
