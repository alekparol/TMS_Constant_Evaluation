using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS_Constant_Evaluation.New_Structure.Page_Elements.Buttons;

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.List_Elements
{
    public class HistoryItem
    {
        /* Fields */

        private HistoryItemHeader historyItemHeader;
        private List<HistoryItemElement> historyItemElements;

        /* Properties */

        public HistoryItemHeader HistoryItemHeader
        {
            get
            {
                return historyItemHeader;
            }
        }

        public string HistoryName
        {
            get
            {
                return historyItemHeader.JobName;
            }
        }

        public List<HistoryItemElement> HistoryItemElements
        {
            get
            {
                return historyItemElements;
            }
        }

        /* Methods */

        /* Constructors */

        public HistoryItem()
        {

        }

        public HistoryItem(IWebElement headerObject, List<IWebElement> elementObjects)
        {
            if (headerObject != null) historyItemHeader = new HistoryItemHeader(headerObject);
            else historyItemHeader = new HistoryItemHeader();

            historyItemElements = new List<HistoryItemElement>();

            foreach (IWebElement elementObject in elementObjects)
            {
                historyItemElements.Add(new HistoryItemElement(elementObject));
            }

            if (historyItemHeader.HistoryElementCount != historyItemElements.Count)
            {
                throw new Exception(String.Format("Item header class should contain {0} job elements, instead it contains {1}.", historyItemHeader.HistoryElementCount, historyItemElements.Count));
            }
        }
    }
}
