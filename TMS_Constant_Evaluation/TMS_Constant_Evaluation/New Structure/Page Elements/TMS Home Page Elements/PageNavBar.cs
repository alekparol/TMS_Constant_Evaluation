using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_Home_Page_Elements
{
    public class PageNavBar
    {

        /* Fields */

        private IWebElement pageNavBarPanel;

        private DropDown itemsPerPage;
        private ElementsCount elementsCount;
        private PageList pageList;

        /* Properties */

        public DropDown ItemsPerPage
        {
            get
            {
                return itemsPerPage;
            }
        }

        public ElementsCount ElementsCount
        {
            get
            {
                return elementsCount;
            }
        }

        public PageList PageList
        {
            get
            {
                return pageList;
            }
        }

        /* Methods */

        /* Constructors */

        public PageNavBar()
        {

        }

        public PageNavBar(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.Id("cup_pgp"));
            if (auxiliaryCollection.Count != 1) throw new Exception("Page navigation panel on the page was not found or found more than one.");

            pageNavBarPanel = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = driver.FindElements(By.XPath("//*[contains(@id,\"msdrpdd\") and contains(@id, \"titletext\")]"));
            if (auxiliaryCollection.Count != 1) throw new Exception("Items per page drop down on the page was not found or found more than one.");

            itemsPerPage = new DropDown(driver, auxiliaryCollection.ElementAt(0).GetAttribute("id"));
            elementsCount = new ElementsCount(driver, pageNavBarPanel);
            pageList = new PageList(driver, pageNavBarPanel);

        }

    }
}
