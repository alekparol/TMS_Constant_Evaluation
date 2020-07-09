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
    public class MyProfile
    {

        /* Fields */

        private IWebElement myProfileBody;

        private IWebElement closeButton;
        private IWebElement reduceButton;
        private IWebElement fullscreenButton;

        private IWebElement itemsPerPageBody;
        private IWebElement optionListParent;
        private IReadOnlyCollection<IWebElement> optionList;
        private IWebElement save;

        /* Properties */

        public bool MyProfileBodyIsNull
        {
            get
            {
                if (myProfileBody != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int MyProfileBodyIsDisplayed
        {
            get
            {
                if (MyProfileBodyIsNull == false)
                {
                    if (myProfileBody.Displayed)
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

        public int CloseButtonIsNull
        {
            get
            {
                if (MyProfileBodyIsNull == false)
                {
                    if (closeButton != null)
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

        public int CloseButtonIsDisplayed
        {
            get
            {
                if (CloseButtonIsNull == 0)
                {
                    if (closeButton.Displayed)
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
        public int ReduceButtonIsNull
        {
            get
            {
                if (MyProfileBodyIsNull == false)
                {
                    if (reduceButton != null)
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

        public int ReduceButtonIsDisplayed
        {
            get
            {
                if (ReduceButtonIsNull == 0)
                {
                    if (reduceButton.Displayed)
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

        public int FullscreenButtonIsNull
        {
            get
            {
                if (MyProfileBodyIsNull == false)
                {
                    if (fullscreenButton != null)
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

        public int FullscreenButtonIsDisplayed
        {
            get
            {
                if (FullscreenButtonIsNull == 0)
                {
                    if (fullscreenButton.Displayed)
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

        public bool ItemsBodyIsNull
        {
            get
            {
                if (itemsPerPageBody != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int ItemsCount
        {
            get
            {
                return optionList.Count;
            }
        }

        public int ItemsChosen
        {
            get
            {
                return Int32.Parse(optionList.Where(x => x.GetAttribute("class").Contains("result-selected")).ElementAt(0).Text);
            }
        }

        public bool SaveIsNull
        {
            get
            {
                if (save != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /* Methods */

        public void ItemsDropDownClick(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            itemsPerPageBody.Click();

            wait.Until(ExpectedConditions.ElementExists(By.ClassName("active-result")));            
            
            auxiliaryCollection = optionListParent.FindElements(By.TagName("li"));
            if (auxiliaryCollection.Count > 0) optionList = auxiliaryCollection;

        }

        public void SaveClick(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            save.Click();

            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

        }

        public void ChangeNumberOfItemsDisplayed(IWebDriver driver, int chosenNumber = 25)
        {

            ItemsDropDownClick(driver);

            optionList.ElementAt(0).Click();
            SaveClick(driver);

        }

        /* Constructors */

        public MyProfile(IWebDriver driver)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IWebElement auxiliaryElement = null;

            wait.Until(ExpectedConditions.ElementExists(By.Id("pup_bdp")));

            auxiliaryCollection = driver.FindElements(By.Id("pup"));
            if (auxiliaryCollection.Count == 1) myProfileBody = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_c"));
            if (auxiliaryCollection.Count == 1) closeButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_r"));
            if (auxiliaryCollection.Count == 1) reduceButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_f"));
            if (auxiliaryCollection.Count == 1) fullscreenButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@title='Changing the number of items displayed per page may impact application response times. The default is 250.']"));
            if (auxiliaryCollection.Count > 0) itemsPerPageBody = auxiliaryCollection.Where(x => x.GetAttribute("style").Contains("width")).ElementAt(0);

            auxiliaryCollection = itemsPerPageBody.FindElements(By.ClassName("chosen-results"));
            if (auxiliaryCollection.Count > 0) optionListParent = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("pup_actSave"));
            if (auxiliaryCollection.Count == 1) save = auxiliaryCollection.ElementAt(0);

        }

    }
}
