using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Lists.List_Objects;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements
{
    public class AssigneeItemElement : ItemElement
    {
        /* Fields */

        private IWebElement jobsName;
        private IWebElement jobsLanguages;
        private IWebElement jobsEffortWordcount;

        Regex jobsLanguagesRegex = new Regex("(\\w{2,3}-\\w{2,3}|N\\/A)\\s{1}→\\s{1}(\\w{2,3}-\\w{2,3}|N\\/A)");
        Regex jobsEffortWordcountRegex = new Regex("(\\d+).*?/.*?(\\d+)");

        protected AssigneeListMenu assigneeListMenu;

        /* Properties */

        public string AssigneeJobsName
        {
            get
            {
                if (jobsName != null)
                {
                    return jobsName.Text;
                }
                else
                {
                    return String.Empty;
                }
                
            }
        } 

        public string AssingeeJobsSourceLanguage
        {
            get
            {
                if (jobsLanguages != null)
                {
                    return jobsLanguagesRegex.Match(jobsLanguages.Text).Groups[1].Value;
                }
                else
                {
                    return String.Empty;
                }        
            }
        }

        public string AssingeeJobsTargetLanguage
        {
            get
            {
                if (jobsLanguages != null)
                {
                    return jobsLanguagesRegex.Match(jobsLanguages.Text).Groups[2].Value;
                }
                else
                {
                    return String.Empty;
                }            
            }
        }

        public string AssingeeJobsEffort
        {
            get
            {
                if (jobsEffortWordcount != null)
                {
                    return jobsEffortWordcountRegex.Match(jobsEffortWordcount.Text).Groups[1].Value;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        public string AssingeeJobsWordcount
        {
            get
            {
                if (jobsEffortWordcount != null)
                {
                    return jobsEffortWordcountRegex.Match(jobsEffortWordcount.Text).Groups[2].Value;
                }
                else
                {
                    return String.Empty;
                }             
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

        public void AssigneeJobClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            jobsLanguages.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"m1 lay_flt\"]")));
        }

        public void SelectJob(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            AssigneeJobClick(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
            assigneeListMenu = new AssigneeListMenu(driver);
        }

        public void TagSingleJob(IWebDriver driver)
        {
            SelectJob(driver);
            assigneeListMenu.ClickTagJobs();
        }

        /* Constructors */

        public AssigneeItemElement()
        {

        }
        public AssigneeItemElement(IWebElement elementObject) : base(elementObject)
        {
            /*jobsName = elementTableData.FirstOrDefault(x => x.GetAttribute("class")
                                                             .Contains("firstColumn"));*/
            jobsName = elementObject.FindElement(By.XPath(".//ul[contains(@class,\"firstColumn\")]"));

            jobsLanguages = elementTableData.FirstOrDefault(x => jobsLanguagesRegex.IsMatch(x.Text));
            jobsEffortWordcount = elementTableData.FirstOrDefault(x => jobsEffortWordcountRegex.IsMatch(x.Text));                                                              
        }
    }
}
