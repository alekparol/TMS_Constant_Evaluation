using OpenQA.Selenium;
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

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    class PageBar
    {

        /* Fields */

        private IWebElement itemsPerPage;

        private string itemsPerPageSelected;
        private IReadOnlyCollection<IWebElement> itemsPerPageOptions;

        private IWebElement previousPage;
        private IWebElement currentPage;
        private IWebElement nextPage;

        private bool isParsedCorrect;

        /* Properties */

        /* Methods */
        
        /* Constructors */

        /* IWebDriver as a passed argument temporary. 
         * Also, we assume that the page is fully loaded properly so we are not waiting until some element. */
        public PageBar(IWebDriver driver)
        {

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            string auxiliaryString;

            Regex itemsPerPageRegexID = new Regex("msdrpdd\\d+_msdd");

            auxiliaryCollection = driver.FindElements(By.Id("cup_pgp"));
            if (auxiliaryCollection.Count == 1)
            {

                isParsedCorrect = true;

                IWebElement pageBarContainer = auxiliaryCollection.ElementAt(0);
                auxiliaryCollection = pageBarContainer.FindElements(By.ClassName("dd ddSelected"));

                if (auxiliaryCollection.Count > 0)
                {

                    itemsPerPage = auxiliaryCollection.First(x => itemsPerPageRegexID.IsMatch(x.GetAttribute("id")));
                    
                    string itemsPerPageActualID = itemsPerPage.GetAttribute("id");
                    string itemsPerPageTitleTextID = itemsPerPageActualID.Replace("msdd", "titletext");
                    
                    auxiliaryCollection = itemsPerPage.FindElements(By.Id(itemsPerPageTitleTextID));
                    if (auxiliaryCollection.Count == 1) itemsPerPageSelected = auxiliaryCollection.ElementAt(0).Text;

                    string itemsPerPageChildID = itemsPerPageActualID.Replace("msdd", "child");

                    auxiliaryCollection = itemsPerPage.FindElements(By.Id(itemsPerPageChildID));
                    if (auxiliaryCollection.Count == 1) itemsPerPageOptions = auxiliaryCollection.ElementAt(0).FindElements(By.XPath("//a"));

                    auxiliaryCollection = pageBarContainer.FindElements(By.ClassName("pgr_lst"));
                    if (auxiliaryCollection.Count == 1)
                    {
                        IWebElement pageContainer = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageContainer.FindElements(By.ClassName("pgr_prv"));
                        if (auxiliaryCollection.Count == 1) previousPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageContainer.FindElements(By.ClassName("pgr_nxt"));
                        if (auxiliaryCollection.Count == 1) nextPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageContainer.FindElements(By.ClassName("pgr_on"));
                        if (auxiliaryCollection.Count == 1) currentPage = auxiliaryCollection.ElementAt(0);

                    }                

                }

            }

        }

    }
}
