using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements
{
    public class ItemElement
    {

        /* Fields */

        protected IWebElement elementObject;

        protected IReadOnlyCollection<IWebElement> elementTableData;

        /* Properties */

        public int TableDataCount
        {
            get
            {
                return elementTableData.Count;
            }
        }

        public IReadOnlyCollection<IWebElement> TableData
        {
            get
            {
                return elementTableData;
            }
        }

        /* Methods */

        /* Constructors */

        public ItemElement()
        {

        }
        public ItemElement(IWebElement elementObject)
        {
            if (elementObject.GetAttribute("class") != "r_L")
            {
                throw new Exception(String.Format("Item header class is not equal to r_L, instead it is {0}.", elementObject.GetAttribute("class")));
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.elementObject = elementObject;

            if (elementObject != null)
            {
                auxiliaryCollection = elementObject.FindElements(By.TagName("td"));
                if (auxiliaryCollection.Count > 0) elementTableData = auxiliaryCollection;
            }            
        }
    }
}
