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

        private IWebElement close;
        private IWebElement reduce;
        private IWebElement fullscreen;

        private IWebElement itemsPerPageBody;
        private IWebElement optionListParent;
        private IReadOnlyCollection<IWebElement> optionList;
        private IWebElement save;

        /* Properties */

        public bool BodyIsNull
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

        public bool BodyIsVisibile
        {
            get
            {
                if (myProfileBody.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CloseButtonIsNull
        {
            get
            {
                if (close != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool ReduceButtonIsNull
        {
            get
            {
                if (reduce != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool FullscreenButtonIsNull
        {
            get
            {
                if (fullscreen != null)
                {
                    return false;
                }
                else
                {
                    return true;
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
            if (auxiliaryCollection.Count == 1) close = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_r"));
            if (auxiliaryCollection.Count == 1) reduce = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = myProfileBody.FindElements(By.Id("pup_btn_f"));
            if (auxiliaryCollection.Count == 1) fullscreen = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@title='Changing the number of items displayed per page may impact application response times. The default is 250.']"));
            if (auxiliaryCollection.Count > 0) itemsPerPageBody = auxiliaryCollection.Where(x => x.GetAttribute("style").Contains("width")).ElementAt(0);

            /*auxiliaryCollection = driver.FindElements(By.XPath("//*[@title='Changing the number of items displayed per page may impact application response times. The default is 250.']"));
            if (auxiliaryCollection.Count > 0) auxiliaryElement = auxiliaryCollection.Where(x => x.GetAttribute("id").Contains("pup")).ElementAt(0);

            auxiliaryCollection = auxiliaryElement.FindElements(By.TagName("option"));
            if (auxiliaryCollection.Count > 0) optionList = auxiliaryCollection;*/

            auxiliaryCollection = itemsPerPageBody.FindElements(By.ClassName("chosen-results"));
            if (auxiliaryCollection.Count > 0) optionListParent = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.Id("pup_actSave"));
            if (auxiliaryCollection.Count == 1) save = auxiliaryCollection.ElementAt(0);

        }

    }
}
