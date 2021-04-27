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

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_Home_Page_Elements
{
    public class CupMessage
    {

        /* Fields */

        protected IWebElement cupMessage;

        /* Properties */

        public string GetCupMessage
        {
            get
            {
                return cupMessage.Text;
            }
        }

        /* Methods */

        /* Constructors */

        /* Constructors */
        public CupMessage()
        {

        }

        public CupMessage(IWebDriver driver, IWebElement parentElement)
        {

            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            string auxiliaryString;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementExists(By.Id("cup_msg")));

            auxiliaryCollection = parentElement.FindElements(By.Id("cup_msg"));
            if (auxiliaryCollection.Count != 1) throw new Exception("Message on the page was not found or found more than one.");
            cupMessage = auxiliaryCollection.ElementAt(0);
        }

    }
}
