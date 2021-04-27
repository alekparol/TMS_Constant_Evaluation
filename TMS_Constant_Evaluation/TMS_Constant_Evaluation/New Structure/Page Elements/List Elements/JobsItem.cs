using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements
{
    public class JobsItem : ItemElement
    {
        /* Fields */

        private IWebElement jobsName;
        private IWebElement jobsLanguages;
        private IWebElement jobsEffort;

        Regex jobsLanguagesRegex = new Regex("(\\w{2,3}-\\w{2,3}|N\\/A)\\s{1}→\\s{1}(\\w{2,3}-\\w{2,3}|N\\/A)");

        /* Properties */

        public string JobsJobName
        {
            get
            {
                return jobsName.Text;
            }
        }

        public bool IsSelected
        {
            get
            {
                if (elementObject.GetAttribute("class").Contains("row_slt"))
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

        public void JobsJobClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            jobsEffort.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"m1 lay_flt\"]")));
        }

        /* Constructors */

        public JobsItem()
        {

        }
        public JobsItem(IWebElement elementObject) : base(elementObject)
        {
            jobsName = elementTableData.FirstOrDefault(x => x.GetAttribute("class")
                                                             .Contains("firstColumn"));

            jobsLanguages = elementTableData.FirstOrDefault(x => jobsLanguagesRegex.IsMatch(x.Text));
            jobsEffort = elementTableData.ElementAt(elementTableData.Count - 1);
        }
    }
}
