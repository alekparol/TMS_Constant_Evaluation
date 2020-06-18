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
    public class PageBar
    {

        /* Fields */

        private IWebElement pageBarContainer;

        private IWebElement itemsPerPage;

        private IWebElement itemsPerPageChild;
        private IWebElement itemsPerPageSelected;
        private IReadOnlyCollection<IWebElement> itemsPerPageOptions;

        private IWebElement pageContainer;

        private IWebElement previousPage;
        private IWebElement currentPage;
        private IWebElement lastPage;
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

        public IWebElement CurrentPage
        {
            get
            {
                return currentPage;
            }
        }

        public bool IsParsedCorrectly
        {
            get
            {
                return isParsedCorrectly;
            }
        }

        /* Methods */

        public void ItemsPerPageClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            itemsPerPage.Click();
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("ddChild borderTop")));

        }

        public void SetMaximalItems(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            if (itemsPerPage != null)
            {
                itemsPerPage.Click();
                itemsPerPageOptions.ElementAt(itemsPerPageOptions.Count - 1).Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            }

        }

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
                previousPage.Click();

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
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("pgr_lst")));

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                string auxiliaryString;

                auxiliaryCollection = driver.FindElements(By.Id("cup_pgp"));
                if (auxiliaryCollection.Count == 1)
                {

                    isParsedCorrectly = true;

                    pageBarContainer = auxiliaryCollection.ElementAt(0);
                    auxiliaryCollection = pageBarContainer.FindElements(By.XPath("//*[@class='dd ddSelected']"));

                    if (auxiliaryCollection.Count > 0)
                    {

                        itemsPerPage = auxiliaryCollection.Where(x => x.GetAttribute("id").Contains("msdrpdd")).ElementAt(0);

                        auxiliaryCollection = itemsPerPage.FindElements(By.ClassName("ddChild"));
                        if (auxiliaryCollection.Count == 1) itemsPerPageChild = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = itemsPerPageChild.FindElements(By.TagName("a"));
                        if (auxiliaryCollection.Count > 0) itemsPerPageOptions = auxiliaryCollection;

                        itemsPerPageSelected = itemsPerPageOptions.Where(x => x.GetAttribute("class").Contains("selected")).ElementAt(0);

                    }

                    auxiliaryCollection = pageBarContainer.FindElements(By.ClassName("pgr_lst"));
                    if (auxiliaryCollection.Count > 0)
                    {

                        pageContainer = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageContainer.FindElements(By.ClassName("pgr_prv"));
                        if (auxiliaryCollection.Count == 1) previousPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageContainer.FindElements(By.ClassName("pgr_nxt"));
                        if (auxiliaryCollection.Count == 1) nextPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageContainer.FindElements(By.TagName("li"));
                        if (auxiliaryCollection.Count > 0) lastPage = auxiliaryCollection.ElementAt(auxiliaryCollection.Count - 2);

                        auxiliaryCollection = pageContainer.FindElements(By.ClassName("pgr_on"));
                        if (auxiliaryCollection.Count == 1) currentPage = auxiliaryCollection.ElementAt(0);

                    }


                }  

            }

        }

    }
}
