using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
using TMS_Constant_Evaluation.MenuLeftContent;

namespace TMS_Constant_Evaluation.MenuLeftContent
{
    class TagMenuPopUp
    {

        /* Fields */

        private IWebDriver driver;
        private IWebElement tagContainer;

        private IWebElement tagBody;
        private IWebElement searchField;

        private IWebElement optionsContainer;
        private IReadOnlyCollection<IWebElement> optionList;

        private IWebElement loadingMessage;

        /* Properties */

        /* Methods */

        /* Constructors */

        public TagMenuPopUp(IWebDriver driver, IWebElement tagContainer)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            this.driver = driver; 

            if (tagContainer.GetAttribute("class") == "m3 lay_flt")
            {
                this.tagContainer = tagContainer;

                auxiliaryCollection = tagContainer.FindElements(By.ClassName("tag_lst"));
                if (auxiliaryCollection.Count == 1)
                {
                    tagBody = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = tagBody.FindElements(By.TagName("input"));
                    if (auxiliaryCollection.Count == 1) searchField = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = tagContainer.FindElements(By.TagName("select"));
                    if (auxiliaryCollection.Count == 1)
                    {
                        optionsContainer = auxiliaryCollection.ElementAt(0);

                        optionList = optionsContainer.FindElements(By.TagName("option"));
                    }
                }
            }
        }



    }
}
