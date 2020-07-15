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

        /* Items Per Page Drop Down (Could be transited to a new class) */
        private IWebElement itemsPerPageContainer;

        private IWebElement itemsPerPageOptionsContainer;
        private IReadOnlyCollection<IWebElement> itemsPerPageOptions;
        
        private IWebElement itemsPerPageSelected; // Might be useless - use property instead.

        /* Page Bar */
        private IWebElement pageNavigationContainer;

        private IWebElement previousPage;
        private IWebElement currentPage;
        private IWebElement nextPage;

        private IWebElement lastPage;

        private bool isParsedCorrectly;

        /* Properties */

        public bool PageBarContainerIsNull
        {
            get
            {
                if (pageBarContainer != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int PageBarContainerIsDisplayed
        {
            get
            {
                if (PageBarContainerIsNull == false)
                {
                    if (pageBarContainer.Displayed)
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

        /* Items Per Page Drop Down */

        public int ItemsPerPageContainerIsNull
        {
            get
            {
                if (PageBarContainerIsNull == false)
                {
                    if (itemsPerPageContainer  != null)
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

        public int ItemsPerPageOptionsContainerIsNull
        {
            get
            {
                if (ItemsPerPageContainerIsNull == 0)
                {
                    if (itemsPerPageOptionsContainer != null)
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

        public int ItemsPerPageOptionsContainerIsDisplayed
        {
            get
            {
                if (ItemsPerPageOptionsContainerIsNull == 0)
                {
                    if (itemsPerPageOptionsContainer.Displayed)
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

        public int ItemsPerPageOptionsIsNull
        {
            get
            {
                if (ItemsPerPageOptionsContainerIsNull == 0)
                { 
                    if (itemsPerPageOptions != null)
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

        public int ItemsPerPageOptionsCount
        {
            get
            {
                if (ItemsPerPageOptionsIsNull == 0)
                {
                    return itemsPerPageOptions.Count;
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Page Bar */

        public bool PageBarIsNull
        {
            get
            {
                if (pageNavigationContainer != null)
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
                if (this.PageBarIsNull)
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
                if (this.PageBarIsNull)
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
                if (this.PageBarIsNull)
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
                if (this.PageBarIsNull)
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

            itemsPerPageContainer.Click();
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("ddChild borderTop")));

        }

        public void SetMaximalItems(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            if (itemsPerPageContainer  != null)
            {
                itemsPerPageContainer.Click();
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

                        itemsPerPageContainer  = auxiliaryCollection.Where(x => x.GetAttribute("id").Contains("msdrpdd")).ElementAt(0);

                        auxiliaryCollection = itemsPerPageContainer.FindElements(By.ClassName("ddChild"));
                        if (auxiliaryCollection.Count == 1) itemsPerPageOptionsContainer = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = itemsPerPageOptionsContainer.FindElements(By.TagName("a"));
                        if (auxiliaryCollection.Count > 0) itemsPerPageOptions = auxiliaryCollection;

                        itemsPerPageSelected = itemsPerPageOptions.Where(x => x.GetAttribute("class").Contains("selected")).ElementAt(0);

                    }

                    auxiliaryCollection = pageBarContainer.FindElements(By.ClassName("pgr_lst"));
                    if (auxiliaryCollection.Count > 0)
                    {

                        pageNavigationContainer = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageNavigationContainer.FindElements(By.ClassName("pgr_prv"));
                        if (auxiliaryCollection.Count == 1) previousPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageNavigationContainer.FindElements(By.ClassName("pgr_nxt"));
                        if (auxiliaryCollection.Count == 1) nextPage = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = pageNavigationContainer.FindElements(By.TagName("li"));
                        if (auxiliaryCollection.Count > 0) lastPage = auxiliaryCollection.ElementAt(auxiliaryCollection.Count - 2);

                        auxiliaryCollection = pageNavigationContainer.FindElements(By.ClassName("pgr_on"));
                        if (auxiliaryCollection.Count == 1) currentPage = auxiliaryCollection.ElementAt(0);

                    }


                }  

            }

        }

    }
}
