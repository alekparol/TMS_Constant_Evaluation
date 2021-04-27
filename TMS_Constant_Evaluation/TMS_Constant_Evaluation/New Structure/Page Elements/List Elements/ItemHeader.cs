using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements
{
    public class ItemHeader
    {

        /* Fields */

        protected IWebElement headerObject;

        protected IWebElement headerTableRow;
        protected IReadOnlyCollection<IWebElement> headerTableData;

        /* Properties */

        public int TableDataCount
        {
            get
            {
                return headerTableData.Count;
            }
        } 

        public IReadOnlyCollection<IWebElement> TableData
        {
            get
            {
                return headerTableData;
            }
        }

        /* Methods */

        /* Constructors */

        public ItemHeader()
        {

        }

        public ItemHeader(IWebElement headerObject)
        {
            if (headerObject.GetAttribute("class") != "r_LH")
            {
                throw new Exception(String.Format("Item header class is not equal to r_LH, instead it is {0}.", headerObject.GetAttribute("class")));
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.headerObject = headerObject;

            auxiliaryCollection = headerObject.FindElements(By.TagName("tr"));
            if (auxiliaryCollection.Count == 1) headerTableRow = auxiliaryCollection.ElementAt(0);

            if (headerTableRow != null)
            {
                auxiliaryCollection = headerTableRow.FindElements(By.TagName("td"));
                if (auxiliaryCollection.Count > 0) headerTableData = auxiliaryCollection;
            }
        }
    }
}
