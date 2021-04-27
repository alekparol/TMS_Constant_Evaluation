using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_Home_Page_Elements
{
    public class PageList
    {

        /* Fields */
        private IWebElement pagesListPanel;

        private IWebElement previousPage;
        private IWebElement currentPage;
        private IWebElement nextPage;

        private IReadOnlyCollection<IWebElement> pageList;
        private IWebElement firstPage;
        private IWebElement lastPage;

        /* Properties */

        /* Page Bar */

        public int PageListCount
        {
            get
            {
                return pageList.Count;
            }
        }

        public bool IsPageListEmpty
        {
            get
            {
                if (PageListCount > 0)
                {
                    return false;
                }
                else
                {
                    return true; 
                }
            }
        }

        public int IsCurrentPageFirst
        {
            get
            {
                if (currentPage != null)
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

        public int IsCurrentPageLast
        {
            get
            {
                if (currentPage != null)
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

        public int FirstPageNumber
        {
            get
            {
                if (firstPage != null)
                {
                    Regex number = new Regex("\\d*");
                    string auxiliaryString;


                    if (number.IsMatch(firstPage.Text))
                    {
                        auxiliaryString = number.Match(firstPage.Text).ToString();
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

        public int CurrentPageNumber
        {
            get
            {
                if (currentPage != null)
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

        public int LastPageNumber
        {
            get
            {
                if (lastPage != null)
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

        /* Methods */

        private void NavigateToPage(IWebDriver driver, IWebElement buttonElement)
        {
            if (IsPageListEmpty == false)
            {
                if (buttonElement != null)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                    buttonElement.Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
                }
            }
        }

        public void GoToFirstPage(IWebDriver driver)
        {
            NavigateToPage(driver, firstPage);
        }

        public void GoToLastPage(IWebDriver driver)
        {
            NavigateToPage(driver, lastPage);
        }

        public void GoToNextPage(IWebDriver driver)
        {
            NavigateToPage(driver, nextPage);
        }

        public void GoToPreviousPage(IWebDriver driver)
        {
            NavigateToPage(driver, previousPage);
        }

        /* Constructors */
        public PageList()
        {

        }


        public PageList(IWebDriver driver, IWebElement pageNavBarPanel)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = pageNavBarPanel.FindElements(By.ClassName("pgr_lst"));
            if (auxiliaryCollection.Count != 1) throw new Exception("Page navigation panel on the page was not found or found more than one.");

            pagesListPanel = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = pagesListPanel.FindElements(By.ClassName("pgr_prv"));
            if (auxiliaryCollection.Count == 1) previousPage = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = pagesListPanel.FindElements(By.ClassName("pgr_on"));
            if (auxiliaryCollection.Count == 1) currentPage = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = pagesListPanel.FindElements(By.ClassName("pgr_nxt"));
            if (auxiliaryCollection.Count == 1) nextPage = auxiliaryCollection.ElementAt(0);

            pageList = pagesListPanel.FindElements(By.TagName("li"));
            if (pageList.Count > 0)
            {
                if (previousPage == null) firstPage = auxiliaryCollection.ElementAt(0);
                else firstPage = auxiliaryCollection.ElementAt(1);

                if (nextPage == null) lastPage = auxiliaryCollection.ElementAt(auxiliaryCollection.Count - 1);
                else lastPage = auxiliaryCollection.ElementAt(auxiliaryCollection.Count - 2);
            }

        }
    }
}
