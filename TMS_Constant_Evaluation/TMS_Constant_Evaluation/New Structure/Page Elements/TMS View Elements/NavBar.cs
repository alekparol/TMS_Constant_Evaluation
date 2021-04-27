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

namespace TMS_Constant_Evaluation.New_Structure.Page_Elements.TMS_View_Elements
{
    public class NavBar
    {

        /* Fields */

        protected IWebElement navBarPanel;
        protected IWebElement pageName;

        protected IEnumerable<IWebElement> navBarButtons;

        /* Properties */

        public string GetPageName
        {
            get
            {
                return pageName.Text;
            }
        }

        public int GetNavBarButtonsCount
        {
            get
            {
                return navBarButtons.Count();
            }
        }

        public string GetCurrentNavBarName
        {
            get
            {
                return navBarButtons.First(x => x.GetAttribute("class").Contains("hdr_sub_sel")).Text;
            }
        }

        /* Methods */

        /* Constructors */

        public NavBar()
        {

        }

        public NavBar(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav_bar_vws")));

            auxiliaryCollection = driver.FindElements(By.Id("nav_bar_vws"));
            if (auxiliaryCollection.Count != 1) throw new Exception("Navigation panel was not found on the page or was found more than one.");

            navBarPanel = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = navBarPanel.FindElements(By.Id("sel_mnu_itm"));
            if (auxiliaryCollection.Count > 0) pageName = auxiliaryCollection.ElementAt(0);

            auxiliaryCollection = pageName.FindElements(By.XPath(".//span[contains(@class,'hdr_sub')]"));
            if (auxiliaryCollection.Count > 0) navBarButtons = auxiliaryCollection;
        }
    }
}
