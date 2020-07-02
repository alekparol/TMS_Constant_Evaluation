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
using TMS_Constant_Evaluation.Pages.PagesObjects;

namespace TMS_Constant_Evaluation.Pages
{
    class AbstractPage1
    {

        /* Fields */

        private IWebElement selectedProject;

        private IWebElement loggedUser;
        private IWebElement userActivitiesMenu;
        private IReadOnlyCollection<IWebElement> userActivitiesList;

        private MyProfile myProfileInstance;

        private bool isParsedCorrectly;

    }
}
