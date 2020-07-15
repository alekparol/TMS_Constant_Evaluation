﻿using OpenQA.Selenium;
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
        private IWebElement lastPage;
        private IWebElement nextPage;

        /* Number of All Items */
        private IWebElement numberOfAllItems;

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

        public int PageNavigationContainerIsNull
        {
            get
            {
                if (PageBarContainerIsNull == false)
                {
                    if (pageNavigationContainer != null)
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

        public int PageNavigationContainerIsVisible
        {
            get
            {
                if (PageNavigationContainerIsNull == 0)
                {
                    if (pageNavigationContainer.Displayed)
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

        public int PreviousPageIsNull
        {
            get
            {
                if (PageNavigationContainerIsNull == 0)
                {
                    if (previousPage != null)
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

        public int CurrentPageIsNull
        {
            get
            {
                if (PageNavigationContainerIsNull == 0)
                {
                    if (currentPage != null)
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

        public int CurrentPageIsFirst
        {
            get
            {
                if (CurrentPageIsNull == 0)
                {
                    if (PreviousPageIsNull == 1)
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

        public int CurrentPageIsLast
        {
            get
            {
                if (CurrentPageIsNull == 0)
                {
                    if (NextPageIsNull == 1)
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

        public int GetCurrentPageNumber
        {
            get
            {
                if (CurrentPageIsNull == 0)
                {
                    Regex number = new Regex("\\d*");
                    string auxiliaryString;


                    if (number.IsMatch(currentPage.Text))
                    {
                        auxiliaryString = number.Match(currentPage.Text).ToString();
                        return Int32.Parse(auxiliaryString);
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

        public int LastPageIsNull
        {
            get
            {
                if (PageNavigationContainerIsNull == 0)
                {
                    if (lastPage != null)
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

        public int GetLastPageNumber
        {
            get
            {
                if (LastPageIsNull == 0)
                {
                    Regex number = new Regex("\\d*");
                    string auxiliaryString;


                    if (number.IsMatch(lastPage.Text))
                    {
                        auxiliaryString = number.Match(lastPage.Text).ToString();
                        return Int32.Parse(auxiliaryString);
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

        public int NextPageIsNull
        {
            get
            {
                if (PageNavigationContainerIsNull == 0)
                {
                    if (nextPage != null)
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

        public int NumberOfAllItemsIsNull
        {
            get
            {
                if (PageBarContainerIsNull == false)
                {
                    if (numberOfAllItems != null)
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

        public int NumberOfAllItemsIsDisplayed
        {
            get
            {
                if (NumberOfAllItemsIsNull == 0)
                {
                    if (numberOfAllItems.Displayed)
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

        public int GetNumberOfAllItems
        {
            get
            {
                if (NumberOfAllItemsIsNull == 0)
                {
                    Regex number = new Regex("\\d*");
                    string auxiliaryString;

                    if (number.IsMatch(numberOfAllItems.Text))
                    {
                        auxiliaryString = number.Match(numberOfAllItems.Text).ToString();
                        return Int32.Parse(auxiliaryString);
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

        public bool IsParsingCorrect
        {
            get
            {
                if (PageBarContainerIsDisplayed == 1 && NumberOfAllItemsIsDisplayed == 1)
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

            if (this.NextPageIsNull == 1)
            {
                nextPage.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        public void GoToPreviousPage(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            if (this.PreviousPageIsNull == 1)
            {
                previousPage.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }
        }

        /* Constructors */
        public PageBar(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                string auxiliaryString;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementExists(By.Id("cup_pgp")));
                 
                auxiliaryCollection = driver.FindElements(By.Id("cup_pgp"));
                if (auxiliaryCollection.Count == 1)
                {

                    pageBarContainer = auxiliaryCollection.ElementAt(0);

                    auxiliaryCollection = pageBarContainer.FindElements(By.XPath("//*[@class='dd ddSelected']"));
                    if (auxiliaryCollection.Count > 0)
                    {

                        itemsPerPageContainer  = auxiliaryCollection.ElementAt(0);

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
