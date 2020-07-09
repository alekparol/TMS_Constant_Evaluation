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

        private IWebElement itemsPerPageButton;
        private IWebElement optionListParent;

        /* Drop Down Menu*/
        private IReadOnlyCollection<IWebElement> optionList;
        private IWebElement saveButton;

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

        public int ItemsBodyIsNull
        {
            get
            {
                if (MyProfileBodyIsDisplayed == 1)
                {
                    if (itemsPerPageButton != null)
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

        public int ItemsDropDownListIsExpanded
        {
            get
            {
                if (ItemsBodyIsNull == 0)
                {

                    if (itemsPerPageButton.GetAttribute("class").Contains("chosen-container-active"))
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

        public int ItemsDropDownIsNull
        {
            get
            {
                if (ItemsDropDownListIsExpanded == 1)
                {
                    if (optionList != null)
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

        public int ItemsDropDownIsFull
        {
            get
            {
                if (ItemsDropDownIsNull == 0)
                {
                    if (optionList.Count == 6)
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

        public int ChosenItemsPerPage
        {
            get
            {
                if (ItemsDropDownIsFull == 1)
                {

                    IEnumerable<IWebElement> auxiliaryEnumerable = optionList.Where(x => x.GetAttribute("class").Contains("result-selected"));
                    if (auxiliaryEnumerable.Count() == 1)
                    {
                        return Int32.Parse(auxiliaryEnumerable.ElementAt(0).Text);
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

        public int SaveButtonIsNull
        {
            get
            {
                if (MyProfileBodyIsNull == false)
                {
                    if (saveButton != null)
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

        public int SaveButtonIsDisplayed
        {
            get
            {
                if (SaveButtonIsNull == 0)
                {
                    if (saveButton.Displayed)
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

        /* Methods */

        //TODO: Change void to int to catch all results. 
        public void ItemsDropDownListClick(IWebDriver driver)
        {           

            if (ItemsBodyIsNull == 0)
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                itemsPerPageButton.Click();
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("active-result")));

            }

        }
        //TODO: Change void to int to catch all results. 
        public void ItemsDropDownClick(IWebDriver driver)
        {
           
            if (ItemsDropDownListIsExpanded == 0)
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                ItemsDropDownClick(driver);

                auxiliaryCollection = optionListParent.FindElements(By.TagName("li"));
                if (auxiliaryCollection.Count > 0) optionList = auxiliaryCollection;
            }
        }

        //TODO: Change void to int to catch all results. 
        public void SaveButtonClick(IWebDriver driver)
        {
            if (SaveButtonIsDisplayed == 1)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                saveButton.Click();

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }           
        }

        //TODO: Add variable dependency
        public void ChangeNumberOfItemsDisplayed(IWebDriver driver, int chosenNumber = 25)
        {

            ItemsDropDownClick(driver);

            optionList.ElementAt(0).Click();
            SaveButtonClick(driver);

        }

        /* Constructors */

        public MyProfile(IWebDriver driver)
        {
            if (driver.Url == "https://tms.lionbridge.com/")
            {

                IReadOnlyCollection<IWebElement> auxiliaryCollection;
                IWebElement auxiliaryElement = null;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if (wait.Until(ExpectedConditions.ElementExists(By.Id("pup_bdp"))) != null)
                {
                    auxiliaryCollection = driver.FindElements(By.Id("pup"));
                    if (auxiliaryCollection.Count == 1)
                    {
                        myProfileBody = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_c"));
                        if (auxiliaryCollection.Count == 1) closeButton = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_r"));
                        if (auxiliaryCollection.Count == 1) reduceButton = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_f"));
                        if (auxiliaryCollection.Count == 1) fullscreenButton = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = driver.FindElements(By.XPath("//*[@title='Changing the number of items displayed per page may impact application response times. The default is 250.']"));
                        if (auxiliaryCollection.Count > 0) itemsPerPageButton = auxiliaryCollection.Where(x => x.GetAttribute("style").Contains("width")).ElementAt(0);

                        auxiliaryCollection = itemsPerPageButton.FindElements(By.ClassName("chosen-results"));
                        if (auxiliaryCollection.Count > 0) optionListParent = auxiliaryCollection.ElementAt(0);

                        auxiliaryCollection = driver.FindElements(By.Id("pup_actSave"));
                        if (auxiliaryCollection.Count == 1) saveButton = auxiliaryCollection.ElementAt(0);

                    }                   
                }            

            }
              
        }

    }
}
