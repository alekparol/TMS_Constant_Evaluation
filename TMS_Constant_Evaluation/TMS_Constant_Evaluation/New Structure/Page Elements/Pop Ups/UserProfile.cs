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
    public class UserProfile
    {

        /* Fields */

        private IWebElement userProfileBody;

        private IWebElement closeButton;
        private IWebElement reduceButton;
        private IWebElement fullscreenButton;

        private IWebElement itemsPerPageButton;
        private IWebElement optionListParent;

        /* Drop Down Menu*/
        private IReadOnlyCollection<IWebElement> optionList;
        private IWebElement saveButton;

        /* Properties */    

        public int IsItemsPerPageMenuUnfolded
        {
            get
            {
                if (itemsPerPageButton != null)
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

        public int GetItemsPerPageCount
        {
            get
            {
                if (itemsPerPageButton != null)
                {
                    return optionList.Count;
                }
                return 0;
            }
        }

        public int GetCurrentItemsPerPage
        {
            get
            {
                if (itemsPerPageButton != null)
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

        /* Methods */

        public void ItemsPerPageClick(IWebDriver driver)
        {           
            if (userProfileBody != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                itemsPerPageButton.Click();
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("active-result")));
            }
        }

        public void DropDownInitialization(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            if (IsItemsPerPageMenuUnfolded == 0) ItemsPerPageClick(driver);

            auxiliaryCollection = optionListParent.FindElements(By.TagName("li"));
            if (auxiliaryCollection.Count > 0) optionList = auxiliaryCollection;
        }

        public void SaveButtonClick(IWebDriver driver)
        {
            if (saveButton.Displayed == true)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                saveButton.Click();

                //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod_c")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("pup_btn_c")));
            }           
        }

        public void ItemsPerPageMinimal(IWebDriver driver)
        {
            DropDownInitialization(driver);

            optionList.ElementAt(0).Click();
            SaveButtonClick(driver);
        }

        public void ItemsPerPageMaximal(IWebDriver driver)
        {
            DropDownInitialization(driver);

            optionList.ElementAt(optionList.Count - 1).Click();
            SaveButtonClick(driver);
        }

        /* Constructors */

        public UserProfile()
        {

        }

        public UserProfile(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            IWebElement auxiliaryElement = null;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementExists(By.Id("pup_bdp")));

            auxiliaryCollection = driver.FindElements(By.Id("pup"));
            if (auxiliaryCollection.Count != 1) throw new Exception("User profile was not found on the page or was found more than one.");

            userProfileBody = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = userProfileBody.FindElements(By.Id("pup_btn_c"));
            if (auxiliaryCollection.Count == 1) closeButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = userProfileBody.FindElements(By.Id("pup_btn_r"));
            if (auxiliaryCollection.Count == 1) reduceButton = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = userProfileBody.FindElements(By.Id("pup_btn_f"));
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
