using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons
{
    public class FilterInitButton : Button
    {

        /* Fields */

        /* Properties */

        public override int ButtonIsClicked
        {
            get
            {
                if (buttonWebElement != null)
                {
                    if (buttonWebElement.GetAttribute("class").Contains("icn_flt_on"))
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

        public void ButtonClick()
        {
            if (buttonWebElement != null)
            {
                if (buttonWebElement != null)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                    buttonWebElement.Click();

                    // Wait for the filters panel to appear. 
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lf")));
                }
            }
        }

        /* Constructors */

        public FilterInitButton()
        {

        }

        public FilterInitButton(IWebElement parentElement, IWebDriver driver, string idLocator) : base(parentElement, driver, idLocator)
        {

        }

    }
}
