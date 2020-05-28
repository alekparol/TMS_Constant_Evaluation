using OpenQA.Selenium;
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

namespace TMS_Constant_Evaluation.Pages.PagesObjects
{
    class PageBar
    {

        /* Fields */

        private IWebElement itemsPerPage;

        private string itemsPerPageSelected;
        private IReadOnlyCollection<IWebElement> itemsPerPageOptions;

        private IWebElement pageContainer;

        private IWebElement previousPage;
        private IWebElement currentPage;
        private IWebElement nextPage;

        private bool isParsedCorrectly;

        /* Properties */

        public bool IfPageBarExists
        {
            get
            {
                if (pageContainer == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int IfPreviousPageExists
        {
            get
            {
                if (this.IfPageBarExists)
                {
                    if (previousPage == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int IfNextPageExists
        {
            get
            {
                if (this.IfPageBarExists)
                {
                    if (nextPage == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int IfFirstPage
        {
            get
            {
                if (this.IfPageBarExists)
                {
                    if (this.IfPreviousPageExists == 1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int IfLastPage
        {
            get
            {
                if (this.IfPageBarExists)
                {
                    if (this.IfNextPageExists == 1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Methods */ 

        public void GoToNextPage(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            if (this.IfNextPageExists == 1)
            {
                nextPage.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        public void GoToPreviousPage(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            if (this.IfPreviousPageExists == 1)
            {
                nextPage.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        /* Constructors */

        /* IWebDriver as a passed argument temporary. 
         * Also, we assume that the page is fully loaded properly so we are not waiting until some element. */
        public PageBar(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {
                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                string auxiliaryString;

                Regex itemsPerPageRegexID = new Regex("msdrpdd\\d+_msdd");

                auxiliaryCollection = driver.FindElements(By.Id("cup_pgp"));
                if (auxiliaryCollection.Count == 1)
                {

                    isParsedCorrectly = true;

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
                            pageContainer = auxiliaryCollection.ElementAt(0);

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
}
